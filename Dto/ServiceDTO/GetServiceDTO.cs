using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Models;

namespace SistemaVendas.Dto.ServiceDTO
{
    public class GetServiceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description{ get; set; }

        public GetServiceDTO(Service service)
        {
            Id = service.Id;
            Name = service.Name;
            Description = service.Description;
        }
    }
}