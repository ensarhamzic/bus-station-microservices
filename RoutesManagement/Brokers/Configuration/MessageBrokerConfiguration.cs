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
        private readonly IServiceProvider serviceProvider;

        public MessageBrokerConfiguration(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var messageBrokerService = serviceProvider.GetRequiredService<IMessageBrokerService>();
            using (var connection = messageBrokerService.CreateConnection())
            using (var channel = connection.CreateModel())
            {
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
                            var busService = serviceProvider.GetRequiredService<IBusService>();
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
