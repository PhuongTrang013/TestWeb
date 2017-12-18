using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using PPCRental.Models;

namespace PPCRental.Controllers
{
    public class HomeController : Controller
    {
        team13Entities db = new team13Entities();
        public ActionResult Index()
        {
            var pro = db.PROPERTies.ToList();
            return View(pro);
        }
        public ActionResult Filter(string propname, int? PropertyType, int? bathroom, int? price, int? Quan_ID)
        {
            IEnumerable<PPCRental.Models.PROPERTY> prop;
            if (price == 1)
            {
                prop = db.PROPERTies.ToList().Where(x => x.PropertyName.ToLower().Contains(propname.ToLower()) || ((x.Price < 1000000000) && (x.District_ID  ==  Quan_ID) && (x.BathRoom.Equals(bathroom)) && (x.PROPERTY_TYPE.ID == PropertyType)));
            } else if (price == 2)
            {
                prop = db.PROPERTies.ToList().Where(x => x.PropertyName.ToLower().Contains(propname.ToLower()) || ((x.Price >= 1000000000 || x.Price < 3000000000) && (x.District_ID == Quan_ID) && (x.BathRoom.Equals(bathroom)) && (x.PROPERTY_TYPE.ID == PropertyType)));
            } else if (price == 3)
            {
                prop = db.PROPERTies.ToList().Where(x => x.PropertyName.ToLower().Contains(propname.ToLower()) || ((x.Price >= 3000000000 || x.Price < 5000000000) && (x.District_ID == Quan_ID) && (x.BathRoom.Equals(bathroom)) && (x.PROPERTY_TYPE.ID == PropertyType)));
            } else
            {
                prop = db.PROPERTies.ToList().Where(x => x.PropertyName.ToLower().Contains(propname.ToLower()) || ((x.Price >= 5000000000) && (x.District_ID == Quan_ID) && (x.BathRoom.Equals(bathroom)) && (x.PROPERTY_TYPE.ID == PropertyType)));
            }
            return View(prop);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var user = db.USERs.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
            if (user != null)
            {
                if (user.Password.Equals(password))
                {
                    Session["Fullname"] = user.FullName;
                    Session["UserID"] = user.ID;
                    return RedirectToAction("IndexAgency");
                }
            }
            else
            {
                ViewBag.mgs = "Tài khoản không tồn tại";
            }
            return View();
        }
        [HttpPost]
        public ActionResult Register(string fullname, string email, string address, string phone, string password, string confirmpassword)
        {
            var user = db.USERs.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
            if (user == null)
            {
                if (password == confirmpassword)
                {
                    USER us = new USER();
                    us.Email = email;
                    us.Address = address;
                    us.Phone = phone;
                    us.Password = password;
                    db.USERs.Add(us);
                    db.SaveChanges();
                    Session["Fullname"] = us.FullName;
                    Session["UserID"] = us.ID;
                    return RedirectToAction("~/Agency/PropertyAgency/IndexAgency");
                }
            }
            else
            {
                ViewBag.mgs = "Tài khoản đã tồn tại";
            }
            return View();
        }
    }
}
