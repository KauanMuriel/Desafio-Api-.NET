using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Dto.OrderDTO
{
    public class RegisterOrderDTO
    {
        public DateTime Date { get; set; }
        public int SellerId { get; set; } // Foreign key
        public int CustomerId { get; set; } // Foreign key
    }
}