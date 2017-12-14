using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPCRental.Models;
using PPCRental.Controllers;
using PPCRental.Areas.Agency.Controllers;
using System.Web.Mvc;
using FluentAssertions;
using TechTalk.SpecFlow;
using PPCRental.AcceptanceTests.Support;
using PPCRental.UITests.Selenium.Support;

namespace PPCRental.AcceptanceTests.Driver.Property
{
    class PostPropertyDriver
    {
        private string _sessionName;
        public void insertUserInfomationToDB(Table user)
        {
            var uInfo = TableExtensions.ToDictionary(user);
            using (var item = new AccountController())
            {
                item.Register(uInfo["Fullname"].ToString(), uInfo["Email"].ToString(), uInfo["Phone"].ToString(), uInfo["Address"].ToString(), uInfo["Password"].ToString(), uInfo["Password"].ToString());
            }
        }
        public bool checkLogged(Table user)
        {
            var sID = TableExtensions.ToDictionary(user);
            using (var item = new AccountController())
            {
                _sessionName = item.Session["FullName"].ToString();
            }
            if (_sessionName == sID["SessionID"])
            {
                return true;
            }
            return false;
        }
        public void navigatePosting()
        {
            using (var item = new PropertyAgencyController())
            {
                item.Create();
            }
        }
        public void inputPropertyInfo(Table property)
        {
            var propInfo = TableExtensions.ToDictionary(property);

            team13Entities db = new team13Entities();
            PROPERTY prop = new PROPERTY();
            prop.PropertyName = propInfo["PropertyName"].ToString();
            prop.PropertyType_ID = int.Parse(propInfo["PropertyType_ID"].ToString());
            prop.Content = propInfo["Content"].ToString();
            prop.Street_ID = int.Parse(propInfo["Street_ID"].ToString());
            prop.Ward_ID = int.Parse(propInfo["Ward_ID"].ToString());
            prop.District_ID = int.Parse(propInfo["District_ID"].ToString());
            prop.Price = int.Parse(propInfo["Price"].ToString());
            prop.UnitPrice = propInfo["UnitPrice"].ToString();
            prop.Area = propInfo["Area"].ToString();
            prop.BedRoom = int.Parse(propInfo["BedRoom"].ToString());
            prop.BathRoom = int.Parse(propInfo["Bathroom"].ToString());
            prop.PackingPlace = int.Parse(propInfo["PackingPlace"].ToString());
            prop.UserID = int.Parse(propInfo["UserId"].ToString());
            prop.Status_ID = int.Parse(propInfo["Status_ID"].ToString());

            using (var item = new PropertyAgencyController())
            {
                item.Create(prop, null, null, null);
            }
        }
    }
}
