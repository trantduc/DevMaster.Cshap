using AdminShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminShop.Controllers;

public class BannersController : Controller
{
    private readonly AppDbContext _db;

    public BannersController(AppDbContext db)
    {
        _db = db;
    }

    // GET: Banners
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var banners = await _db.Banners
            .AsNoTracking()
            .ToListAsync();

        return View(banners);
    }
}