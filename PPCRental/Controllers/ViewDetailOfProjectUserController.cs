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
        K21T1_Tteam13Entities db = new K21T1_Tteam13Entities();
        // GET: ViewDetailOfProjectUser
        public ActionResult ViewDetailOfProject(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var detail = db.PROPERTies.FirstOrDefault(x => x.ID == id);
            if (detail == null)
            {
                return HttpNotFound();
            }
            return View(detail);
        }
    }
}