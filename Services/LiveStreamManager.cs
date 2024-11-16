
using System.Collections.Concurrent;

public class LiveStreamManager
{
    private readonly LiveMatchTrackerService _trackerService;
    private readonly LiveMatchEventStreamerService _eventStreamer;
    private readonly ConcurrentDictionary<string, CancellationTokenSource> _activeStreams;

    public LiveStreamManager(LiveMatchTrackerService trackerService, LiveMatchEventStreamerService eventStreamer)
    {
        _trackerService = trackerService;
        _eventStreamer = eventStreamer;
        _activeStreams = new ConcurrentDictionary<string, CancellationTokenSource>();
    }

    public async Task StartLiveStream(string matchId)
    {
        if (await _trackerService.IsStreamActiveAsync(matchId))
        {
            Console.WriteLine($"Match {matchId} is already active.");
            return;
        }

        var cts = new CancellationTokenSource();
        _activeStreams[matchId] = cts;

        _ = Task.Run(async () =>
        {
            try
            {
                Console.WriteLine($"Starting match {matchId}...");
                await _trackerService.StartLiveGameAsync(matchId);
                await _eventStreamer.StreamEventsAsync(matchId, cts.Token);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine($"Match {matchId} streaming cancelled.");
            }
            finally
            {
                _activeStreams.TryRemove(matchId, out _);
                await _trackerService.StopMatchAsync(matchId);
                Console.WriteLine($"Stopped match {matchId}.");
            }
        }, cts.Token);
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