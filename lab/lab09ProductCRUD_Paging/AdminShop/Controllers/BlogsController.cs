using AdminShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminShop.Controllers;

public class BlogsController : Controller
{
    private readonly AppDbContext _db;

    public BlogsController(AppDbContext db)
    {
        _db = db;
    }

    // GET: Blogs
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var blogs = await _db.Blogs
            .AsNoTracking()
            .ToListAsync();

        return View(blogs);
    }
}