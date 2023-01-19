using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Dto.OrderDTO
{
    public class UpdateOrderDTO
    {
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public int SellerId { get; set; }
    }
}