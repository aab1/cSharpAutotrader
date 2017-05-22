using AutotraderBDDPageObjectModel.AutotraderPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace AutotraderBDDPageObjectModel.Steps
{
    [Binding]
    public sealed class SearchSteps
    {
        private AutotraderHomePage homepage;
        private AutotraderSearchResultPage searchResultPage;
        private AutotraderResultPage resultPage;

        [Given(@"I navigate to Autotrader")]
        public void GivenINavigateToAutotrader()
        {
            homepage = BaseClass.GivenINavigateToAutotraderHomepage();
            homepage.AndIAmOnAutotraderHomePage();
        }

        [When(@"search for a car")]
        public void WhenSearchForACar()
        {
            homepage.WhenIEnteredValidPostcode();
            homepage.AndISelectDistanceToPostcode();
            homepage.AndISelectACarMake();
            searchResultPage = homepage.AndIClickOnSearchACarButton();
        }

        [Then(@"the result is displayed")]
        public void ThenTheResultIsDisplayed()
        {
            searchResultPage.ThenIAmOnSearchResultPage();
            
        }

        [Then(@"I can view a selected car")]
        public void ThenICanViewASelectedCar()
        {
            resultPage = searchResultPage.AndIClickedOnOneOfTheResultDisplayed();
            resultPage.AndIAmOnResultPageForCar();
        }

        [When(@"I search for a car ""(.*)"" from a ""(.*)"" of range ""(.*)""")]
        public void WhenISearchForACarFromAOfRange(string make, string postcode, string distance)
        {
            homepage.WhenIEnteredValidPostcode(postcode);
            homepage.AndISelectDistanceToPostcode(distance);
            homepage.AndISelectACarMake(make);
            searchResultPage = homepage.AndIClickOnSearchACarButton();
        }

        [Then(@"the result is displayed contains ""(.*)""")]
        public void ThenTheResultIsDisplayedContains(string make)
        {
            searchResultPage.ThenTheCarSearchedForIsDisplayedOnSearchResultpage(make);
        }


    }
}
