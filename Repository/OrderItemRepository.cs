using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Context;
using SistemaVendas.Models;

namespace SistemaVendas.Repository
{
    public class OrderItemRepository
    {
        private readonly SalesContext _context;

        public OrderItemRepository(SalesContext context)
        {
            _context = context;
        }

        public OrderItem Register(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
            _context.SaveChanges();

            return orderItem;
        }

        public List<OrderItem> List(int orderId)
        {
            var orderItems = _context.OrderItems
                                    .OrderBy(x => x.OrderItemId)
                                    .ToList();
                            
            return orderItems;
        }

        public OrderItem GetOrderItem(int orderId, int serviceId)
        {
            var orderItem = List(orderId).SingleOrDefault(x => x.ServiceId == serviceId);
            return orderItem;
        }

        public void DeleteOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Remove(orderItem);
            _context.SaveChanges();
        }

        public OrderItem Update(OrderItem orderItem) 
        {
            _context.OrderItems.Update(orderItem);
            _context.SaveChanges();

            return orderItem;
        }
    }
}