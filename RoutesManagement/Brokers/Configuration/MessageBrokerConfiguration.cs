using Microsoft.OpenApi.Writers;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RoutesManagement.Data.ViewModels;
using RoutesManagement.Services;
using System.Text;

namespace RoutesManagement.Brokers.Configuration
{
    public class MessageBrokerConfiguration : IHostedService
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public MessageBrokerConfiguration(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var scope = serviceScopeFactory.CreateScope();
            var messageBrokerService = scope.ServiceProvider.GetRequiredService<IMessageBrokerService>();
            var connection = messageBrokerService.CreateConnection();
            var channel = connection.CreateModel();

            foreach (var queue in Enum.GetValues(typeof(Queues)))
            {
                channel.QueueDeclare(queue: queue.ToString(), durable: false, exclusive: false, autoDelete: false, arguments: null);
            }

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                switch (ea.RoutingKey)
                {
                    case nameof(Queues.Buses):
                        var busService = scope.ServiceProvider.GetRequiredService<IBusService>();
                        var bus = JsonConvert.DeserializeObject<AddBusVM>(message);
                        busService.AddBus(bus);
                        break;
                    default:
                        break;
                }
            };

            foreach (var queue in Enum.GetValues(typeof(Queues)))
            {
                channel.BasicConsume(queue: queue.ToString(), autoAck: true, consumer: consumer);
            }
            await Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            // perform cleanup if needed
            return Task.CompletedTask;
        }
    }
}
