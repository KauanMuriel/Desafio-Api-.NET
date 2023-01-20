using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Context;
using SistemaVendas.Models;

namespace SistemaVendas.Repository
{
    public class CustomerRepository
    {
        private readonly SalesContext _context;

        public CustomerRepository (SalesContext context)
        {
            _context = context;
        }

        public void Register(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public Customer GetById(int id)
        {
            var customer = _context.Customers.Find(id);
            return customer;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();

            return customer;
        }

        public void DeleteSeller(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public List<Customer> GetAllCustomers()
        {
            var customers = _context.Customers.OrderBy(x => x.Name).ToList();
            return customers;
        }

        public Customer FindByLogin(Customer customer)
        {
            var customerFound = _context.Customers.SingleOrDefault(x => x.Login == customer.Login && x.Password == customer.Password);
            return customerFound;
        }
    }
}