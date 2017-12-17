using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCRental.Models;
using System.Net;

namespace PPCRental.Controllers
{
    public class ViewDetailOfProjectUserController : Controller
    {
        K21T1_Team3Entities db = new K21T1_Team3Entities();
        // GET: ViewDetailOfProjectUser
        public ActionResult ViewDetailOfProject(int id)
        {
            var detail = db.PROPERTies.FirstOrDefault(x => x.ID == id);
            return View(detail);
        }
    }
}