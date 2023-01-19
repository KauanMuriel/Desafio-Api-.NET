using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Dto.ServiceDTO;
using SistemaVendas.Models;
using SistemaVendas.Repository;

namespace SistemaVendas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly ServiceRepository _repository;

        public ServiceController(ServiceRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Register(RegisterServiceDTO dto)
        {
            var service = new Service(dto);
            _repository.Register(service);
            return Ok(service);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var service = _repository.GetById(id);

            if(service is not null)
            {
                var serviceDTO = new GetServiceDTO(service);
                return Ok(serviceDTO);
            }
            else
            {
                return NotFound(new { Message = "Service not found"});
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var service = _repository.GetById(id);

            if (service is not null)
            {
                _repository.DeleteService(service);
                return NoContent();
            }
            else
            {
                return NotFound(new { Message = "Service not found"});
            }
        }

        [HttpGet("GetAllServices")]
        public IActionResult GetAllServices()
        {
            var services = _repository.GetAllServices();

            if(services is not null)
            {
                return Ok(services);
            }
            else
            {
                return NotFound(new { Message = "There aren't services registered"});
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateService(int id, UpdateServiceDTO dto)
        {
            var service = _repository.GetById(id);

            if (service is not null)
            {
                service.MapUpdateService(dto);
                _repository.UpdateService(service);
                return Ok(service);
            }
            else
            {
                return NotFound(new { Message = "Service not found"});
            }
        }
    }
}