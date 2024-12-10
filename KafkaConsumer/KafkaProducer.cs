using Confluent.Kafka;

namespace KafkaProducerExample;

public class KafkaProducer
{
    private readonly IProducer<string, string> _producer;

    public KafkaProducer(string bootstrapServers)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = bootstrapServers
        };
        _producer = new ProducerBuilder<string, string>(config).Build();
    }

    public async Task ProduceMessageAsync(string topic, string key, string value)
    {
        try
        {
            var result = await _producer.ProduceAsync(topic, new Message<string, string>
            {
                Key = key,
                Value = value
            });

            Console.WriteLine($"Message sent to {result.TopicPartitionOffset}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error producing message: {ex.Message}");
        }
    }
}

