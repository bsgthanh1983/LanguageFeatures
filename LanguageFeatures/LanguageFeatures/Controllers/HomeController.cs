using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            /* //===========================================
               //= Before 4.4 - Using String Interpolation =
               //===========================================       
            
            List<string> results = new List<string>();
            foreach (Product p in Product.GetProducts())
            {
                string name = p?.Name?? "<No Name>";
                decimal? price = p?.Price?? 0;
                string relatedName = p?.Related?.Name?? "<None>";
                string category = p?.Category ?? "<Not decided yet>";
                string a = "Not have information yet";
                switch (p?.Instock)
                {
                    case null:
                        a = "No Information";
                        break;
                    case true:
                        a = "In stock";
                        break;
                    case false:
                        a = "Out of stock";
                        break;
                }             
                results.Add(string.Format("Name : {0}, Price : {1}, Related : {2}, Category : {3}, Stocking State : {4}", name, price, relatedName, category,a));          
            }
            **/

            /* //====================================
               //= 4.4 - Using String Interpolation =
               //====================================
            
            List<string> results = new List<string>();
            foreach (Product p in Product.GetProducts())
            {
                string name = p?.Name?? "<No Name>";
                decimal? price = p?.Price?? 0;
                string relatedName = p?.Related?.Name?? "<None>";
                string category = p?.Category ?? "<Not decided yet>";
                string a = "Not have information yet";
                switch (p?.Instock)
                {
                    case null:
                        a = "No Information";
                        break;
                    case true:
                        a = "In stock";
                        break;
                    case false:
                        a = "Out of stock";
                        break;
                }
                results.Add($"Name : {name}---Price : {price}---Related : {relatedName}---Category : {category}---Stocking States : {a}");
            }
            **/

            /* //=================================================
               //= 4.5 - Using Object and Collection Initializer =
               //=================================================

            return View(new string[] { "Bob","Joe","Alice"});
            **/


            /* //====================================
               //=4.5.1 - Using an Index Initializer=
               //====================================

            //traditional C# approach to initializing a dictionary
            Dictionary<string, Product> products = new Dictionary<string, Product>
            {
                {"Lifejacket", new Product{Name="Lifejacket", Price=48.95M}},
                { "Kayak", new Product{Name ="Kayak", Price =275M}}
            };
            return View(products.Keys);
            
            
            //The last version of C# (7.0) approach to initializing a dictionary
            Dictionary<string, Product> products = new Dictionary<string, Product>
            {
                ["Kayak"] = new Product { Name="Kayak", Price=275M},
                ["Lifejacket"] = new Product { Name="Lifejacket", Price=48.95M}
            };
            return View(products.Keys);
            **/

            /* //========================
               //=4.6 - Pattern matching=
               //========================

            object[] data = new object[] {275M,29.95M,"apple","orange",100,10 };
            decimal total = 0;
            for (int i=0; i< data.Length; i++)
            {
                if (data[i] is int d)
                {
                    total += d;
                }
            }

            return View(new string[] { $"Total : {total:c2}" });
            **/

            //==============================================
            //=4.6.1 - Pattern matching in Switch statement=
            //==============================================

            object[] data = new object[] {275M,29.95M,"apple","orange",100,10 };
            decimal totalDecimal = 0;
            int totalInt = 0;
            for (int i = 0; i < data.Length; i++)
            {
                switch (data[i])
                {
                    case decimal decimalValue:
                        totalDecimal += decimalValue;
                        break;
                    case int intValue when intValue > 50 :
                        totalInt += intValue;
                        break;
                }
            }
            return View(new string[] { $"Total Decimal : {totalDecimal:c2}, Total int : {totalInt}" });
            
        }
    }
}
