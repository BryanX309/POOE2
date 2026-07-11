using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POO_E2.Entities
{
    public class InventoryEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double PurchasePrice { get; set; }
        public double SellingPrice { get; set; }
        public int Inventory { get; set; }
        public double Utility { get; set; }
        public double Margin { get; set; }
        public double InventoryValue { get; set; }



        //nombre, precio de compra, precio de venta y cantidad en inventario.
        //name, purchase price, selling price and quantity in inventory.
    }
}