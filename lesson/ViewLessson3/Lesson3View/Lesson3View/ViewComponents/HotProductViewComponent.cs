using Microsoft.AspNetCore.Mvc;
using Lesson3View.Models;

namespace Lesson3View.ViewComponents
{
    public class HotProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<Product> products = new List<Product>
            {
                new Product
                {
                    Id = 4,
                    Name = "Tivi Hot NAG0102",
                    ImageUrl = "/images/product.jpg",
                    Price = 2590000
                },
                new Product
                {
                    Id = 5,
                    Name = "Tivi Hot akimi NAG0102",
                    ImageUrl = "/images/product.jpg",
                    Price = 2590000
                },
                new Product
                {
                    Id = 6,
                    Name = "Tivi HOt T9_Nagakawa NAG0102",
                    ImageUrl = "/images/product.jpg",
                    Price = 2590000
                }
            };

            return View(products);
        }
    }
}