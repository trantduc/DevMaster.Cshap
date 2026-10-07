using AdminShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminShop.Controllers;

public class CustomersController : Controller
{
    private readonly AppDbContext _db;

    public CustomersController(AppDbContext db)
    {
        _db = db;
    }

    // GET: Customers
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var customers = await _db.Customers
            .AsNoTracking()
            .ToListAsync();

        return View(customers);
    }
}