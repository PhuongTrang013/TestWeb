using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCRental.Models;

namespace PPCRental.Controllers
{
    public class ViewListOfProjectController : Controller
    {
        K21T1_Tteam13Entities db = new K21T1_Tteam13Entities();
        // GET: ViewListOfProjectUser
        public ActionResult ViewListOfProjectUser(int typeid = 1)
        {
            var pro = db.PROPERTY_TYPE.FirstOrDefault(s => s.ID == typeid);
            var result = db.PROPERTies.Where(s => s.PropertyType_ID == pro.ID).ToList();
            return View(result);
        }
    }
}