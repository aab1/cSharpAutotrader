using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutotraderBDDPageObjectModel.AutotraderPages
{
    public class AutotraderSearchResultPage :BaseClass
    {
        private IList<IWebElement> searchResult;

        public void ThenIAmOnSearchResultPage()
        {
            searchResult = GetElementsByClassName("search-page__result");
            Assert.True(searchResult.Count > 0, "No Result is displayed");
        }

        public void ThenTheCarSearchedForIsDisplayedOnSearchResultpage(string carMake)
        {
            searchResult = GetElementsByClassName("gui-test-search-result-link");
            
            foreach (var search in searchResult)
            {
                var searchText = search.Text.ToLower();

                Assert.True(searchText.Contains(carMake.ToLower()), String.Format("The car text that was wrong is {0}", searchText));
            }
        }

        public AutotraderResultPage AndIClickedOnOneOfTheResultDisplayed()
        {
            Random rand = new Random();
            //generate a random number btween 1 and 10
            int randomNumber = rand.Next(1, 10);

            //Click on a car from the result returned that falls to the index of the random number  
            searchResult = GetElementsByClassName("listing-fpa-link");
            searchResult.ElementAt(randomNumber).Click();

            //when a car is clicked from the results a new page opens which I call AutotraderResultPage
            return new AutotraderResultPage();
        }
    }
}
