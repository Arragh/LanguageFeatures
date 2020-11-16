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
        bool FilterByPrice(Product prod)
        {
            return (prod?.Price ?? 0) >= 0;
        }

        public async Task<IActionResult> Index3()
        {
            long? length = await MyAsyncMethods.GetPageLength();
            return View("Index", new string[] { $"Length: {length}" });
        }

        public IActionResult index2() => View("Index", Product.GetProducts().Select(p => p?.NameBeginsWithS.ToString()));

        public IActionResult Index()
        {
            // ---------------------------------------------- Получение имён ---------------------------------------------------

            var products = new[]
            {
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "LifeJacket", Price = 48.95M },
                new Product { Name = "Soccer Ball", Price = 19.50M },
                new Product { Name = "Corner Flag", Price = 34.95M }
            };
            return View(products.Select(p => $"{nameof(p.Name)}: {p.Name}, {nameof(p.Price)}: {p.Price:C2}"));


            // ------------------------------------------- Асинхронные методы 1 ------------------------------------------------

            //return Content($"{MyAsyncMethods.GetPageLength().Result}");


            //---------------------------------------------- Лямбда-выражения 3 ------------------------------------------------

            //return View(Product.GetProducts().Select(p => p?.Name));


            //---------------------------------------------- Лямбда-выражения 2 ------------------------------------------------

            //Product[] productArray =
            //{
            //    new Product { Name = "Kayak", Price = 275M },
            //    new Product { Name = "LifeJacket", Price = 48.95M },
            //    new Product { Name = "Soccer Ball", Price = 19.50M },
            //    new Product { Name = "Corner Flag", Price = 34.95M }
            //};
            //Func<Product, bool> nameFilter = delegate (Product prod)
            //{
            //    return prod?.Name?[0] == 'S';
            //};
            ////decimal priceFilterTotal = productArray.Filter(FilterByPrice).TotalPrices();
            ////decimal nameFilterTotal = productArray.Filter(nameFilter).TotalPrices();
            //decimal priceFilterTotal = productArray.Filter(p => (p?.Price ?? 0) >= 20).TotalPrices();
            //decimal nameFilterTotal = productArray.Filter(p => p?.Name?[0] == 'S').TotalPrices();
            //return View(new string[]
            //{
            //    $"Price Total: {priceFilterTotal:C2}",
            //    $"Name Total: {nameFilterTotal:C2}"
            //});


            //----------------------------------------------- Лямбда-выражения -------------------------------------------------

            //Product[] productArray =
            //{
            //    new Product { Name = "Kayak", Price = 275M },
            //    new Product { Name = "LifeJacket", Price = 48.95M },
            //    new Product { Name = "Soccer Ball", Price = 19.50M },
            //    new Product { Name = "Corner Flag", Price = 34.95M }
            //};
            //decimal priceFilterTotal = productArray.FilterByPrice(20).TotalPrices();
            //decimal nameFilterTotal = productArray.FilterByName('S').TotalPrices();
            //return View(new string[]
            //{
            //    $"Price Total: {priceFilterTotal:C2}",
            //    $"Name Total: {nameFilterTotal:C2}"
            //});


            //------------------------------------------- Фильтрующие расширения 2 ----------------------------------------------

            //Product[] productArray =
            //{
            //    new Product { Name = "Kayak", Price = 275M },
            //    new Product { Name = "LifeJacket", Price = 48.95M },
            //    new Product { Name = "Soccer Ball", Price = 19.50M },
            //    new Product { Name = "Corner Flag", Price = 34.95M }
            //};
            //decimal arrayTotal = productArray.FilterByPrice(20).TotalPrices();
            //return View(new string[] { $"Array Total: {arrayTotal:C2}" });


            //---------------------------------------------- Методы расширения 2 -------------------------------------------------

            //ShoppingCart cart = new ShoppingCart()
            //{
            //    Products = Product.GetProducts()
            //};
            //Product[] productArray =
            //{
            //    new Product { Name = "Kayak", Price = 275M },
            //    new Product { Name = "LifeJacket", Price = 48.95M }
            //};
            //decimal cartTotal = cart.TotalPrices();
            //decimal arrayTotal = productArray.TotalPrices();
            //return View(new string[] { $"Cart Total: {cartTotal:C2}", $"Array Total: {arrayTotal:C2}" });


            //---------------------------------------------- Методы расширения 1 -------------------------------------------------

            //ShoppingCart cart = new ShoppingCart()
            //{
            //    Products = Product.GetProducts()
            //};
            //decimal cartTotal = cart.TotalPrices();
            //return View(new string[] { $"Total: {cartTotal:C2}" });


            //------------------------------- Сопоставление с образцом в операторе SWITCH-CASE -----------------------------------

            //object[] data = new object[] { 275M, 29.95M, "apple", "orange", 100, 10 };
            //decimal total = 0;
            //for (int i = 0; i < data.Length; i++)
            //{
            //    switch (data[i])
            //    {
            //        case decimal decimalValue: // Если значение data[i] decimal, то прибавляем data[i] к total
            //            total += decimalValue;
            //            break;
            //        case int intValue when intValue > 50: // Если значение data[i] int и больше 50, то прибавляем data[i] к total
            //            total += intValue;
            //            break;
            //    }
            //}
            //return View(new string[] { $"Total: {total:C2}" });



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
