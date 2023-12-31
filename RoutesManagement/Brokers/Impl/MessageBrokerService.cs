using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace RoutesManagement.Brokers.Impl
{
    public class MessageBrokerService : IMessageBrokerService
    {
        private readonly IConfiguration configuration;
        public MessageBrokerService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IConnection CreateConnection()
        {
            var hostName = configuration.GetSection("MessageBroker:HostName").Value;
            var factory = new ConnectionFactory
            {
                HostName = configuration.GetSection("MessageBroker:HostName").Value,
                Port = int.Parse(configuration.GetSection("MessageBroker:Port").Value),
                UserName = configuration.GetSection("MessageBroker:Username").Value,
                Password = configuration.GetSection("MessageBroker:Password").Value
            };

            return factory.CreateConnection();
        }

        public void Publish<T>(Queues queue, T message)
        {
            var connection = CreateConnection();
            using var channel = connection.CreateModel();
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            channel.BasicPublish("", queue.ToString(), body: body);
        }
    }
}
