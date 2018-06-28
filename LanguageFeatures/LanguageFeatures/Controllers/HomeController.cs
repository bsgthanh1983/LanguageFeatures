using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
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

            return View(results);
            
        }
    }
}
