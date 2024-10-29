// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;

Console.WriteLine("Hello, World!");

var factory = new ConnectionFactory { Uri = new Uri("amqp://guest:guest@localhost:5672/") };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

// Declare exchanges, queues, and bindings
channel.ExchangeDeclare("deposit_withdraw_exchange", ExchangeType.Fanout, durable: true);

channel.QueueDeclare("users_deposit_withdraw_queue", durable: true, exclusive: false, autoDelete: false);
channel.QueueDeclare("transactions_deposit_withdraw_queue", durable: true, exclusive: false, autoDelete: false);


channel.QueueBind("users_deposit_withdraw_queue", "deposit_withdraw_exchange", "");
channel.QueueBind("transactions_deposit_withdraw_queue", "deposit_withdraw_exchange", "");

Console.WriteLine("RabbitMQ resources initialized.");