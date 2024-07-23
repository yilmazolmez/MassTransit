using MassTransit.Contract.Commands;
using MassTransit.Contract.Constant;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace MassTransit.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public TestController(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        [HttpPost]
        public async Task Post([FromBody] string name)
        {
            ISendEndpoint sendEnpoint;

            sendEnpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{RabbitMQSettingsConst.TestCommandConsumerQueue}"));

            await sendEnpoint.Send<ITestCommand>(new TestCommand() { Name = name });
        }
    }
}
