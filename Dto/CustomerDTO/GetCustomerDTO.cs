using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Models;

namespace SistemaVendas.Dto.CustomerDTO
{
    public class GetCustomerDTO
    {
        public int Id { get; set;}
        public string Name { get; set;}
        public string Login { get; set;}

        public GetCustomerDTO(Customer customer)
        {

            Id = customer.Id;
            Name = customer.Name;
            Login = customer.Login;
        }
    }
}