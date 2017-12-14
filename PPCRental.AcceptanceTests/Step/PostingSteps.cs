using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPCRental.Models;
using PPCRental.AcceptanceTests.Driver.Property;
using PPCRental.AcceptanceTests.Driver.Home;
using TechTalk.SpecFlow;

namespace PPCRental.AcceptanceTests.Step
{
    [Binding, Scope(Tag = "automated")]
    class PostingSteps
    {
        private PostPropertyDriver _postDriver;

        [Given(@"User have an exist account following information below")]
        public void GivenUserHaveAnExistAccountFollowingInformationBelow(Table table)
        {
            _postDriver.insertUserInfomationToDB(table);
        }

        [Given(@"User have been logged on website with '(.*)'")]
        public void GivenUserHaveBeenLoggedOnWebsiteWith(Table table)
        {
            _postDriver.checkLogged(table);
        }

        [Given(@"User click on button in sidebar")]
        public void GivenUserClickOnButtonInSidebar()
        {
            _postDriver.navigatePosting();
        }

        [Given(@"User input information of property")]
        public void GivenUserInputInformationOfProperty(Table table)
        {
            _postDriver.inputPropertyInfo(table);
        }

        [When(@"I press ""(.*)"" button")]
        public void WhenIPressButton(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The System will check and save information of property")]
        public void ThenTheSystemWillCheckAndSaveInformationOfProperty()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"User should see view Ìndex of Agency")]
        public void ThenUserShouldSeeViewIndexOfAgency()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
