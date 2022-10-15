using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TestAutomationPractice.Helper;
using TestAutomationPractice.Pages;

namespace TestAutomationPractice.Features
{
    [Binding]
    public class MyAccountSteps : Base

    {
        Utilities ut = new Utilities(Driver);
        HomePage hp = new HomePage(Driver);

        [Given(@"User open login page")]
        public void GivenUserOpenLoginPage()
        {
            ut.ClickOnElement(hp.signIn);
        }
        
        [Given(@"enter correct credentials")]
        public void GivenEntersCorrectCredentials()
        {
            LogInPage ap = new LogInPage(Driver);
            ut.EnterTextInElement(ap.username, TestConstans.Username);
            ut.EnterTextInElement(ap.password, TestConstans.Password);
        }
        
        [When(@"user submits the form")]
        public void WhenUserSubmitsTheForm()
        {
            LogInPage ap = new LogInPage(Driver);
            ut.ClickOnElement(ap.signinBtn);
        }
        
        [Then(@"user will be logged in")]
        public void ThenUserWillBeLoggedIn()
        {
            MyAccountPage mp = new MyAccountPage(Driver);
            Assert.True(ut.ElementIsDisplayed(mp.signOutBtn), "User is not logged in");
        }
    }
}
