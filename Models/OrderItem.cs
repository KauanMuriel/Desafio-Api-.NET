using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set;}
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public int Quantity { get; set;}
        public decimal Value { get; set; }
    }
}