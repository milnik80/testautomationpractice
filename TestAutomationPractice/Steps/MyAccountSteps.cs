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

        private readonly PersonData personData;

        public MyAccountSteps(PersonData personData)
        {
            this.personData = personData;
        }

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

        [Given(@"initiates a flow for creating account")]
        public void GivenInitiatesAFlowForCreatingAccount()
        {
            LogInPage ap = new LogInPage(Driver);
            ut.EnterTextInElement(ap.email, ut.GenerateRandomEmail());
            ut.ClickOnElement(ap.createAcc);
        }

            [Given(@"user enters all required personal details")]
            
        public void GivenUserEntersAllRequiredPersonalDetails()
        {
                 SignUpPage sup = new SignUpPage(Driver);
                 ut.EnterTextInElement(sup.firstName, TestConstans.FirstName);
                 ut.EnterTextInElement(sup.lastName, TestConstans.LastName);
                 personData.FullName = TestConstans.FirstName + " " + TestConstans.LastName;
                 ut.EnterTextInElement(sup.password, TestConstans.Password);
                 ut.EnterTextInElement(sup.address, TestConstans.Address);
                 ut.EnterTextInElement(sup.city, TestConstans.City);
                 ut.DropdownSelect(sup.state, TestConstans.State);
                 ut.EnterTextInElement(sup.zipCode, TestConstans.ZipCode);
                 ut.EnterTextInElement(sup.phone, TestConstans.MobilePhone);
            }

        [When(@"user submits the sign up form")]
        public void WhenUserSubmitsTheSignUpForm()
        {
            SignUpPage sup  = new SignUpPage(Driver);
            ut.ClickOnElement(sup.registerBtn);
        }

        [Then(@"users full name is displayed")]
        public void ThenUsersFullNameIsDisplayed()
        {
            Assert.True(ut.TextPresentInElement(personData.FullName), "Users full name is not displayed in the header");
        }

    }
}
