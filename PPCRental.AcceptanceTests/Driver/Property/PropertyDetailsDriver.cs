using FluentAssertions;
using PPCRental.Controllers;
using PPCRental.Models;
using PPCRental.AcceptanceTests.Support;
using System.Linq;
using System.Web.Mvc;
using TechTalk.SpecFlow;
using System;



namespace PPCRental.AcceptanceTests.Driver.Property
{
    class PropertyDetailsDriver
    {
        private readonly PropertyContext _context = new PropertyContext();
        private ActionResult _result;


        public void InsertProjectToDB(Table projects)
        {
            using (var db = new K21T1_Team3Entities())
            {

                foreach (var item in projects.Rows)
                {
                    var property = item["PropertyName"].ToString();
                    var content = item["Content"].ToString();
                    var protype = item["PropertyType"].ToString();
                    var street = item["Street"].ToString();
                    var ward = item["Ward"].ToString();
                    var district = item["District"].ToString();

                    PROPERTY pro = new PROPERTY()
                    {

                        PropertyName = property,
                        Content = content,
                        Price = int.Parse(item["Price"].ToString()),
                        PropertyType_ID = db.PROPERTY_TYPE.FirstOrDefault(t => t.CodeType == protype).ID,
                        Street_ID = db.STREETs.FirstOrDefault(s => s.StreetName == street).ID,
                        Ward_ID = db.WARDs.FirstOrDefault(s => s.WardName == ward).ID,
                        District_ID = db.DISTRICTs.FirstOrDefault(s => s.DistrictName == district).ID


                    };
                    _context.ReferenceDetails.Add(projects.Header.Contains("ID") ? item["ID"] : pro.PropertyName, pro);
                    db.PROPERTies.Add(pro);
                }
                db.SaveChanges();

            }
        }
        public void ShowDetailProject(Table ShowDetailProject)
        {
            //Arrange
            var expectedProjectDetails = ShowDetailProject.Rows.Single();

            //Act
            var actualProjectDetails = _result.Model<PROPERTY>();

            //Assert
            actualProjectDetails.Should().Match<PROPERTY>(
                b => b.PropertyName == expectedProjectDetails["PropertyName"]);
        }

        public void OpenPropertyDetails(string PropertyName)
        {
            var db = new K21T1_Team3Entities();

            int property_Id = db.PROPERTies.FirstOrDefault(r => r.PropertyName == PropertyName).ID;

            using (var controller = new ViewDetailOfProjectUserController())
            {
                _result = controller.ViewDetailOfProject(property_Id);
            }
        }
    }
}
