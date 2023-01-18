using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Dto.OrderDTO;
using SistemaVendas.Models;
using SistemaVendas.Repository;

namespace SistemaVendas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderRepository _repository;

        public OrderController(OrderRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Register(RegisterOrderDTO dto)
        {
            var order = new Order(dto);
            _repository.Register(order);
            return Ok(order);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var order = _repository.GetById(id);

            if(order is not null) 
            {
                return Ok(order);
            }
            else
            {
                return NotFound( new { Mensagem = "Order not found"});
            }
        }
    }
}