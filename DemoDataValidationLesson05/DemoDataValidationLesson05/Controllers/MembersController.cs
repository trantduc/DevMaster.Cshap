using DemoDataValidationLesson05.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoDataValidationLesson05.Controllers
{
    public class MembersController : Controller
    {
        public static List<Member> _members = new List<Member>()
        {
            new Member(){ MemberID = "01", FullName ="Trần Việt ĐỨc" , Email ="tranvietduc@gmail.com", Password ="12345",
                Phone ="0362382600", Birtday = DateTime.Parse("12/08/1999"), UserName="Member1"
            }
        };
        public IActionResult Index()
        {
            return View(_members);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Member member = new Member()
                {
                    MemberID = Guid.NewGuid().ToString(),
                    FullName = model.FullName,
                    Email = model.Email,
                    Password = model.Password,
                    Phone = model.Phone,
                    Birtday = model.Birtday,
                    UserName = model.UserName
                };
                _members.Add(member);
                return RedirectToAction("Index");

            }
            else
            {
                return View(model);
            }
        }
    }
}
