
using Confluent.Kafka;

/**
 * Service to produce live match events to Kafka
 */
public class LiveMatchEventProducerService
{
    private readonly IProducer<string, string> _producer;

    public LiveMatchEventProducerService(string bootstrapServers)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = bootstrapServers
        };

        _producer = new ProducerBuilder<string, string>(config).Build();
    }
    
    public async Task PublishEventAsync(string topic, string key, string message)
    {
        try
        {
            var result = await _producer.ProduceAsync(topic, new Message<string, string>
            {
                Key = key,
                Value = message
            });

            Console.WriteLine($"Message delivered to {result.TopicPartitionOffset}");
        }
        catch (ProduceException<string, string> ex)
        {
            Console.WriteLine($"Failed to deliver message: {ex.Error.Reason}");
        }
    }

}
