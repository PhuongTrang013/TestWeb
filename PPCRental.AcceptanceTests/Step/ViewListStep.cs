using System;
using TechTalk.SpecFlow;
using PPCRental;
using PPCRental.AcceptanceTests.Driver.Home;
using PPCRental.AcceptanceTests.Driver.ViewProjects;
using PPCRental.UITests.Selenium.Support;


namespace PPCRental.AcceptanceTests.Step
{
    [Binding, Scope(Tag = "web")]
    class ViewListStep
    {
        private readonly HomeDriver _homdriver;
        private readonly ViewprojectDriver _viewprojectdriver;

        [Given(@"I am at home page")]
        public void GivenIAmAtHomePage(Table table)
        {
            _homdriver.Navigate();
        }

        [When(@"I click DUAN")]
        public void WhenIClickDUAN()
        {
            _viewprojectdriver.Click();
        }

        [Then(@"I will see list of project")]
        public void ThenIWillSeeListOfProject()
        {
            
            _viewprojectdriver.ShowProjects(expectedProjects.Rows.Select(r => r["Title"]));
        }

    }
}
