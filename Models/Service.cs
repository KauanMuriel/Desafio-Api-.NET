using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Dto.ServiceDTO;

namespace SistemaVendas.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description{ get; set; }

        public Service()
        {
        }

        public Service(RegisterServiceDTO dto)
        {
            Name = dto.Name;
            Description = dto.Description;
        }

        public void MapUpdateService(UpdateServiceDTO dto)
        {
            Name = dto.Name;
            Description = dto.Description;
        }

       public Service(string name, string description) 
       {
        Name = name;
        Description = description;
       } 
    }
}