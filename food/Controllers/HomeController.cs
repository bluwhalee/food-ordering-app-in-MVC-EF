using food.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Diagnostics;
using System.Web;
using food.Controllers;
using System.Linq;

namespace food.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddToCart(Order o)
        {
            
            List<Order> orders = new List<Order>();
            
            if (HttpContext.Session.Get<List<Order>>("Orders") != null)
            {
                orders = HttpContext.Session.Get<List<Order>>("Orders");
                
            }
            if (HttpContext.Session.Get<List<Order>>("Orders") == null)
            {
                orders.Add(o);
                HttpContext.Session.Set<List<Order>>("Orders", orders);
            }
            else
            {
                bool f = true;
                foreach (Order o1 in orders)
                {
                    if (o1.Id == o.Id)
                    {
                        o1.Quantity = (Convert.ToInt32(o1.Quantity) + Convert.ToInt32(o.Quantity)).ToString();
                        f = false;
                    }
                }
                if (f)
                {
                    orders.Add(o);
                }
                HttpContext.Session.Set<List<Order>>("Orders", orders);
            }
            foreach (Order oo in orders)
            {
                Console.Write(oo.Title);
                Console.WriteLine(oo.Quantity);
            }

            return View("~/Views/Home/Index.cshtml");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}