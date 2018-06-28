using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public Product Related {get;set;}
        public string Category { get; set; } = "Watersports";
        public bool Instock { get; } = true;

        public Product(bool stock = true)
        {
            Instock = stock;
        }

        public static Product[] GetProducts()
        {
            Product kayak = new Product
            {
                Name = "Kayak",
                Price = 275M,
                Category = "Water Craft"
               
            };
            Product lifejacket = new Product(false)
            {
                Name = "LifeJacket",
                Price = 48.95M,
                Related = kayak
            };

            kayak.Related = lifejacket;
            

            return new Product[] { kayak, lifejacket, null };
        }
    }
}
