using AdminShop.Data;
using AdminShop.Models;
using AdminShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AdminShop.Controllers;

public class ProductsController : Controller
{
    private readonly AppDbContext _db;
    private readonly IWebHostEnvironment _env;

    public ProductsController(AppDbContext db, IWebHostEnvironment env)
    {
        _db = db;
        _env = env;
    }

    // GET: Products
    public async Task<IActionResult> Index(string? keyword, int page = 1)
    {
        const int pageSize = 5;
        if (page < 1) page = 1;

        var q = _db.Products
            .Include(x => x.Category)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            q = q.Where(x => x.Name.Contains(keyword));
        }

        var count = await q.CountAsync();
        var pages = Math.Max(1, (int)Math.Ceiling(count / (double)pageSize));
        if (page > pages) page = pages;

        var items = await q.OrderBy(x => x.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return View(new ProductIndexVM
        {
            Items = items,
            Keyword = keyword,
            Page = page,
            TotalPages = pages
        });
    }

    // GET: Products/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var product = await _db.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // GET: Products/Create
    public IActionResult Create()
    {
        LoadCategories();
        return View();
    }

    // POST: Products/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product model, IFormFile? imageFile)
    {
        if (ModelState.IsValid)
        {
            model.Image = await SaveImage(imageFile);
            model.CreatedDate = DateTime.Now;

            _db.Add(model);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        LoadCategories(model.CategoryId);
        return View(model);
    }

    // GET: Products/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var product = await _db.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        LoadCategories(product.CategoryId);
        return View(product);
    }

    // POST: Products/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Product model, IFormFile? imageFile)
    {
        if (id != model.Id)
        {
            return NotFound();
        }

        var oldProduct = await _db.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (oldProduct == null)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            model.Image = imageFile != null ? await SaveImage(imageFile) : oldProduct.Image;
            model.CreatedDate = oldProduct.CreatedDate;

            _db.Update(model);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        LoadCategories(model.CategoryId);
        return View(model);
    }

    // GET: Products/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _db.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // POST: Products/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var product = await _db.Products.FindAsync(id);
        if (product != null)
        {
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    #region Helper Methods

    private void LoadCategories(int? selected = null)
    {
        ViewBag.CategoryId = new SelectList(_db.Categories.OrderBy(x => x.Name), "Id", "Name", selected);
    }

    private async Task<string?> SaveImage(IFormFile? file)
    {
        if (file == null || file.Length == 0)
        {
            return null;
        }

        var extension = Path.GetExtension(file.FileName);
        var fileName = $"{Guid.NewGuid():N}{extension}";
        var folder = Path.Combine(_env.WebRootPath, "images", "products");

        Directory.CreateDirectory(folder);

        var filePath = Path.Combine(folder, fileName);
        using (var stream = System.IO.File.Create(filePath))
        {
            await file.CopyToAsync(stream);
        }

        return "/images/products/" + fileName;
    }

    #endregion
}