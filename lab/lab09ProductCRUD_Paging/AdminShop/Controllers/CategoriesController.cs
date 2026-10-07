using AdminShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminShop.Controllers;

public class CategoriesController : Controller
{
    private readonly AppDbContext _db;

    public CategoriesController(AppDbContext db)
    {
        _db = db;
    }

    // GET: Categories
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var categories = await _db.Categories
            .AsNoTracking()
            .ToListAsync();

        return View(categories);
    }
}