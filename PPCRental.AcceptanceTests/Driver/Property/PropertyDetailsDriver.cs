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
            using (var db = new K21T1_Team3Entities())
            {
                foreach (var item in project.Rows)
                {
                    var property = item["PropertyName"].ToString();
                    var content = item["Content"].ToString();
                    var protype = item["PropertyType"].ToString();
                    var street = item["Street"].ToString();
                    var ward = item["Ward"].ToString();
                    var district = item["District"].ToString();

                    PROPERTY pro = new PROPERTY
                    {
                        PropertyName = property,
                        Content = content,
                        Price = int.Parse(item["Price"]),
                        PropertyType_ID = db.PROPERTY_TYPE.FirstOrDefault(t => t.CodeType == protype).ID,
                        Street_ID = db.STREETs.FirstOrDefault(s => s.StreetName == street).ID,
                        Ward_ID = db.WARDs.FirstOrDefault(s => s.WardName == ward).ID,
                        District_ID = db.DISTRICTs.FirstOrDefault(s => s.DistrictName == district).ID
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

            var db = new K21T1_Team3Entities();

            var property = expectedProjectDetails["PropertyName"].ToString();
            var content = expectedProjectDetails["Content"].ToString();
            var protype = expectedProjectDetails["PropertyType"].ToString();
            var street = expectedProjectDetails["Street"].ToString();
            var ward = expectedProjectDetails["Ward"].ToString();
            var district = expectedProjectDetails["District"].ToString();

            //Assert
            actualProjectDetails.Should().Match<PROPERTY>(
                b => b.PropertyName == property
                && b.PropertyType_ID == db.PROPERTY_TYPE.FirstOrDefault(t => t.TypeCode == protype).ID
                && b.Content == content
                && b.Street_ID == db.STREETs.FirstOrDefault(d => d.StreetName == street).ID
                && b.District_ID == db.DISTRICTs.FirstOrDefault(e => e.DistrictName == district).ID
                && b.Ward_ID == db.WARDs.FirstOrDefault(f => f.WardName == ward).ID
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
