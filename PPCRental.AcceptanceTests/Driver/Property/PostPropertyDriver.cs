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
        public PROPERTY _prop = new PROPERTY();

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

            K21T1_Team3Entities db = new K21T1_Team3Entities();
            _prop.PropertyName = propInfo["PropertyName"].ToString();
            _prop.PropertyType_ID = int.Parse(propInfo["PropertyType_ID"].ToString());
            _prop.Content = propInfo["Content"].ToString();
            _prop.Street_ID = int.Parse(propInfo["Street_ID"].ToString());
            _prop.Ward_ID = int.Parse(propInfo["Ward_ID"].ToString());
            _prop.District_ID = int.Parse(propInfo["District_ID"].ToString());
            _prop.Price = int.Parse(propInfo["Price"].ToString());
            _prop.UnitPrice = propInfo["UnitPrice"].ToString();
            _prop.Area = propInfo["Area"].ToString();
            _prop.BedRoom = int.Parse(propInfo["BedRoom"].ToString());
            _prop.BathRoom = int.Parse(propInfo["Bathroom"].ToString());
            _prop.PackingPlace = int.Parse(propInfo["PackingPlace"].ToString());
            _prop.UserID = int.Parse(propInfo["UserId"].ToString());
            _prop.Status_ID = int.Parse(propInfo["Status_ID"].ToString());
        }
        public void clickSaveButton()
        {
            using (var item = new PropertyAgencyController())
            {
                item.Create(_prop, null, null, null);
            }
        }
    }
}
