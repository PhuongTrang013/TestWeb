using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using PPCRental.Models;
using PPCRental.AcceptanceTests.Common;
using PPCRental.Controllers;
using TechTalk.SpecFlow;
using PPCRental.AcceptanceTests.Support;

namespace PPCRental.AcceptanceTests.Driver.ViewProjects
{
    public class ViewprojectDriver
    {
        private ActionResult _result;

        //public void Navigate()
        //{
        //    using (var controller = new AccountController())
        //    {
        //        _result = controller.Index();
        //    }
        //}
        public void Click()
        {
            using (var cont = new ViewListOfProjectController())
            {
                _result = cont.ViewListOfProjectUser();
            }
        }

        internal void ShowProjects(object p)
        {
            throw new NotImplementedException();
        }

        public void ShowProjects(Table expectedProjects)
        => ShowProjects(expectedProjects.Rows.Select(r => r["Title"]));

        public void ShowProjects(IEnumerable<string> expectedTitles)
        {
           // Act
            var showProjects = _result.Model<IEnumerable<PROPERTY>>();
           // Assert
            ProjectAssertions.HomeScreenShouldShow(showProjects, expectedTitles);
        }

        internal void ShowProject(object expectedProjects)
        {
            throw new NotImplementedException();
        }
    }
}
