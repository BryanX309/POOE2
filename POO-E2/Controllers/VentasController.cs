using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using POO_E2.Dtos;
using POO_E2.Entities;

namespace POO_E2.Controllers
{
    [ApiController]
    [Route("api/ventas")]
    public class VentasController : ControllerBase
    {
        [HttpPost]
        public ActionResult<ResponseDto<List<VentasEntity>>> Post([FromBody] List<VentasEntity> v)
        {
            Console.Clear();
            Console.WriteLine("{1,-15} {0,2} {2,-15} {0,2} {3,-15} {0,2} {4,-15} {0,2} {5,-15} {0,2} {6,-15}","|", "VENDEDOR", "TOTAL VENTA", "PROMEDIO", "V. MAS ALTA", "V. MAS BAJA", "META DUPERADA");
            Console.WriteLine("===================================================================================================================");

            foreach (var vendedor in v)
            {
                double total = 0;
                double prom;
                double ventaMasAlta = 0;
                double ventaMasBaja = -1;
                int diasDeVentaSuperada = 0;
                var ventas = vendedor.Ventas;

                foreach(var venta in ventas)
                {
                    if(ventas == null) continue;
                    total += venta;
                    ventaMasAlta = ventaMasAlta < venta ? venta : ventaMasAlta;
                    ventaMasBaja = (ventaMasBaja > venta || ventaMasBaja == -1) ? venta : ventaMasBaja;

                    if (venta > 3000) diasDeVentaSuperada++;
                }

                /*int i = 0;
                while (i < ventas.Count || i < 30)
                {
                    total += ventas[i];
                    ventaMasAlta = ventaMasAlta < ventas[i] ? ventas[i] : ventaMasAlta;
                    ventaMasBaja = ventaMasBaja > ventas[i] ? ventas[i] : ventaMasBaja;

                    if (ventas[i] > 3000) diasDeVentaSuperada++;
                    i++;
                }*/

                prom = total / ventas.Count;

                Console.WriteLine("{1,-15} {0,2} {2,-15} {0,2} {3,-15} {0,2} {4,-15} {0,2} {5,-15} {0,2} {6,-15}","|", $"{vendedor.Vendedor}", $"L. {(decimal)total:F2}", $"L. {(decimal)prom:F2}", $"L. {(decimal)ventaMasAlta:F2}", $"L. {(decimal)ventaMasBaja:F2}", diasDeVentaSuperada);
            }

            return Ok(new ResponseDto<List<VentasEntity>>
            {
                StatusCode = 400,
                Status = true,
                Message = "Ventas Ingresadas",
                Data = v
            });
        }

        [HttpGet]

        public ActionResult<ResponseDto<List<VentasEntity>>> GETALL()
        {
            List<VentasEntity> ventas = new List<VentasEntity>();

            for (int i = 1; i <= 3; i++)
            {
                List<double> vs = new List<double>();

                for (int v = 1; v < 4; v++)
                {
                    vs.Add((double)(v*i*10));
                }

                ventas.Add(new VentasEntity
                {
                    Vendedor = $"Vendedor #{i}",
                    Ventas = vs
                    
                });
            }

            return Ok(new ResponseDto<List<VentasEntity>>
            {
                StatusCode = 400,
                Status = true,
                Message = "Ventas Generadas",
                Data = ventas
            });
        }
    }
}