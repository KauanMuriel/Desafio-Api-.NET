using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Dto.SellerDTO;

namespace SistemaVendas.Models
{
    public class Seller
    {
        public int Id { get; set;}
        public string Name { get; set;}
        public string Login { get; set;}
        public string Password { get; set; }

        public Seller()
        {

        }
        public Seller(RegisterSellerDTO dto) {
            Name = dto.Name;
            Login = dto.Login;
            Password = dto.Password;
        }

        public Seller(LoginSellerDTO dto)
        {
            Login = dto.Login;
            Password = dto.Password;
        }

        public void MapUpdateSeller(UpdateSellerDTO dto)
        {
            Name = dto.Name;
            Login = dto.Login;
            Password = dto.Password;
        }
    }
}