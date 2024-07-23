using MassTransit.Contract.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransit.ConsumerService.Consumers
{
    public class TestCommandConsumer : IConsumer<ITestCommand>
    {
        public Task Consume(ConsumeContext<ITestCommand> context)
        {
            var message = context.Message;

            return Task.CompletedTask;
        }
    }
}
