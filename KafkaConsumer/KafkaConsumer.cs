using Confluent.Kafka;

namespace KafkaConsumerExample;

public class KafkaConsumer
{
    private readonly IConsumer<string, string> _consumer;

    public KafkaConsumer(string bootstrapServers, string groupId)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = bootstrapServers,
            GroupId = groupId,
            AutoOffsetReset = AutoOffsetReset.Earliest
        };
        _consumer = new ConsumerBuilder<string, string>(config).Build();
    }

    public void Consume(string topic)
    {
        _consumer.Subscribe(topic);

        try
        {
            while (true)
            {
                var result = _consumer.Consume();
                Console.WriteLine($"Consumed message: {result.Message.Value}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error consuming message: {ex.Message}");
        }
        finally
        {
            _consumer.Close();
        }
    }
}

