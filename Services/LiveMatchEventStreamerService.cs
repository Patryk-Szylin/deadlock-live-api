
using System.Text.Json;

public class LiveMatchEventStreamerService
{
    private readonly LiveMatchEventProducerService _kafkaProducerService;

    public LiveMatchEventStreamerService(LiveMatchEventProducerService kafkaProducerService)
    {
        _kafkaProducerService = kafkaProducerService;
    }
    
    public async Task StreamEventsAsync(string matchId, CancellationToken cancellationToken)
    {
        // Simulate streaming events
        while (!cancellationToken.IsCancellationRequested)
        {
            var eventData = new
            {
                MatchId = matchId,
                EventTime = DateTime.UtcNow,
                EventType = "GameUpdate",
                Payload = "Some event data"
            };

            var message = JsonSerializer.Serialize(eventData);
            await _kafkaProducerService.PublishEventAsync($"game-streams-{matchId}", matchId, message);

            Console.WriteLine($"Published event for match {matchId}");
            await Task.Delay(1000, cancellationToken); // Simulate event frequency
        }
    }
    
    
}
