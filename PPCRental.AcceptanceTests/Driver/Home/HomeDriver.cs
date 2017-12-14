using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PPCRental.Models;
using PPCRental.Controllers;

namespace PPCRental.AcceptanceTests.Driver.Home
{
    class HomeDriver
    {
        private ActionResult _result;

        public void Navigate()
        {
            using (var controller = new HomeController())
            {
                _result = controller.Index();
            }
        }
    }
}
