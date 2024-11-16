using System.Collections.Concurrent;

public class LiveStreamManager
{
    private readonly LiveMatchTrackerService _trackerService;
    private readonly LiveMatchEventStreamerService _eventStreamer;
    private readonly EventCallbackRegistryService _eventCallbackRegistry;
    private readonly ConcurrentDictionary<string, CancellationTokenSource> _activeStreams;

    public LiveStreamManager(LiveMatchTrackerService trackerService, EventCallbackRegistryService eventCallbackRegistry,
        LiveMatchEventStreamerService eventStreamer)
    {
        _trackerService = trackerService;
        _eventStreamer = eventStreamer;
        _eventCallbackRegistry = eventCallbackRegistry;
        _activeStreams = new ConcurrentDictionary<string, CancellationTokenSource>();
    }

    public Task StartLiveStream(string matchId)
    {
        if (_activeStreams.ContainsKey(matchId))
        {
            Console.WriteLine($"Match {matchId} is already active.");
            return Task.CompletedTask;
        }

        var cts = new CancellationTokenSource();
        _activeStreams[matchId] = cts;

        _ = Task.Run(async () =>
        {
            var session = new LiveDeadlockStreamSession(_eventStreamer, _eventCallbackRegistry, matchId, cts.Token);

            // TODO: Handle:
            // 1. Match not found
            try
            {
                Console.WriteLine($"Starting match {matchId}...");
                await session.WatchGame(() =>
                {
                    // Record the match in redis.
                    _ = Task.Run(async () =>
                    {
                        try
                        {
                            await _trackerService.StartLiveGameAsync(matchId);
                        } catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }, default);
                });
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine($"Match {matchId} streaming cancelled.");
            }
            finally
            {
                _activeStreams.TryRemove(matchId, out _);
                await _trackerService.StopMatchAsync(matchId);
                Console.WriteLine($"Stopped streaming match: {matchId}.");
            }
        }, cts.Token);
        return Task.CompletedTask;
    }

    public void StopStream(string matchId)
    {
        if (_activeStreams.TryRemove(matchId, out var cts))
        {
            cts.Cancel();
        }
    }

    public async Task<bool> IsStreamOpened(string matchId)
    {
        return await _trackerService.IsStreamActiveAsync(matchId);
    }
}