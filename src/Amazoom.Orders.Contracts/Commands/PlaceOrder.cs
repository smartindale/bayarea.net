using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazoom.Orders.Contracts.Commands
{
    public class PlaceOrder
    {
        Guid OrderId { get; set; }

        string CustomerId { get; set; }

        decimal Amount { get; set; }


    }
}
