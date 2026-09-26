using lab05Validation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab05Validation.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> _products = new List<Product>()
        {
            new Product { Id = "1", Description ="Test" , Image ="Ảnh 1" , Name ="Laptop"  , Price =100000, SalePrice = 10000, CategoryId = 2 }
        };
        // thêm dữ liệu cho category
        private static List<Category> _categories = new List<Category>()
        {
            new Category { Id = 1, Name = "Điện thoại" },
            new Category { Id = 2, Name = "Laptop" },
            new Category { Id = 3, Name = "Phụ kiện" },
            new Category { Id = 4, Name = "Đồng hồ thông minh" }
        };
        public IActionResult Index()
        {
            // hiển thị tên category
            foreach(var item in _products)
            {
                item.category = _categories.FirstOrDefault(p => p.Id == item.CategoryId);
            }
            return View(_products);
        }
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            string message = null;
            bool isValid = true;

            // SalePrice không âm
            if (product.SalePrice < 0)
            {
                message = "Giá khuyến mãi không được âm.";
                isValid = false;
            }

            // SalePrice phải nhỏ hơn hoặc bằng 90% giá chuẩn
            else if (product.SalePrice > product.Price * 0.9f)
            {
                message = $"Giá khuyến mãi ({product.SalePrice:N0}) phải nhỏ hơn hoặc bằng 90% giá chuẩn (tối đa {product.Price * 0.9f:N0}).";
                isValid = false;
            }

            if (ModelState.IsValid && isValid)
            {
                product.Id = Guid.NewGuid().ToString();
                _products.Add(product);
                return RedirectToAction("Index");
            }
            if (string.IsNullOrEmpty(message) && !ModelState.IsValid)
            {
                message = "Vui lòng kiểm tra và nhập đầy đủ các thông tin bên dưới.";
            }
            //Gán thông báo lỗi ra View
            ViewBag.message = "<div class='alert alert-danger'>" + message + "</div>";
            ViewBag.Categories = new SelectList(_categories, "Id", "Name");
            return View(product);
        }
    }
}
