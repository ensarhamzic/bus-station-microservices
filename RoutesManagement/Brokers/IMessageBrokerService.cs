using RabbitMQ.Client;

namespace RoutesManagement.Brokers
{
    public interface IMessageBrokerService
    {
        IConnection CreateConnection();
        void Publish<T>(Queues queue, T message);
    }
}
