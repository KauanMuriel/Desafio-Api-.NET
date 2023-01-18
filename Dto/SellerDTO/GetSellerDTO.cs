using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Models;

namespace SistemaVendas.Dto.SellerDTO
{
    public class GetSellerDTO
    {
        public int Id { get; set;}
        public string Name { get; set;}
        public string Login { get; set;}

        public GetSellerDTO(Seller seller)
        {
            Id = seller.Id;
            Name = seller.Name;
            Login = seller.Login;
        }
    }
}