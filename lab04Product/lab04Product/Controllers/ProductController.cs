using lab04Product.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab04Product.Controllers
{
    public class ProductController : Controller
    {
        // tạo dữ liệu mẫu
        private static List<Product> _products = new List<Product>()
        {
            new Product { Id = 1, Name = "iPhone 15", Price = 20000000, SalePrice = 18000000, Status = 1, CreatedDate = DateTime.Now, Image = "iphone.jpg", CategoryId = 1, Description = "Sản phẩm Apple" },
            new Product { Id = 2, Name = "MacBook Air M2", Price = 28000000, SalePrice = 25000000, Status = 1, CreatedDate = DateTime.Now, Image = "macbook.jpg", CategoryId = 2, Description = "Sản phẩm Apple" }
        };
        public IActionResult Index()
        {
            return View(_products);
        }
        public IActionResult Create()
        {
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Điện thoại" },
                new Category { Id = 2, Name = "Laptop" },
                new Category { Id = 3, Name = "Phụ kiện" }
            };

            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            return View();
        }
        // thêm mới sản phẩm
        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product model)
        {
            try
            {
                // Lấy file ảnh upload từ Form
                var files = HttpContext.Request.Form.Files;

                if (files.Count() > 0 && files[0].Length > 0)
                {
                    var file = files[0];
                    var FileName = file.FileName;

                    // Tạo đường dẫn lưu ảnh vào thư mục wwwroot\images
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);

                        // Gán tên file ảnh vào thuộc tính Image của sản phẩm
                        model.Image = FileName;
                    }
                }

                // Tự tăng Id cho sản phẩm mới
                model.Id = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
                model.CreatedDate = DateTime.Now;

                // Thêm sản phẩm vào danh sách
                _products.Add(model);

                // Chuyển hướng về trang danh sách (Index)
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
        // hiển thị chi tiết
        // GET: Product/Details/1
        public IActionResult Details(int id)
        {
            // Tìm sản phẩm theo Id trong danh sách _products
            var product = _products.FirstOrDefault(p => p.Id == id);

            // Nếu không tìm thấy sản phẩm thì trả về trang lỗi 404
            if (product == null)
            {
                return NotFound();
            }
            // Trả sản phẩm tìm được sang View
            return View(product);
        }
        // chỉnh sửa sản phẩm
        // GET: Product/Edit/1 (Lấy dữ liệu cũ hiển thị lên form)
        public IActionResult Edit(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            // Danh sách danh mục mẫu cho ComboBox
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Điện thoại" },
                new Category { Id = 2, Name = "Laptop" },
                new Category { Id = 3, Name = "Phụ kiện" }
            };

            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Product/Edit/1 (Xử lý lưu dữ liệu sau khi sửa)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product model)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            // Xử lý upload ảnh mới (nếu người dùng chọn ảnh mới)
            var files = HttpContext.Request.Form.Files;
            if (files.Count() > 0 && files[0].Length > 0)
            {
                var file = files[0];
                var fileName = file.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                    existingProduct.Image = fileName; // Cập nhật ảnh mới
                }
            }

            // Cập nhật thông tin khác
            existingProduct.Name = model.Name;
            existingProduct.Price = model.Price;
            existingProduct.SalePrice = model.SalePrice;
            existingProduct.Status = model.Status;
            existingProduct.CategoryId = model.CategoryId;
            existingProduct.Description = model.Description;

            return RedirectToAction(nameof(Index));
        }
        // xóa sản phẩm
        // GET: Product/Delete/1 (Lấy thông tin chi tiết sản phẩm hiển thị ra trang xác nhận)
        public IActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/1 (Thực hiện xóa khỏi danh sách khi người dùng bấm nút "Xác nhận xóa")
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
