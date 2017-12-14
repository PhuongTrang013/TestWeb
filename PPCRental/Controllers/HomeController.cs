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
        K21T1_Tteam13Entities db = new K21T1_Tteam13Entities();
        public ActionResult Index()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";

            var pro = db.PROPERTies.ToList().OrderByDescending(x => x.ID);
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

       /* public ActionResult Filter(string property_Name)
        {
            throw new NotImplementedException();
        }*/
    }
}
