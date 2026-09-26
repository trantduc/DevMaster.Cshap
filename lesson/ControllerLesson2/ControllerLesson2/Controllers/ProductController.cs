
using ControllerLesson2.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControllerLesson2.Controllers
{
    [Route("/SanPham")]
    public class ProductController : Controller
    {
        //action method
        public IActionResult Index()
        {
            ViewBag.messageVB = "ViewBag: Hello, this is a message from the ProductController Index action method.";
            // chuyển tab sẽ mất dữ liệu,
            ViewData["messageVD"] = "ViewData: Hello, this is a message from the ProductController Index action method.";

            TempData["messageTD"] = "TempData: Hello, this is a message from the ProductController Index action method.";
            return View();
        }
        [Route("ChiTietSP")]
        public IActionResult GetProduct()
        {
            // cách truyền qua model
            Product p = new Product()
            {

                Id = 1,
                ProductName = "Product 1",
                YearRelease = 2020,
                Price = 100.0f 

            };
            ViewBag.productVB = p;
            ViewData["productVD"] = p;
            TempData["productTD"] = p;
            return View(p);
        }
        [Route("DanhSachSP")]
        // tạo 1 action mới
        public IActionResult GetAllProduct()
        {
            List<Product> productList = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    ProductName = "Product 1",
                    YearRelease = 2020,
                    Price = 100.0f
                }
                ,
                new Product()
                {
                    Id = 2,
                    ProductName = "Product 2",
                    YearRelease = 2026,
                    Price = 100.0f
                },
                new Product()
                {

                    Id = 3,
                    ProductName = "Product 3",
                    YearRelease = 2026,
                    Price = 100.0f
                }
            };
            ViewBag.productListVB = productList;
            return View();
        }
    }
}
