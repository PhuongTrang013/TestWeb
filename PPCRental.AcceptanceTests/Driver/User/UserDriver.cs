using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PPCRental.Controllers;

namespace PPCRental.AcceptanceTests.Driver.User
{
    public class UserDriver
    {
        private ActionResult _result;

        public void Navigate()
        {
            using (var controller = new AccountController())
            {
                _result = controller.Login();
            }
        }

        public void Login(string username, string password)
        {
            using (var controller = new AccountController())
            {
                _result = controller.Login(username, password);
            }
        }
    }
}
