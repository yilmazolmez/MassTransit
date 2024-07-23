using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransit.Contract.Commands
{
    public interface ITestCommand
    {
        public string Name { get; set; }
    }

    public class TestCommand : ITestCommand
    {
        public string Name { get; set; }
    }
}
