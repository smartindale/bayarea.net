using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazoom.Orders.Endpoint
{
    public class LogStartup : IWantToRunWhenBusStartsAndStops
    {
        static ILog _log = LogManager.GetLogger(typeof(LogStartup));

        public void Start()
        {
            _log.Warn("Orders Endpoint running...");

        }

        public void Stop()
        {
        }
    }
}
