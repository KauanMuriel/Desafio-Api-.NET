using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Dto.OrderDTO;

namespace SistemaVendas.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int SellerId { get; set; } // Foreign key
        public Seller Seller { get; set;}
        public int CustomerId { get; set; } // Foreign key
        public Customer Customer { get; set;}

        public Order()
        {
        }

        public Order(RegisterOrderDTO dto)
        {
            Date = dto.Date;
            SellerId = dto.SellerId;
            CustomerId = dto.CustomerId;
        }

        public void MapUpdateOrder(UpdateOrderDTO dto)
        {
            Date = dto.Date;
            SellerId = dto.SellerId;
            CustomerId = dto.CustomerId;
        }
    }
}