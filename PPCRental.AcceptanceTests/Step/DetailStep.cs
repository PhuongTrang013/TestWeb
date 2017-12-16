using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPCRental.Models;
using TechTalk.SpecFlow;
using PPCRental.AcceptanceTests.Driver.Property;

namespace PPCRental.AcceptanceTests.Step
{
    [Binding, Scope(Tag = "automated")]
    class DetailStep
    {
        private readonly PropertyDetailsDriver _propertyDriver;

        public DetailStep(PropertyDetailsDriver driver)
        {
            _propertyDriver = driver;
        }

        [Given(@"the following projects")]
        public void GivenTheFollowingProjects(Table givenProperties)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I open the details of '(.*)'")]
        public void WhenIOpenTheDetailsOf(string property)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the project details should show")]
        public void ThenTheProjectDetailsShouldShow(Table ShowProperty)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
