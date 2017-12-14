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
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var user = db.USERs.FirstOrDefault(x => x.Email.ToLower().Equals(email.ToLower()));
            if (user != null)
            {
                if (user.Password.Equals(password))
                {
                    Session["Fullname"] = user.FullName;
                    Session["UserID"] = user.ID;
                    return RedirectToAction("../Agency/PropertyAgency/IndexAgency");
                }
            }
            else
            {
                ViewBag.mgs = "Tài khoản không tồn tại";
            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string fullname, string email, string phone, string address, string password, string rpassword)
        {
            if (fullname == null || email == null || phone == null || address == null || password == null || rpassword == null)
            {
                ViewBag.mgs = "Bạn nhập thiếu thông tin";
            }
            else
            {
                var user = db.USERs.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
                if (user == null)
                {
                    if (password.Equals(rpassword))
                    {
                        USER us = new USER();
                        us.Email = email;
                        us.Address = address;
                        us.FullName = fullname;
                        us.Phone = phone;
                        us.Password = password;
                        us.Status = false;
                        us.Role_ID = 2;
                        db.USERs.Add(us);
                        db.SaveChanges();
                        Session["Fullname"] = us.FullName;
                        Session["UserID"] = us.ID;
                        return RedirectToAction("../Agency/PropertyAgency/IndexAgency");
                    }
                }
                else
                {
                    ViewBag.mgs = "Tài khoản đã tồn tại";
                }
            }
            return View();
        }
    }
}