using TechTalk.SpecFlow;
using PPCRental.AcceptanceTests.Driver.Property;
using System;

namespace PPCRental.AcceptanceTests.Step
{
    [Binding, Scope (Tag ="automated")]
     class ViewDetails
    {
        private readonly PropertyDetailsDriver _propertyDriver;
            
        public ViewDetails(PropertyDetailsDriver driver)
        {
            _propertyDriver = driver;
        }

        [Given(@"the following projects")]
        public void GivenTheFollowingProjects(Table givenProperties)
        {
            _propertyDriver.InsertProjectToDB(givenProperties);
        }


        [When(@"I open the details of '(.*)'")]
        public void WhenIOpenTheDetailsOf(string property)
        {
            _propertyDriver.OpenPropertyDetails(property);
        }

        [Then(@"the project details should show")]
        public void ThenTheProjectDetailsShouldShow(Table ShowProperty)
        {
            _propertyDriver.ShowDetailProject(ShowProperty);
        }

    }
}
