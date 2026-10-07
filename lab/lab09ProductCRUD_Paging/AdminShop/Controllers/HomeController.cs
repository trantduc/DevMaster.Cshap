using Microsoft.AspNetCore.Mvc;

namespace AdminShop.Controllers;

public class HomeController : Controller
{
    // GET: Home
    [HttpGet]
    public IActionResult Index()
    {
        // kiểm tra trong session
        var accountId = HttpContext.Session.GetInt32("AccountId");

        if (accountId == null)
        {
            return RedirectToAction("Login", "Accounts");
        }

        return View();
    }
}