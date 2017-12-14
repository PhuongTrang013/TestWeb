using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCRental.Models;
using System.IO;

namespace PPCRental.Areas.Agency.Controllers
{
    public class PropertyAgencyController : Controller
    {
        team13Entities db = new team13Entities();
        // GET: Admin/ProductAdmin
        public ActionResult IndexAgency()
        {
            var us = db.PROPERTies.Find(int.Parse(Session["UserID"].ToString()));
            //var product
            //if (us.USER.Role == "1")
            //{
                var product = db.PROPERTies.ToList().OrderByDescending(x => x.ID);
            //}
            
            return View(product);
        }

        //[HttpPost]
        //public ActionResult Edit(int id, PROPERTY pty, )
        //{
        //    var product = db.PROPERTies.SingleOrDefault(x => x.ID == id);
        //    product.PropertyName = pty.PropertyName;
        //    product.Images = pty.Images;
        //    product.Price = pty.Price;
        //    product.UnitPrice = pty.UnitPrice;
        //    product.District_ID = pty.District_ID;
        //    product.PROPERTY_TYPE = pty.PROPERTY_TYPE;
        //    product.Street_ID = pty.Street_ID;
        //    product.Ward_ID = pty.Ward_ID;
        //    db.PROPERTies.Add(product);
        //    db.SaveChanges();
        //    return RedirectToAction("IndexAgency");
        //}
        public JsonResult GetStreet(int District_id)
        {
            return Json(
            db.WARDs.Where(s => s.District_ID == District_id)
            .Select(s => new { id = s.ID, text = s.WardName }).ToList(),
            JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Create()
        {
            //List<DISTRICT> so = new List<DISTRICT>();
            //foreach(var item in db.DISTRICTs)
            //{
            //    so.Add(item);
            //}
            //ViewData["District"] = so;
            var model = new PROPERTY();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(PROPERTY prop, HttpPostedFileBase Avatar, List<HttpPostedFileBase> Image, List<int> chkfeature)//?
        {
            string path1 = "";
            if (Avatar != null)
            {
                string ava = "";
                if (Avatar.ContentLength > 0)
                {
                    var filename = Path.GetFileName(Avatar.FileName);
                    path1 = Path.Combine(Server.MapPath("/Images/"), filename);
                    Avatar.SaveAs(path1);
                    ava = filename;
                }
                prop.Avatar = ava;
            }

            string path2 = "";
            foreach (var item in Image)
            {
                if (item != null)
                {
                    try
                    {
                        var filename2 = Path.GetFileName(item.FileName);
                        path2 = Path.Combine(Server.MapPath("~/Images/"), filename2);
                        item.SaveAs(path2);
                        prop.Images += filename2 + ",";
                    }
                    catch
                    {
                        ViewBag.mgs = "error";
                        return View("IndexAgency");
                    }
                }
            }

            foreach (int fe in chkfeature)
            {
                PROPERTY_FEATURE fea = new PROPERTY_FEATURE();
                fea.Feature_ID = db.FEATUREs.SingleOrDefault(x => x.ID == fe).ID;
                fea.Property_ID = prop.ID;
                db.PROPERTY_FEATURE.Add(fea);
            }

            prop.Created_at = DateTime.Now;
            prop.Status_ID = 1;
            prop.UserID = int.Parse(Session["UserID"].ToString());
            db.PROPERTies.Add(prop);
            db.SaveChanges();
            return RedirectToAction("IndexAgency");
        }
        [HttpPost]
        public ActionResult SaveDraft(PROPERTY prop, HttpPostedFileBase Avatar, List<HttpPostedFileBase> Image, List<int> chkfeature)//?
        {
            string path1 = "";
            if (Avatar != null)
            {
                string ava = "";
                if (Avatar.ContentLength > 0)
                {
                    var filename = Path.GetFileName(Avatar.FileName);
                    path1 = Path.Combine(Server.MapPath("/Images/"), filename);
                    Avatar.SaveAs(path1);
                    ava = filename;
                }
                prop.Avatar = ava;
            }

            string path2 = "";
            foreach (var item in Image)
            {
                if (item != null)
                {
                    try
                    {
                        var filename2 = Path.GetFileName(item.FileName);
                        path2 = Path.Combine(Server.MapPath("~/Images/"), filename2);
                        item.SaveAs(path2);
                        prop.Images += filename2 + ",";
                    }
                    catch
                    {
                        ViewBag.mgs = "error";
                        return View("IndexAgency");
                    }
                }
            }

            foreach (int fe in chkfeature)
            {
                PROPERTY_FEATURE fea = new PROPERTY_FEATURE();
                fea.Feature_ID = db.FEATUREs.SingleOrDefault(x => x.ID == fe).ID;
                fea.Property_ID = prop.ID;
                db.PROPERTY_FEATURE.Add(fea);
            }

            prop.Created_at = DateTime.Now;
            prop.Status_ID = 2;
            prop.UserID = int.Parse(Session["UserID"].ToString());
            db.PROPERTies.Add(prop);
            db.SaveChanges();
            return RedirectToAction("IndexAgency");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            PROPERTY prop = db.PROPERTies.Find(id);
            ViewBag.prop_type = db.PROPERTY_TYPE.ToList().OrderByDescending(x => x.ID);
            ViewBag.prop_street = db.STREETs.ToList().OrderByDescending(x => x.ID);
            ViewBag.prop_ward = db.WARDs.ToList().OrderByDescending(x => x.ID);
            ViewBag.prop_district = db.DISTRICTs.ToList().OrderByDescending(x => x.ID);
            return View(prop);
        }

        [HttpPost]
        public ActionResult Edit(PROPERTY prop, HttpPostedFileBase Avatar, List<HttpPostedFileBase> Image, List<int> chkfeature)//?
        {
            string path1 = "";
            if (Avatar != null)
            {
                string ava = "";
                if (Avatar.ContentLength > 0)
                {
                    var filename = Path.GetFileName(Avatar.FileName);
                    path1 = Path.Combine(Server.MapPath("/Images/"), filename);
                    Avatar.SaveAs(path1);
                    ava = filename;
                }
                prop.Avatar = ava;
            }

            string path2 = "";
            foreach (var item in Image)
            {
                if (item != null)
                {
                    try
                    {
                        var filename2 = Path.GetFileName(item.FileName);
                        path2 = Path.Combine(Server.MapPath("~/Images/"), filename2);
                        item.SaveAs(path2);
                        prop.Images += filename2 + ",";
                    }
                    catch
                    {
                        ViewBag.mgs = "error";
                        return View("IndexAgency");
                    }
                }
            }

            foreach (int fe in chkfeature)
            {
                PROPERTY_FEATURE fea = new PROPERTY_FEATURE();
                fea.Feature_ID = db.FEATUREs.SingleOrDefault(x => x.ID == fe).ID;
                fea.Property_ID = prop.ID;
                db.PROPERTY_FEATURE.Add(fea);
            }

            PROPERTY p = db.PROPERTies.Find(prop.ID);
            p.Created_at = DateTime.Now;
            p.Status_ID = 1;
            p.PropertyName = prop.PropertyName;
            p.District_ID = prop.District_ID;
            p.Ward_ID = prop.Ward_ID;
            p.Street_ID = prop.Street_ID;
            p.Price = prop.Price;
            p.UnitPrice = prop.UnitPrice;
            p.BedRoom = prop.BedRoom;
            p.BathRoom = prop.BathRoom;
            p.PackingPlace = prop.PackingPlace;
            p.Content = prop.Content;
            p.UserID = int.Parse(Session["UserID"].ToString());
            db.PROPERTies.Add(prop);
            db.SaveChanges();
            return RedirectToAction("IndexAgency");
        }

        public ActionResult Delete(int id)
        {
            PROPERTY prop = db.PROPERTies.Find(id);
            foreach (var fe in db.PROPERTY_FEATURE)
            {
                if (fe.Property_ID == id)
                {
                    db.PROPERTY_FEATURE.Remove(fe);
                }
            }
            db.PROPERTies.Remove(prop);
            db.SaveChanges();
            return RedirectToAction("IndexAgency");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var product = db.PROPERTies.FirstOrDefault(x => x.ID == id);
            return View(product);
        }

        [HttpGet]
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
                    return RedirectToAction("IndexAgency");
                }
            }
            else
            {
                return View();
            }
            return View();
        }
        public ActionResult Logout(int id)
        {
            var user = db.USERs.FirstOrDefault(x => x.ID == id);
            if (user != null)
            {
                Session["Fullname"] = null;
                Session["UserID"] = null;
            }
            return RedirectToAction("Login");
        }
        [HttpPost]
        public ActionResult Register(string fullname, string email, string address, string phone, string password, string rpassword)
        {
            var user = db.USERs.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
            if (user == null)
            {
                if (password.Equals(rpassword))
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
                    return RedirectToAction("IndexAgency");
                }
            }
            else
            {
                ViewBag.mgs = "Tài khoản đã tồn tại";
            }
            return View("Login");
        }
    }
}