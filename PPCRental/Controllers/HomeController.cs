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
        K21T1_Team3Entities db = new K21T1_Team3Entities();
        public ActionResult Index()
        {
            var pro = db.PROPERTies.ToList().OrderByDescending(x => x.ID);
            return View(pro);
        }
        [HttpPost]
        public ActionResult Filter(string propertyname, string Quan_ID, string Phuong_ID)
        {
            int Quan = int.Parse(Quan_ID);
            //int Phuong = int.Parse(Phuong_ID);
            var model = db.PROPERTies.ToList().Where(p => (p.District_ID == Quan) /*|| (p.Ward_ID == Phuong) || (p.PropertyName.ToLower().Contains(propertyname) || propertyname!=null))*/);
            return View(model);
            //propertyname = propertyname.ToLower();

            //if (propertyname == "" && bathroom != null)
            //{
            //    var model = db.PROPERTies.ToList().Where(p => p.BathRoom==(int.Parse(bathroom)));
            //    return View(model);
            //}
            //else
            //{

            //    var model = db.PROPERTies.ToList().Where(p => p.BathRoom.Equals(bathroom) || p.PropertyName.ToLower().Contains(propertyname.ToLower()));
            //    return View(model);
            //}
            //(p.PropertyName.ToLower().Contains(propertyname)) || (p.BathRoom == numOfBathroom)
          
        }
        public JsonResult GetStreet(int District_id)
        {
            return Json(
            db.WARDs.Where(s => s.District_ID == District_id)
            .Select(s => new { id = s.ID, text = s.WardName }).ToList(),
            JsonRequestBehavior.AllowGet);
        }
    }
}
