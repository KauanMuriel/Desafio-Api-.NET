using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Dto.OrderItemDTO
{
    public class UpdateOrderItemDTO
    {
        public int ServiceId { get; set; }
        public int Quantity { get; set;}
        public decimal Value { get; set; }
    }
}