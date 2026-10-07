using AdminShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminShop.Controllers;

public class OrdersController : Controller
{
    private readonly AppDbContext _db;

    public OrdersController(AppDbContext db)
    {
        _db = db;
    }

    // GET: Orders
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var orders = await _db.Orders
            .Include(x => x.Customer)
            .AsNoTracking()
            .ToListAsync();

        return View(orders);
    }
}