using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutotraderBDDPageObjectModel.AutotraderPages
{
    public class AutotraderHomePage : BaseClass
    {
        private IWebElement logo;
        private IWebElement postcode;
        private IWebElement distance;
        private IWebElement carMake;
        private IWebElement submitButton;
        public void AndIAmOnAutotraderHomePage()
        {
            logo = GetElementByClassName("site-header__logo");

            Assert.True(logo.Displayed, "Autotrader is not displayed");
        }

        public void WhenIEnteredValidPostcode()
        {
            postcode = GetElementById("postcode");
            postcode.Clear();
            postcode.SendKeys("M34 5JD");
        }
//paramerised method
        public void WhenIEnteredValidPostcode(string postalCode)
        {
            postcode = GetElementById("postcode");
            postcode.Clear();
            postcode.SendKeys(postalCode);
        }

        public void AndISelectDistanceToPostcode()
        {
            distance = GetElementById("radius");
            SelectByVisibleText(distance, "Within 55 miles");
        }

        public void AndISelectDistanceToPostcode(string inputDistance)
        {
            distance = GetElementById("radius");
            SelectByVisibleText(distance, inputDistance);
        }



        public void AndISelectACarMake()
        {
            carMake = GetElementById("searchVehiclesMake");
            SelectByValue(carMake, "AUDI");
        }

        public void AndISelectACarMake(string make)
        {
            carMake = GetElementById("searchVehiclesMake");
            SelectByValue(carMake, make.ToUpper());
        }

        public AutotraderSearchResultPage AndIClickOnSearchACarButton()
        {
            submitButton = GetElementById("search");
            submitButton.Click();
            return new AutotraderSearchResultPage();
        }
    }
}
