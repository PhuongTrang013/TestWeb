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
        K21T1_Team3Entities db = new K21T1_Team3Entities();
        // GET: Admin/ProductAdmin
        public ActionResult IndexAgency()
        {
            var product = db.PROPERTies.ToList();
            return View(product);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = db.PROPERTies.SingleOrDefault(x => x.ID == id);
            ViewBag.PROPERTY_TYPE = db.PROPERTies.OrderByDescending(x => x.ID).ToList();
            ViewBag.Street_ID = db.PROPERTies.OrderByDescending(x => x.ID).ToList();
            ViewBag.Ward_ID = db.PROPERTies.OrderByDescending(x => x.ID).ToList();
            ViewBag.District_ID = db.PROPERTies.OrderByDescending(x => x.ID).ToList();
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(int id, PROPERTY pty)
        {
            var product = db.PROPERTies.SingleOrDefault(x => x.ID == id);
            product.PropertyName = pty.PropertyName;
            product.Images = pty.Images;
            product.Price = pty.Price;
            product.UnitPrice = pty.UnitPrice;
            product.District_ID = pty.District_ID;
            product.PROPERTY_TYPE = pty.PROPERTY_TYPE;
            product.Street_ID = pty.Street_ID;
            product.Ward_ID = pty.Ward_ID;
            db.PROPERTies.Add(product);
            db.SaveChanges();
            return RedirectToAction("IndexAgency");
        }
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
        public ActionResult Create(PROPERTY prop, HttpPostedFileBase Avatar, List<int> chkfeature)//?
        {
            if (Avatar != null)
            {
                string ava = "";
                if (Avatar.ContentLength > 0)
                {
                    var filename = Path.GetFileName(Avatar.FileName);
                    var path = Path.Combine(Server.MapPath("/Images/"), filename);
                    Avatar.SaveAs(path);
                    ava = filename;
                }
                prop.Avatar = ava;
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
        public ActionResult SaveDraft(PROPERTY prop, HttpPostedFileBase Avatar, List<int> chkfeature)//?
        {
            if (Avatar != null)
            {
                string ava = "";
                if (Avatar.ContentLength > 0)
                {
                    var filename = Path.GetFileName(Avatar.FileName);
                    var path = Path.Combine(Server.MapPath("/Images/"), filename);
                    Avatar.SaveAs(path);
                    ava = filename;
                }
                prop.Avatar = ava;
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

        [HttpPost]
        public ActionResult Edit(PROPERTY prop, HttpPostedFileBase Avatar, List<int> chkfeature)//?
        {
            if (Avatar != null)
            {
                string ava = "";
                if (Avatar.ContentLength > 0)
                {
                    var filename = Path.GetFileName(Avatar.FileName);
                    var path = Path.Combine(Server.MapPath("/Images/"), filename);
                    Avatar.SaveAs(path);
                    ava = filename;
                }
                prop.Avatar = ava;
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
            var product = db.PROPERTies.FirstOrDefault(x => x.ID == id);
            List<PROPERTY_FEATURE> pf = new List<PROPERTY_FEATURE>();
            foreach (var item in pf)
            {
                if (item.Property_ID == id)
                {
                    
                }
            }
            db.PROPERTies.Remove(product);
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
    }
}