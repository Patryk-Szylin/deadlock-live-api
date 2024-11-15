using System.Diagnostics;
using DemoFile;

public class DeadlockService
{
    public async Task WatchDemo(string matchId, CancellationToken cancellationToken)
    {
        var baseUrl = "http://dist1-ord1.steamcontent.com/tv/";
        var url = $"{baseUrl}{matchId}/";

        try
        {
            var demo = new DeadlockDemoParser();
            demo.Source1GameEvents.Source1GameEvent += e =>
            {
                Console.WriteLine($"Game event: {e}");
            };

            var tickInterval = TimeSpan.Zero;
            demo.PacketEvents.SvcServerInfo += e =>
            {
                tickInterval = TimeSpan.FromSeconds(e.TickInterval);
                Console.WriteLine($"Server tick rate: {1 / e.TickInterval:N0}");
            };

            var httpReader = HttpBroadcastReader.Create(demo, new Uri(url));
            Console.WriteLine("Starting stream...");
            Console.WriteLine($"Connecting to URL: {url}");

            await httpReader.StartReadingAsync(default);
            await httpReader.MoveNextAsync(default);

            var startTime = Stopwatch.GetTimestamp();
            var firstTick = demo.CurrentDemoTick;

            Console.WriteLine("Playing broadcast in realtime...");
            // while (!cancellationToken.IsCancellationRequested)
            while (true)
            {
                var prevTick = demo.CurrentDemoTick;

                var sw = Stopwatch.StartNew();
                if (!await httpReader.MoveNextAsync(default))
                {
                    break;
                }

                var gameElapsed = (demo.CurrentDemoTick - firstTick).Value * tickInterval;
                var wallClockElapsed = Stopwatch.GetElapsedTime(startTime);

                var drift = gameElapsed - wallClockElapsed;
                var adjustmentRatio = Math.Clamp(drift.TotalSeconds / 0.200, -1.0, 1.0);
                var adjust = TimeSpan.FromSeconds(0.200 * adjustmentRatio);

                var ticksAdvanced = (demo.CurrentDemoTick - prevTick).Value;
                var sleepUntilNextTick = tickInterval * ticksAdvanced - sw.Elapsed + adjust;

                if (sleepUntilNextTick > TimeSpan.Zero)
                    await Task.Delay(sleepUntilNextTick, cancellationToken);
            }

            Console.WriteLine("\nFinished!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
            throw; // Re-throw or handle the exception appropriately
        }
    }
}