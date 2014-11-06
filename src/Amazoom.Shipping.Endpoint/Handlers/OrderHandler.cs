using Amazoom.Orders.Contracts.Events;
using Amazoom.Shipping.Contracts.Events;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazoom.Shipping.Endpoint.Handlers
{
    public class OrderHandler : IHandleMessages<IPlacedAnOrder>
    {
        static ILog _log = LogManager.GetLogger(typeof(OrderHandler));
        private readonly IBus _bus;

        public OrderHandler(IBus bus)
        {
            _bus = bus;
        }
        public void Handle(IPlacedAnOrder message)
        {
            _log.WarnFormat("Shipping order {0}", message.OrderId);
            _bus.Publish<IShippedAnOrder>(e =>
            {
                e.Amount = message.Amount;
                e.CustomerId = message.CustomerId;
                e.OrderId = message.OrderId;
            });
        }
    }
}
