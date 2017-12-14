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

namespace PPCRental.AcceptanceTests.Step
{
    [Binding, Scope(Tag = "automated")]
    class FilterSteps
    {
        private FilterPropertyDriver _filterDriver;

        public FilterSteps(FilterPropertyDriver driver)
        {
            _filterDriver = driver;
        }

        [Given(@"the following property")]
        public void GivenTheFollowingProperty(Table inputProperty)
        {
            
        }

        [Given(@"User at the Home page")]
        public void GivenUserAtTheHomePage()
        {
            HomeDriver _homeDriver = new HomeDriver();
            _homeDriver.Navigate();
        }

        [When(@"I search for property by the pharse '(.*)'")]
        public void WhenISearchForPropertyByThePharse(string Property_Name)
        {
            _filterDriver.Filter(Property_Name);
        }

        
        [Then(@"User should see the list name of project")]
        public void ThenUserShouldSeeTheListNameOfProject(Table ShownProperties)
        {
            _filterDriver.ShouldShowProjects(ShownProperties);
        }


    }
}
