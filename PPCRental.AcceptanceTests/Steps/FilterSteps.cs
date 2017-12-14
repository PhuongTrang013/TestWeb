using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPCRental.Models;
using PPCRental.UITests.Selenium.Support;
using PPCRental.AcceptanceTests.Driver.Property;
using PPCRental.AcceptanceTests.Driver.Home;
using TechTalk.SpecFlow;


namespace PPCRental.AcceptanceTests.Steps
{
    class FilterStepd
    {
        [Given(@"the following property")]
        public void GivenTheFollowingProperty(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"User at the Home page")]
        public void GivenUserAtTheHomePage()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I search for property by the pharse '(.*)'")]
        public void WhenISearchForPropertyByThePharse(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"User should see the list name of project")]
        public void ThenUserShouldSeeTheListNameOfProject(Table table)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
