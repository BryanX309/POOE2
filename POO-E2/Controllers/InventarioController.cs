using Microsoft.AspNetCore.Mvc;
using POO_E2.Entities;

namespace POO_E2.Controllers
{
    [ApiController]
    [Route("api/inventario/analizar")]

    public class InventarioController:ControllerBase
    {
        private readonly List<InventoryEntity> _inventory;

        public InventarioController()
        {
            _inventory = new List<InventoryEntity>();

            _inventory.Add(new InventoryEntity{Id = 1, Name = "Botas 1", PurchasePrice = 40, SellingPrice = 60, Inventory = 5});
            _inventory.Add(new InventoryEntity{Id = 2, Name = "Botas 2", PurchasePrice = 50, SellingPrice = 70, Inventory = 6});
            _inventory.Add(new InventoryEntity{Id = 3, Name = "Botas 3", PurchasePrice = 60, SellingPrice = 80, Inventory = 7});
            _inventory.Add(new InventoryEntity{Id = 4, Name = "Botas 4", PurchasePrice = 70, SellingPrice = 90, Inventory = 8});
        }   
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_inventory);
        }

        [HttpPost]
        public IActionResult Post([FromBody] List<InventoryEntity> inventory)
        {
            double InventoryValue = 0;
            double HigherMargin = 0;
            string? HigherMarginTool = "";
            
            Console.WriteLine("\n{0,-10} {1,-10} {2,-10} {3,-10}","NOMBRE","UTILIDAD", "MARGEN", "VALOR INVENTARIO");
            Console.WriteLine("==========================================================");

            foreach(var product in inventory)
            {
                product.Utility = product.SellingPrice-product.PurchasePrice;
                product.Margin = (product.Utility / product.PurchasePrice) *100;
                product.InventoryValue = product.SellingPrice * product.Inventory;
                Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10}",product.Name, product.Utility,$"{(decimal)product.Margin:F2}%", $"L. {(decimal)product.InventoryValue:F2}");

                InventoryValue += product.InventoryValue;

                if(product.Margin > HigherMargin)
                {
                    HigherMargin = product.Margin;
                    HigherMarginTool = product.Name;
                }
            }
            
            return Ok($"Valor Inventario Completo de: L. {(decimal)InventoryValue:F2} \nLa Herramienta con mayor margen es: {HigherMarginTool} con un margen de {HigherMargin}%");
            //return Ok(inventory);
        }
    }
}