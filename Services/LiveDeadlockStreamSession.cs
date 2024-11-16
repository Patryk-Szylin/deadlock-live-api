using System.Diagnostics;
using System.Reflection;
using DemoFile;
using DemoFile.Game.Deadlock;

public class LiveDeadlockStreamSession
{
    private readonly LiveMatchEventStreamerService _eventStreamer;
    private readonly EventCallbackRegistryService _eventCallbackRegistry;
    private DeadlockDemoParser Demo { get; set; }
    private CancellationToken CancellationToken { get; }
    private string MatchId { get; }
    private string LiveMatchUrl { get; }
    private string BaseUrl { get; } = "http://dist1-ord1.steamcontent.com/tv/";

    public LiveDeadlockStreamSession(LiveMatchEventStreamerService eventStreamer, EventCallbackRegistryService registryService, string matchId,
        CancellationToken cancellationToken)
    {
        _eventStreamer = eventStreamer;
        _eventCallbackRegistry = registryService;
        MatchId = matchId;
        CancellationToken = cancellationToken;
        LiveMatchUrl = $"{BaseUrl}{matchId}/";
    }

    public async Task WatchGame(Action? onSuccessfulConnectionCallback = null)
    {
        try
        {
            Demo = new DeadlockDemoParser();

            SubscribeToEvents();

            var tickInterval = TimeSpan.Zero;
            Demo.PacketEvents.SvcServerInfo += e =>
            {
                tickInterval = TimeSpan.FromSeconds(e.TickInterval);
                Console.WriteLine($"Server tick rate: {1 / e.TickInterval:N0}");
            };

            var httpReader = HttpBroadcastReader.Create(Demo, new Uri(LiveMatchUrl));
            Console.WriteLine("Starting stream...");
            Console.WriteLine($"Connecting to URL: {LiveMatchUrl}");

            await httpReader.StartReadingAsync(CancellationToken);
            await httpReader.MoveNextAsync(CancellationToken);
            
            onSuccessfulConnectionCallback?.Invoke();

            var startTime = Stopwatch.GetTimestamp();
            var firstTick = Demo.CurrentDemoTick;

            Console.WriteLine("Playing broadcast in realtime...");

            while (!CancellationToken.IsCancellationRequested)
            {
                var prevTick = Demo.CurrentDemoTick;

                var sw = Stopwatch.StartNew();
                if (!await httpReader.MoveNextAsync(default))
                {
                    break;
                }

                var gameElapsed = (Demo.CurrentDemoTick - firstTick).Value * tickInterval;
                var wallClockElapsed = Stopwatch.GetElapsedTime(startTime);

                var drift = gameElapsed - wallClockElapsed;
                var adjustmentRatio = Math.Clamp(drift.TotalSeconds / 0.200, -1.0, 1.0);
                var adjust = TimeSpan.FromSeconds(0.200 * adjustmentRatio);

                var ticksAdvanced = (Demo.CurrentDemoTick - prevTick).Value;
                var sleepUntilNextTick = tickInterval * ticksAdvanced - sw.Elapsed + adjust;

                if (sleepUntilNextTick > TimeSpan.Zero)
                    await Task.Delay(sleepUntilNextTick, CancellationToken);
            }

            Console.WriteLine("\nFinished!");
            // TODO: Cleanup: redis key, kafka topic events and etc.
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
            throw; // TODO: Re-throw or handle the exception appropriately
        }
    }

    private void SubscribeToEvents()
    {
        _eventCallbackRegistry.RegisterGameEvents(MatchId, Demo.GameEvents);
        _eventCallbackRegistry.RegisterSource1GameEvents(MatchId, Demo.Source1GameEvents);
        _eventCallbackRegistry.RegisterUserMessageEvents(MatchId, Demo.UserMessageEvents);
    }
}