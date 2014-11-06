using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amazoom.Portal.Models
{
    public class OrderModel
    {
        public string CustomerId { get; set; }

        public decimal Amount { get; set; }
    }
}