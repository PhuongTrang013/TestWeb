using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCRental.Models;

namespace PPCRental.Controllers
{
    public class ViewDetailOfProjectUserController : Controller
    {
        team13Entities db = new team13Entities();
        // GET: ViewDetailOfProjectUser
        public ActionResult ViewDetailOfProject(int id)
        {
            var detail = db.PROPERTies.FirstOrDefault(x => x.ID == id);
            return View(detail);
        }
    }
}