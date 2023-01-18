using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Models
{
    public class Adress
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public string Cep { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } // Propriedade acessora
    }
}