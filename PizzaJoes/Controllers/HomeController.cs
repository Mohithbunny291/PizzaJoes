using Microsoft.AspNetCore.Mvc;
using PizzaJoes.Models;
using System.Diagnostics;

namespace PizzaJoes.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Checkout(string pizzaType, string size, int quantity)
        {
            // Calculate total price - this is a simplified example
            var pricePerPizza = 10; // Assume each pizza costs $10 for simplicity
            var totalPrice = pricePerPizza * quantity;

            // Pass data to the view using ViewBag or a ViewModel
            ViewBag.PizzaType = pizzaType;
            ViewBag.Size = size;
            ViewBag.Quantity = quantity;
            ViewBag.TotalPrice = totalPrice;

            return View();
        }

        public IActionResult Confirmation(string pizzaType, string size, int quantity, string totalPrice)
        {
            // Here, you're assuming these parameters are passed correctly from the previous step
            ViewBag.PizzaType = pizzaType;
            ViewBag.Size = size;
            ViewBag.Quantity = quantity;
            ViewBag.TotalPrice = totalPrice; // Make sure this is calculated and passed from the checkout step

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
