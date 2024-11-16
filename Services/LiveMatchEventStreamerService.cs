
using System.Text.Json;

/**
 * Service to stream live match events to Kafka.
 */
public class LiveMatchEventStreamerService
{
    private readonly LiveMatchEventProducerService _kafkaProducerService;

    public LiveMatchEventStreamerService(LiveMatchEventProducerService kafkaProducerService)
    {
        _kafkaProducerService = kafkaProducerService;
    }
    
    public async Task SendEventAsync<T>(T eventObj, string matchId, string eventName, Func<T, object> createPayload)
    {
        var payload = createPayload(eventObj);
        var eventPayload = JsonSerializer.Serialize(payload);

        Console.WriteLine($"{eventName} with payload: {JsonSerializer.Serialize(payload)}");
        
        await _kafkaProducerService.PublishEventAsync($"game-streams-{matchId}", eventName, eventPayload);
    }
}
