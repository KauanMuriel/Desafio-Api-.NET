using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Dto;

namespace SistemaVendas.Models
{
    public class Customer
    {
        public int Id { get; set;}
        public string Name { get; set;}
        public string Login { get; set;}
        public string Password { get; set; }

        public Customer()
        {
        }

        public Customer(RegisterCustomerDTO dto)
        {
            Name = dto.Name;
            Login = dto.Login;
            Password = dto.Password;
        }

        public void MapUpdateCustomer(UpdateCustomerDTO dto)
        {
            Name = dto.Name;
            Login = dto.Login;
            Password = dto.Password;
        }
    }
}