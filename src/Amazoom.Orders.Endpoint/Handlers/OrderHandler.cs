using Amazoom.Orders.Contracts.Commands;
using Amazoom.Orders.Contracts.Events;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazoom.Orders.Endpoint.Handlers
{
    public class OrderHandler : IHandleMessages<PlaceOrder>
    {
        static ILog _log = LogManager.GetLogger(typeof(OrderHandler));
        private IBus _bus;
        public OrderHandler(IBus bus)
        {
            _bus = bus;
        }
        public void Handle(PlaceOrder message)
        {
            _log.WarnFormat("Placing order {0}", message.OrderId);
            _bus.Publish<IPlacedAnOrder>(e =>
            {
                e.Amount = message.Amount;
                e.CustomerId = message.CustomerId;
                e.OrderId = message.OrderId;
            });
        }
    }
}
