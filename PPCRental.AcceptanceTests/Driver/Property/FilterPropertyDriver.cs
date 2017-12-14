using System;
using System.Collections.Generic;
using System.Linq;
using PPCRental.Models;
using PPCRental.Controllers;
using System.Web.Mvc;
using TechTalk.SpecFlow;
using PPCRental.AcceptanceTests.Support;
using PPCRental.AcceptanceTests.Common;

namespace PPCRental.AcceptanceTests.Driver.Property
{
    public class FilterPropertyDriver
    {
        private ActionResult _result;
        private readonly PropertyContext _context;

        public void Filter(string property_Name)
        {
            using (var controller = new HomeController())
            {
                _result = controller.Filter(property_Name, null, null, null, null);
            } 
        }

        public void ShouldShowProjects(Table expectedProperties)
        {
            //Arrange
            var expectedProjects = expectedProperties.Rows.Select(r => r["Property_Name"]);


            //Act
            var actualProjects = _result.Model<IEnumerable<PPCRental.Models.PROPERTY>>();

            //Assert
            ProjectAssertions.HomeScreenShouldShow(actualProjects, expectedProjects);
        }

        public void OpenProjectFilter(string Property_Name)
        {
           var filter = _context.ReferenceFilter.GetById(Property_Name);
            using (var controller = new HomeController())
            {
                _result = controller.Filter(filter.PropertyName, null, null, null, null);
            }
        }
    }
}
