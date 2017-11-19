using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCRental.Models;

namespace PPCRental.Controllers
{
    public class ViewListOfProjectUserController : Controller
    {
        K21T1_Team3Entities db = new K21T1_Team3Entities();
        // GET: ViewListOfProjectUser
        public ActionResult ViewListOfProjectUser()
        {
            var pro = db.PROPERTies.ToList();
            return View(pro);
        }
    }
}