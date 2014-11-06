﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazoom.Orders.Contracts.Commands
{
    public class PlaceOrder
    {
        public Guid OrderId { get; set; }

        public string CustomerId { get; set; }

        public decimal Amount { get; set; }


    }
}
