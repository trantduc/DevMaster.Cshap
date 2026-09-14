using Microsoft.AspNetCore.Mvc;
using Lesson3View.Models;
using System.Diagnostics;

namespace Lesson3View.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Product> products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Tivi Nagakawa NAG0102",
                    ImageUrl = "/images/product.jpg",
                    Price = 2590000
                },
                new Product
                {
                    Id = 2,
                    Name = "Tivi samsung NAG0102",
                    ImageUrl = "/images/product.jpg",
                    Price = 2590000
                },
                new Product
                {
                    Id = 3,
                    Name = "Tivi samsung DNA0102",
                    ImageUrl = "/images/product.jpg",
                    Price = 2590000
                }
            };

            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(
            Duration = 0,
            Location = ResponseCacheLocation.None,
            NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id
                    ?? HttpContext.TraceIdentifier
            });
        }
    }
}