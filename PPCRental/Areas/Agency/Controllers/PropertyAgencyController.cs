using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCRental.Models;

namespace PPCRental.Areas.Agency.Controllers
{
    public class PropertyAgencyController : Controller
    {
        // GET: Agency/PropertyAgency
        K21T1_Team3Entities db = new K21T1_Team3Entities();
        // GET: Admin/ProductAdmin
        public ActionResult IndexAgency()
        {
            var product = db.PROPERTies.OrderByDescending(x => x.ID).ToList();
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
            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public ActionResult Create(PROPERTY pty)
        //{
        //    var product = new PROPERTY();
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

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var product = db.PROPERTies.FirstOrDefault(x=>x.ID == id);
            return View(product);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var product = db.PROPERTies.FirstOrDefault(x => x.ID == id);
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
        public ActionResult Create()
        {
            ViewBag.product_type = db.PROPERTY_TYPE.OrderByDescending(x => x.ID).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(PROPERTY p, HttpPostedFileBase Avatar)
        {
            return RedirectToAction("IndexAgency");
        }
    }
}