using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransit.Contract.Constant
{
    public class RabbitMQSettingsConst
    {
        private const string MassTransitServicesPrefix = "MassTransit.";


        public static string TestCommandConsumerQueue { get; } = MassTransitServicesPrefix + nameof(TestCommandConsumerQueue);
    }
}
