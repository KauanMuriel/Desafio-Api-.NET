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

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = _repository.GetById(id);

            if(order is not null)
            {
                _repository.DeleteOrder(order);
                return NoContent();
            }
            else
            {
                return NotFound( new { Mensagem = "Order not found"});
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateOrderDTO dto)
        {
            var order = _repository.GetById(id);

            if (order is not null)
            {
                order.MapUpdateOrder(dto);
                _repository.UpdateOrder(order);
                return Ok(order);
            }
            else
            {
                return NotFound(new { Mensagem = "Order not found"});
            }
        }

        [HttpGet("GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            var orders = _repository.GetAllOrders();

            if (orders is not null)
            {
                return Ok(orders);
            }
            else
            {
                return NotFound(new { Mensagem = "There aren't sellers registered"});
            }
        }
    }
}