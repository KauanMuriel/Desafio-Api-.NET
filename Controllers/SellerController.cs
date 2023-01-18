using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Dto.SellerDTO;
using SistemaVendas.Models;
using SistemaVendas.Repository;

namespace SistemaVendas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SellerController : ControllerBase
    {
        private readonly SellerRepository _repository;

        public SellerController(SellerRepository repository) 
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Register(RegisterSellerDTO dto)
        {
            var seller = new Seller(dto);
            _repository.Register(seller);
            return Ok(seller); 
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var seller = _repository.GetById(id);

            if (seller is not null) 
            {
                var sellerDTO = new GetSellerDTO(seller);
                return Ok(sellerDTO);
            }
            else 
                return NotFound(new { Mensagem = "Seller not found" });
        }

        [HttpGet("GetByName/{name}")]
        public IActionResult GetByName(string name)
        {
            var sellers = _repository.GetByName(name);
            return Ok(sellers);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateSellerDTO dto)
        {
            var seller = _repository.GetById(id);
            
            if (seller is not null) 
            {
                seller.MapUpdateSeller(dto);
                _repository.UpdateSeller(seller);
                return Ok(seller);
            } else 
                return NotFound(new { Mensagem = "Seller not found"});
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var seller = _repository.GetById(id);
            
            if (seller is not null) 
            {
                _repository.DeleteSeller(seller);
                return NoContent();
            }
            else
                return NotFound(new { Mensagem = "Seller not found"});
        }

        [HttpPatch("{id}")]
        public IActionResult UpdatePassword(int id, UpdatePasswordSellerDTO dto)
        {
            var seller = _repository.GetById(id);

            if (seller is not null)
            {
                _repository.UpdatePassword(seller, dto);
                return Ok(seller);
            }
            else
            {
                return NotFound(new { Mensagem = "Seller not found"});
            }
        }

        [HttpGet("GetAllSellers")]
        public IActionResult GetAllSellers() 
        {
            var sellers = _repository.GetAllSellers();

            if(sellers is not null)
            {
                return Ok(sellers);
            }
            else
            {
                return NotFound(new { Mensagem = "There isn't sellers registered"});
            }
        }
    }
}