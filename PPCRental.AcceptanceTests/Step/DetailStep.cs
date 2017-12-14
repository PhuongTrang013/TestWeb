using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPCRental.Models;
using PPCRental.UITests.Selenium.Support;
using PPCRental.AcceptanceTests.Driver.Property;
using TechTalk.SpecFlow;

namespace PPCRental.AcceptanceTests.Step
{
    [Binding]
    public class DetailStep
    {
        private readonly PropertyDetailsDriver _projectDriver;

        [Given(@"the following project")]
        public void GivenTheFollowingProject(Table givenProperties)
        {
            _projectDriver.InsertPropertyToDB(givenProperties);
        }

        [When(@"I open the details of '(.*)'")]
        public void WhenIOpenTheDetailsOf(string property)
        {
            _projectDriver.OpenProjectDetails(property);
        }

        [Then(@"the project details should show")]
        public void ThenTheProjectDetailsShouldShow(Table ShowProperty)
        {
            _projectDriver.ShowProjectDetails(ShowProperty);
        }

    }
}
