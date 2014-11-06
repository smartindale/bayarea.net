using Amazoom.Orders.Contracts.Events;
using Amazoom.Portal.Hubs;
using Amazoom.Shipping.Contracts.Events;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amazoom.Portal.Handlers
{
    public class OrderHandler : IHandleMessages<IPlacedAnOrder>
        , IHandleMessages<IShippedAnOrder>
    {
        static ILog _log = LogManager.GetLogger(typeof(OrderHandler));
        private readonly IBus _bus;

        public OrderHandler(IBus bus)
        {
            _bus = bus;
        }
        public void Handle(IPlacedAnOrder message)
        {
            var payload = new
            {
                OrderId = message.OrderId,
                Amount = message.Amount,
                CustomerId = message.CustomerId,
            };
            var connectionManager = GlobalHost.DependencyResolver.GetService(typeof(IConnectionManager)) as IConnectionManager;
            var connection = connectionManager.GetHubContext<OrdersHub>();

            connection.Clients.Client(message.CustomerId).showOrderConfirmation(payload);
            
        }

        public void Handle(IShippedAnOrder message)
        {
            var payload = new
            {
                OrderId = message.OrderId,
                Amount = message.Amount,
                CustomerId = message.CustomerId,
            };
            var connectionManager = GlobalHost.DependencyResolver.GetService(typeof(IConnectionManager)) as IConnectionManager;
            var connection = connectionManager.GetHubContext<OrdersHub>();

            connection.Clients.Client(message.CustomerId).showShippingConfirmation(payload);
        }
    }
}