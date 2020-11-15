using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        public static decimal TotalPrices(this IEnumerable<Product> products)
        {
            decimal total = 0;

            foreach (var prod in products)
            {
                total += prod?.Price ?? 0;
            }

            //test.ForEach(p => total += p?.Price ?? 0);

            return total;
        }
    }
}
