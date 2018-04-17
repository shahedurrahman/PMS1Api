using System;
using System.Collections.Generic;
using System.Text;

namespace PMS1Api.Models.EFModels
{
    public class Order
    {
        public int OrderId { get; set; }
        public int DrugId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        //public Guid Userid { get; set; }
        public DateTimeOffset? OrderDate { get; set; }
    }
}
