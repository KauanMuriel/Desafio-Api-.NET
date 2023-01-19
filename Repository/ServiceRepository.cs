using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Context;
using SistemaVendas.Dto.ServiceDTO;
using SistemaVendas.Models;

namespace SistemaVendas.Repository
{
    public class ServiceRepository
    {
        private readonly SalesContext _context;
        
        public ServiceRepository(SalesContext context)
        {
            _context = context;
        }

        public void Register(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
        }

        public Service GetById(int id)
        {
            var service = _context.Services.Find(id);
            return service;   
        }

        public void DeleteService(Service service)
        {
            _context.Services.Remove(service);
            _context.SaveChanges();
        }

        public List<Service> GetAllServices()
        {
            return _context.Services.OrderBy(x => x.Name).ToList();
        }

        public Service UpdateService(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();

            return service;
        }
    }
}