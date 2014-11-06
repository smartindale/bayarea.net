using Amazoom.Orders.Contracts.Commands;
using Amazoom.Portal.Models;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Amazoom.Portal.Controllers.Api
{
    public class OrderController : ApiController
    {
        private readonly IBus _bus;

        public OrderController(IBus bus)
        {
            _bus = bus;
        }
        public void Post(OrderModel model)
        {
            _bus.Send<PlaceOrder>(x =>
            {
                x.OrderId = Guid.NewGuid();
                x.CustomerId = model.CustomerId;
                x.Amount = model.Amount;
            });
        }
    }
}
