using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POO_E2.Entities
{
    public class VentasEntity
    {
        public string? Vendedor {get; set;}

        public List<double>? Ventas {get; set;}
    }
}