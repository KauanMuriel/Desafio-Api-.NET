using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description{ get; set; }

       public Service(string name, string description) {
        Name = name;
        Description = description;
       } 
    }
}