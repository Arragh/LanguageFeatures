using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; } = "Watersports";
        public decimal? Price { get; set; }
        public Product Related { get; set; }
        public bool InStock { get; }
        public bool NameBeginsWithS => Name?[0] == 'S';

        public Product(bool instock = false) // Значение InStock по умолчанию
        {
            InStock = instock;
        }

        public static Product[] GetProducts()
        {
            Product kayak = new Product(true) // Задает значение InStock
            {
                Name = "Kayak",
                Category = "Water Craft",
                Price = 275M
            };

            Product lifeJacket = new Product()
            {
                Name = "LifeJacket",
                Price = 48.95M
            };

            kayak.Related = lifeJacket;

            return new Product[] { kayak, lifeJacket, null };
        }
    }
}
