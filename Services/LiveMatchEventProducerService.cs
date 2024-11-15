
using Confluent.Kafka;

public class LiveMatchEventProducerService
{
    private readonly IProducer<string, string> _producer;
    private readonly string _bootstrapServers;
    
    public LiveMatchEventProducerService(string bootstrapServers)
    {
        _bootstrapServers = bootstrapServers;

        var config = new ProducerConfig
        {
            BootstrapServers = _bootstrapServers
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
