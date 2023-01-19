using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Context;
using SistemaVendas.Dto.SellerDTO;
using SistemaVendas.Models;

namespace SistemaVendas.Repository
{

    public class SellerRepository
    {
        private readonly SalesContext _context;
        
        public SellerRepository(SalesContext context)
        {
            _context = context;
        }
    
        public void Register(Seller seller)
        {
            _context.Sellers.Add(seller);
            _context.SaveChanges();
        }

        public Seller GetById(int id) 
        {
            var seller = _context.Sellers.Find(id);
            return seller;
        }

        public List<GetSellerDTO> GetByName(string name) 
        {
            var sellers = _context.Sellers.Where(x => x.Name.Contains(name))
                                          .Select(x => new GetSellerDTO(x))
                                          .ToList();
            
            return sellers;
        }

        public Seller UpdateSeller(Seller seller) 
        {
            _context.Sellers.Update(seller);
            _context.SaveChanges();

            return seller;
        }

        public void DeleteSeller(Seller seller)
        {
            _context.Sellers.Remove(seller);
            _context.SaveChanges();
        }

        public void UpdatePassword(Seller seller, UpdatePasswordSellerDTO dto) 
        {
            seller.Password = dto.Password;
            UpdateSeller(seller);
        }

        public List<Seller> GetAllSellers() 
        {
            return _context.Sellers.OrderBy(x => x.Id).ToList();
        }

        public Seller FindByLogin(Seller seller)
        {
            var sellerFound = _context.Sellers.SingleOrDefault(x => x.Login == seller.Login && x.Password == seller.Password);
            return sellerFound;
        }
    }
    
}