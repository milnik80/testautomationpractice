using System;
using TechTalk.SpecFlow;
using TestAutomationPractice.Pages;
using NUnit.Framework;
using TestAutomationPractice.Helper;

namespace TestAutomationPractice.Steps
{
    [Binding]
    public class SearchSteps : Base
    {
        Utilities ut = new Utilities(Driver);
        HomePage hp = new HomePage(Driver);

        [Given(@"user enters '(.*)'search term")]
        public void GivenUserEntersTerm(string term)
        {
            ut.EnterTextInElement(hp.searchField, term);
        }

        [When(@"user submits the search")]
        public void WhenUserSubmitsTheSearch()
        {
            ut.ClickOnElement(hp.searchBtn);
        }

        [Then(@"results for '(.*)'search term are displayed")]
        public void ThenResultsForDressSearchTermAreDisplayed(string term)
        {
           
           SearchResultsPage srp = new SearchResultsPage(Driver);
           Assert.That(ut.ReturnTextFromElement(srp.searchResults), Does.Contain(term));
           
        }
    }
}
