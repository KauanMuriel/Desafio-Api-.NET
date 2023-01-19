using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Context;
using SistemaVendas.Dto;
using SistemaVendas.Dto.CustomerDTO;
using SistemaVendas.Models;
using SistemaVendas.Repository;

namespace SistemaVendas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerRepository _repository;

        public CustomerController(CustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Register(RegisterCustomerDTO dto)
        {
            var customer = new Customer(dto);
            _repository.Register(customer);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _repository.GetById(id);

            if(customer is not null)
            {
                return Ok(customer);
            }
            return NotFound(new { Message = "Customer not found"});
        }
        
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateCustomerDTO dto)
        {
            var customer = _repository.GetById(id);

            if(customer is not null)
            {
                customer.MapUpdateCustomer(dto);
                _repository.UpdateCustomer(customer);
                return Ok(customer);
            }
            else
            {
                return NotFound(new { Message = "Customer not found"});
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = _repository.GetById(id);

            if(customer is not null)
            {
                _repository.DeleteSeller(customer);
                return NoContent();
            }
            else
            {
                return NotFound(new { Message = "Customer not found"});
            }
        }

        [HttpGet("GetAllCustomers")]
        public IActionResult GetAllCustomers()
        {
            var customers = _repository.GetAllCustomers();

            if(customers is not null)
            {
                return Ok(customers);
            }
            else
            {
                return NotFound(new { Mensagem = "There isn't customers registered"});
            }
        }
    }
}