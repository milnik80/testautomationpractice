using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TestAutomationPractice.Helper;
using TestAutomationPractice.Pages;

namespace TestAutomationPractice.Steps
{
    [Binding]
    public class ContactusSteps : Base
    {
        Utilities ut = new Utilities(Driver);
        HomePage hp = new HomePage(Driver);

        [Given(@"user open contact us page")]
        public void GivenUserOpenContactUsPage()
        {
            ut.ClickOnElement(hp.contactus);
        }
        
        [When(@"user fill in all required fields with '(.*)' heading and '(.*)' message")]
        public void WhenUserFillInAllRequiredFieldsWithHeadingAndMessage(string heading, string message)
        {
            ContactUsPage cup = new ContactUsPage(Driver);
            ut.DropdownSelect(cup.subjectHeading,heading);
            ut.EnterTextInElement(cup.contactEmail,ut.GenerateRandomEmail());
            ut.EnterTextInElement(cup.message, message);
           
        }
        
        [When(@"User submits the form")]
        public void WhenUserSubmitsTheForm()
        {
            ContactUsPage cup = new ContactUsPage(Driver);
            ut.ClickOnElement(cup.sendBtn);
        }
        
        [Then(@"message '(.*)' is presented to do user")]
        public void ThenMessageIsPresentedToDoUser(string succssesMessage)
        {
            ContactUsPage cup = new ContactUsPage(Driver);
            Assert.That(ut.ReturnTextFromElement(cup.successMessage),Is.EqualTo(succssesMessage),"Message was not send to customer service");
        }
    }
}
