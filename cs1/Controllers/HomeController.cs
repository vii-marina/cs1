using System.Diagnostics;
using System.Globalization;
using cs1.Models;
using Microsoft.AspNetCore.Mvc;

namespace cs1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SprintTasks()
        {
            return View();
        }

        public IActionResult Greetings()
        {
            // Prepare view data for greetings
            var now = DateTime.Now;
            ViewData["Now"] = now;
            ViewData["UserName"] = "Guest";
            ViewData["IsMorning"] = now.Hour < 12;
            return View();
        }

        public IActionResult ProductInfo()
        {
            return View();
        }

        public IActionResult SuperMarkets()
        {
            // supply list via ViewBag
            var markets = new[] { "FreshMart", "DailyFoods", "CornerStore", "SuperValue" };
            ViewBag.SuperMarkets = markets;
            return View();
        }

        public IActionResult ShoppingList()
        {
            // dictionary of product -> quantity
            var dict = new Dictionary<string, int>
            {
                ["Apples"] = 4,
                ["Bread"] = 2,
                ["Milk"] = 1,
                ["Eggs"] = 12
            };
            return View(dict);
        }

        [HttpGet]
        public IActionResult ShoppingCart()
        {
            var markets = new[] { "FreshMart", "DailyFoods", "CornerStore", "SuperValue" };
            ViewBag.SuperMarkets = markets;

            // items for listbox - reuse shopping list keys
            var items = new[] { "Apples", "Bread", "Milk", "Eggs" };
            ViewBag.Items = items;

            // shipping date options (today + next 2 days)
            var dates = new[] { DateTime.Today, DateTime.Today.AddDays(1), DateTime.Today.AddDays(2) };
            ViewBag.ShippingDates = dates;

            return View();
        }

        [HttpPost]
        public IActionResult ShoppingCart(string customerName, string supermarket, DateTime shippingDate, string[] selectedItems)
        {
            var markets = new[] { "FreshMart", "DailyFoods", "CornerStore", "SuperValue" };
            ViewBag.SuperMarkets = markets;
            ViewBag.Items = new[] { "Apples", "Bread", "Milk", "Eggs" };
            ViewBag.ShippingDates = new[] { DateTime.Today, DateTime.Today.AddDays(1), DateTime.Today.AddDays(2) };

            ViewBag.Message = "Your order has been submitted.";
            ViewBag.CustomerName = customerName;
            ViewBag.SelectedItems = selectedItems ?? Array.Empty<string>();
            ViewBag.Supermarket = supermarket;
            ViewBag.ShippingDate = shippingDate.ToString("d", CultureInfo.InvariantCulture);

            return View();
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
