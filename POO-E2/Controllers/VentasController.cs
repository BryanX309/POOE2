using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using POO_E2.Entities;

namespace POO_E2.Controllers
{
    [ApiController]
    [Route("api/ventas")]
    public class VentasController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] List<VentasEntity> v)
        {
            Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10} {4,-10} {5,-10}", "VENDEDOR", "TOTAL VENTA", "PROMEDIO", "V. MAS ALTA", "V. MAS BAJA", "META DUPERADA");

            foreach (var vendedor in v)
            {
                double total = 0;
                double prom;
                double ventaMasAlta = 0;
                double ventaMasBaja = 0;
                int diasDeVentaSuperada = 0;
                var ventas = vendedor.Ventas;

                int i = 0;
                while (i < ventas.Count || i < 30)
                {
                    total += ventas[i];
                    ventaMasAlta = ventaMasAlta < ventas[i] ? ventas[i] : ventaMasAlta;
                    ventaMasBaja = ventaMasBaja > ventas[i] ? ventas[i] : ventaMasBaja;

                    if (ventas[i] > 3000) diasDeVentaSuperada++;
                    i++;
                }

                prom = total / ventas.Count;

                Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10} {4,-10} {5,-10}", vendedor.Vendedor, $"L. {(decimal)total:F2}", $"L. {(decimal)prom:F2}", $"L. {(decimal)ventaMasAlta:F2}", $"L. {(decimal)ventaMasBaja:F2}", diasDeVentaSuperada);
            }

            return Ok("Tabla desplegada");
        }
    }
}