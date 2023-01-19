using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaVendas.Context;
using SistemaVendas.Models;

namespace SistemaVendas.Repository
{
    public class OrderRepository
    {
        private readonly SalesContext _context;

        public OrderRepository(SalesContext context)
        {
            _context = context;
        }

        public Order Register(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();

            return order;
        }

        public Order GetById(int id)
        {
            var order = _context.Orders.Include(x => x.Seller)
                                       .Include(x => x.Customer)
                                       .FirstOrDefault(x => x.Id == id);
            return order;
        }

        public void DeleteOrder(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public Order UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();

            return order;
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders.OrderBy(x => x.Date).ToList();
        }
    }
}