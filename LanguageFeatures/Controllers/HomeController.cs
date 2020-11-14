using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //------------------------------- Сопоставление с образцом в операторе SWITCH-CASE -----------------------------------

            object[] data = new object[] { 275M, 29.95M, "apple", "orange", 100, 10 };
            decimal total = 0;
            for (int i = 0; i < data.Length; i++)
            {
                switch (data[i])
                {
                    case decimal decimalValue: // Если значение data[i] decimal, то прибавляем data[i] к total
                        total += decimalValue;
                        break;
                    case int intValue when intValue > 50: // Если значение data[i] int и больше 50, то прибавляем data[i] к total
                        total += intValue;
                        break;
                }
            }
            return View(new string[] { $"Total: {total:C2}" });



            //------------------------------------------ Сопоставление с образцом---------------------------------------------------

            //object[] data = new object[] { 275M, 29.95M, "apple", "orange", 100, 10 };
            //decimal total = 0;
            //for (int i = 0; i < data.Length; i++)
            //{
            //    if (data[i] is decimal d) // Если значение data[i] decimal, то прибавляем data[i] к total
            //    {
            //        total += d;
            //    }
            //}
            //return View(new string[] { $"Total: {total:C2}" });



            //----------------------------------- Инициализатор индексированной коллекции -------------------------------------------

            //Dictionary<string, Product> products = new Dictionary<string, Product>()
            //{
            //    ["Kayak_Key"] = new Product() { Name = "Kayak", Price = 275M },
            //    ["LifeJacket_Key"] = new Product() { Name = "LifeJacket", Price = 48.95M }
            //};
            //return View(products.Keys);



            //----------------------------------- NULL-условные операции и объединение с NULL----------------------------------------

            //List<string> results = new List<string>();
            //foreach (var prod in Product.GetProducts())
            //{
            //    string name = prod?.Name ?? "<No Name>";
            //    string category = prod?.Category ?? "<No Category>";
            //    decimal? price = prod?.Price ?? 0;
            //    string relatedName = prod?.Related?.Name ?? "<None>";
            //    bool? instock = prod?.InStock;
            //    results.Add($"Name: {name}, Category: {category}, Price: {price}, Related: {relatedName}, In Stock: {instock}");
            //}
            //return View(results);



            //-----------------------------------------------------------------------------------------------------------------------

            //return View(new string[] { "C#", "Language", "Features" });
        }
    }
}
