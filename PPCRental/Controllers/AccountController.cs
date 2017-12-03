using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCRental.Models;

namespace PPCRental.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        K21T1_Team3Entities db = new K21T1_Team3Entities();
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                var userid = int.Parse(Session["UserID"].ToString());
            }
            else
            {
                return RedirectToAction("Login");
            }
            var emp = db.USERs.OrderByDescending(x => x.ID).ToList();
            return View(emp);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = db.USERs.FirstOrDefault(x => x.Email == username);
            if (user != null)
            {
                if (user.Password.Equals(password))
                {
                    Session["Fullname"] = user.FullName;
                    Session["UserID"] = user.ID;
                    return RedirectToAction("~/");
                }
            }
            else
            {
                ViewBag.mgs = "Tài khoản không tồn tại";
            }
            return View();
        }
    }
}