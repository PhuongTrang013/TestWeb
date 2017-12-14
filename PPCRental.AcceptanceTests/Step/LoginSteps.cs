using System;
using TechTalk.SpecFlow;
using PPCRental;
using PPCRental.AcceptanceTests.Driver.Home;
using PPCRental.AcceptanceTests.Driver.User;
using PPCRental.UITests.Selenium.Support;

namespace PPCRental.AcceptanceTests.Step
{
    [Binding, Scope(Tag ="automated")]
    public class LoginSteps
    {
        private readonly UserDriver _userDriver;
        string _username;
        string _password;
        
        [Given(@"I am at Home page")]
        public void GivenIAmAtHomePage()
        {
            //ScenarioContext.Current.Pending();
            //Viết 
            HomeDriver _homeDriver = new HomeDriver();
            _homeDriver.Navigate();
            
        }

        [Given(@"Navigate to login page")]
        public void GivenNavigateToLoginPage()
        {
            _userDriver.Navigate();
        }

        [When(@"I input the following information")]
        public void WhenIInputTheFollowingInformation(Table User)
        {
            var dictionary = TableExtensions.ToDictionary(User);

            _username = dictionary["Email"].ToString();
            _password = dictionary["Password"].ToString();
        }

        [When(@"I click on Dangnhap Button")]
        public void WhenIClickOnDangnhapButton()
        {
            _userDriver.Login(_username, _password);
        }

        [Then(@"I should see successfull message")]
        public void ThenIShouldSeeSuccessfullMessage()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
