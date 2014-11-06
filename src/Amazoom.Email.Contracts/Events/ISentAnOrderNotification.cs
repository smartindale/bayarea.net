using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazoom.Email.Contracts.Events
{
    public interface ISentAnOrderNotification
    {
        Guid OrderId { get; set; }

        string CustomerId { get; set; }

        decimal Amount { get; set; }
    }
}
