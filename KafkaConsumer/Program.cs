using KafkaConsumerExample;

var bootstrapServers = "localhost:9092";
var groupId = "test-group";
var topic = "test-topic";

var consumer = new KafkaConsumer(bootstrapServers, groupId);
consumer.Consume(topic);