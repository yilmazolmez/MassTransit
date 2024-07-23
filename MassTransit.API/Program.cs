using MassTransit;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(configuration.GetValue<string>("RabbitMQSettings:RabbitMQUri"), rabbitMQHostConfigurator =>
        {
            rabbitMQHostConfigurator.Username(configuration.GetValue<string>("RabbitMQSettings:RabbitMQUserName"));
            rabbitMQHostConfigurator.Password(configuration.GetValue<string>("RabbitMQSettings:RabbitMQPassword"));
        });

        //cfg.Host(configuration.GetConnectionString("RabbitMQ")); //LOCAL
    });
});

#region MassTransit 7.2 version
//builder.Services.AddMassTransitHostedService();
#endregion

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var app = builder.Build();




if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
