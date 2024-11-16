
/**
 * This is a background service that runs in the background and checks for active matches
 * that are being watched by users. If a match is being watched, it will start a stream
 * for that match. Also handles re-connection logic in case of stream failure or API crashes
 */
public class LiveMatchStreamWorker : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public LiveMatchStreamWorker(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("LiveMatchStreamWorker started.");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var trackerService = scope.ServiceProvider.GetRequiredService<LiveMatchTrackerService>();
                var manager = scope.ServiceProvider.GetRequiredService<LiveStreamManager>();

                // Get active matches from Redis
                var activeMatches = await trackerService.GetAllActiveStreamsAsync();

                // TODO: Batch Request to Redis
                foreach (var matchId in activeMatches)
                {
                    if (!manager.IsStreamOpened(matchId).Result)
                    {
                        Console.WriteLine($"Resuming stream for match {matchId}...");
                        await manager.StartLiveStream(matchId);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in worker: {ex.Message}");
            }

            // Wait before checking again
            await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
        }

        Console.WriteLine("LiveMatchStreamWorker stopping...");
    }

}
