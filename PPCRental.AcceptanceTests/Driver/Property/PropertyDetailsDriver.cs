using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPCRental.Models;
using PPCRental.Controllers;
using System.Web.Mvc;
using FluentAssertions;
using TechTalk.SpecFlow;
using PPCRental.AcceptanceTests.Support;

namespace PPCRental.AcceptanceTests.Driver.Property
{
    public class PropertyDetailsDriver
    {
        private ActionResult _result;
        private readonly PropertyContext _context;

        //public PPCRentalDetailsDriver(CatalogContext context)
        //{
        //    _context = context;
        //}

        public void InsertPropertyToDB(Table project)
        {
            using (var db = new K21T1_Tteam13Entities())
            {
                foreach (var item in project.Rows)
                {
                    PROPERTY pro = new PROPERTY
                    {
                        PropertyName = item["PropertyName"],
                        Content = item["Content"],
                        Price = int.Parse(item["Price"]),
                        PropertyType_ID = db.PROPERTY_TYPE.FirstOrDefault(t => t.CodeType == item["PropertyType"]).ID,
                        Street_ID = db.STREETs.FirstOrDefault(s => s.StreetName == item["Street"]).ID,
                        Ward_ID = db.WARDs.FirstOrDefault(s => s.WardName == item["Ward"]).ID,
                        District_ID = db.DISTRICTs.FirstOrDefault(s => s.DistrictName == item["District"]).ID
                    };

                    //_context.ReferenceDetails.Add(
                    //        project.Header.Contains("ID") ? item["ID"] : pro.PropertyName,
                    //        pro);

                    db.PROPERTies.Add(pro);
                }

                db.SaveChanges();
            }
        }

        public void ShowProjectDetails(Table shownPPCRentalDetails)
        {
            //Arrange
            var expectedProjectDetails = shownPPCRentalDetails.Rows.Single();

            //Act
            var actualProjectDetails = _result.Model<PROPERTY>();

            var db = new K21T1_Tteam13Entities();
            //Assert
            actualProjectDetails.Should().Match<PROPERTY>(
                b => b.PropertyName == expectedProjectDetails["PropertyName"]
                && b.PROPERTY_TYPE.ToString() == expectedProjectDetails["PropertyType"]
                && b.Content == expectedProjectDetails["Content"]
                && b.Street_ID == db.STREETs.FirstOrDefault(d => d.StreetName == expectedProjectDetails["Street"]).ID
                && b.District_ID == db.DISTRICTs.FirstOrDefault(e => e.DistrictName == expectedProjectDetails["District"]).ID
                && b.Ward_ID == db.WARDs.FirstOrDefault(f => f.WardName == expectedProjectDetails["Ward"]).ID
                && b.Price == int.Parse(expectedProjectDetails["Price"]));
        }

        public void OpenProjectDetails(string ID)
        {
            var details = _context.ReferenceDetails.GetById(ID);
            using (var controller = new ViewDetailOfProjectUserController())
            {
                _result = controller.ViewDetailOfProject(details.ID);
            }
        }
    }
}
