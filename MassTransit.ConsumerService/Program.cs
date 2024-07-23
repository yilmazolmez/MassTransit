using MassTransit;
using MassTransit.ConsumerService;
using MassTransit.ConsumerService.Consumers;
using MassTransit.Contract.Constant;

Microsoft.Extensions.Hosting.IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddMassTransit(cfg =>
        {
            cfg.AddConsumer<TestCommandConsumer>();

            cfg.AddBus(context => Bus.Factory.CreateUsingRabbitMq(configure =>
            {
                configure.Host(hostContext.Configuration.GetValue<string>("RabbitMQSettings:RabbitMQUri"), rabbitMQHostConfigurator =>
                {
                    rabbitMQHostConfigurator.Username(hostContext.Configuration.GetValue<string>("RabbitMQSettings:RabbitMQUserName"));
                    rabbitMQHostConfigurator.Password(hostContext.Configuration.GetValue<string>("RabbitMQSettings:RabbitMQPassword"));
                });

                configure.ReceiveEndpoint(RabbitMQSettingsConst.TestCommandConsumerQueue, e =>
                {
                    e.ConfigureConsumer<TestCommandConsumer>(context);
                    //e.PrefetchCount = 16;
                });
            }));
        });

        services.AddMassTransitHostedService();
        services.AddHostedService<Worker>();
    })
    .Build();


host.Run();
