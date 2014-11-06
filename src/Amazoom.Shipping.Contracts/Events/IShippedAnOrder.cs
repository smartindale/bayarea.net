using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazoom.Shipping.Contracts.Events
{
    public interface IShippedAnOrder
    {
        Guid OrderId { get; set; }

        string CustomerId { get; set; }

        decimal Amount { get; set; }
    }
}
