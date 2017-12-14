using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using PPCRental.Models;
using TechTalk.SpecFlow;
using PPCRental.UITests.Selenium.Support;


namespace PPCRental.UITests.Selenium
{
    [Binding, Scope(Tag = "web")]
    public class LoginSteps : SeleniumStepsBase
    {
        //private readonly HomeDriver _result;
        string _username;

        [Given(@"I am at Home page")]
        public void GivenIAmAtHomePage()
        {
            Browser.NavigateTo("Home");

        }

        [Given(@"Navigate to login page")]
        public void GivenNavigateToLoginPage()
        {
            Browser.NavigateTo("Agency/PropertyAgency");
        }

        [When(@"I input the following information")]
        public void WhenIInputTheFollowingInformation(Table User)
        {
            var dictionary = TableExtensions.ToDictionary(User);

            _username = dictionary["Email"].ToString();
            string _password = dictionary["Password"].ToString();

            Browser.SetTextBoxValue("email", _username);
            Browser.SetTextBoxValue("password", _password);
        }

        [When(@"I click on Dangnhap Button")]
        public void WhenIClickOnDangnhapButton()
        {
            Browser.ClickButton("login");
        }

        [Then(@"I should see successfull message")]
        public void ThenIShouldSeeSuccessfullMessage()
        {
            //Arrange
            string expectedTitle = "Xin chào " + _username;

            //Act
            string actualTitle = Browser.FindElement(By.XPath("//*[@id='navbarResponsive']/ul[3]/h2")).Text;

            //Assert
            true.Equals(actualTitle.Contains(expectedTitle));
        }
    }
}
