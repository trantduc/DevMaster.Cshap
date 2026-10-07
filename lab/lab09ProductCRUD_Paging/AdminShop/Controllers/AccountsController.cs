using AdminShop.Data;
using AdminShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AdminShop.Controllers;

public class AccountsController : Controller
{
    private readonly AppDbContext _db;

    public AccountsController(AppDbContext db)
    {
        _db = db;
    }

    // GET: Accounts
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var accounts = await _db.Accounts
            .AsNoTracking()
            .ToListAsync();

        return View(accounts);
    }
    // Hiển thị trang đăng nhập
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    // Xử lý đăng nhập
    [HttpPost]
    public IActionResult Login(Login model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var account = _db.Accounts.FirstOrDefault(x =>
            x.Email == model.Email &&
            x.Password == model.Password);

        if (account == null)
        {
            ViewBag.Error = "Email hoặc mật khẩu không đúng";
            return View(model);
        }
        // lưu session
        HttpContext.Session.SetInt32("AccountId", account.Id);
        HttpContext.Session.SetString("AccountName", account.Name);
        HttpContext.Session.SetString("AccountEmail", account.Email);
        if (account.Avatar != null)
        {
            HttpContext.Session.SetString("AccountAvatar", account.Avatar);
        }

        return RedirectToAction("Index", "Home");
    }
    //xử lý đăng xuất
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login", "Accounts");
    }
}