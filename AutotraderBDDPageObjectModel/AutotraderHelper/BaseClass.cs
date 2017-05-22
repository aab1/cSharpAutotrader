using AutotraderBDDPageObjectModel.AutotraderPages;
using AutotraderBDDPageObjectModel.SpecflowHooks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutotraderBDDPageObjectModel
{
   public class BaseClass
    {
        public static IWebDriver driver { get; set; }
        private static SelectElement select;

        static BaseClass()
        {
            driver = null;
            select = null;
        }
        public static void LaunchBrowser(string browser)
        {
            switch (browser)
            {
                case "Chrome":
                    driver = InitChrome();
                    break;
                case "Firefox":
                    driver = InitFirefox();
                    break;
                default:
                    Console.WriteLine(browser + "Is not recognised. So, Firefox is lauched instead");
                    driver = InitFirefox();
                    break;
            }
            driver.Manage().Window.Maximize();
        }
        private static IWebDriver InitChrome()
        {
            driver = new ChromeDriver();

            return driver;
        }

        private static IWebDriver InitFirefox()
        {
            driver = new FirefoxDriver();

            return driver;
        }

        public static void LaunchUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static void CloseBrowser()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Close();
            driver.Quit();
        }
        public static void SelectByIndex(IWebElement element, int index)
        {
            select = new SelectElement(element);
            select.SelectByIndex(index);
        }
        public static void SelectByVisibleText(IWebElement element, string text)
        {
            select = new SelectElement(element);
            select.SelectByText(text);
        }
        public static void SelectByValue(IWebElement element, string value)
        {
            select = new SelectElement(element);
            select.SelectByValue(value);
        }

        public static IWebElement GetElementById(string id)
        {
            By locator = By.Id(id);
            return GetElement(locator);
        }
        public static IWebElement GetElementByClassName(string className)
        {
            By locator = By.ClassName(className);
            return GetElement(locator);
        }
        public static IWebElement GetElementByCssSelector(string cssSelector)
        {
            By locator = By.CssSelector(cssSelector);
            return GetElement(locator);
        }
        public static IWebElement GetElementByName(string name)
        {
            By locator = By.Name(name);
            return GetElement(locator);
        }
        public static IWebElement GetElementByXpath(string xpath)
        {
            By locator = By.XPath(xpath);
            return GetElement(locator);
        }
        public static IWebElement GetElementByTagName(string tagname)
        {
            By locator = By.TagName(tagname);
            return GetElement(locator);
        }
        //####################################################################
        public static IList<IWebElement> GetElementsById(string id)
        {
            By locator = By.Id(id);
            return GetElements(locator);
        }
        public static IList<IWebElement> GetElementsByClassName(string className)
        {
            By locator = By.ClassName(className);
            return GetElements(locator);
        }
        public static IList<IWebElement> GetElementsByCssSelector(string cssSelector)
        {
            By locator = By.CssSelector(cssSelector);
            return GetElements(locator);
        }
        public static IList<IWebElement> GetElementsByName(string name)
        {
            By locator = By.Name(name);
            return GetElements(locator);
        }
        public static IList<IWebElement> GetElementsByXpath(string xpath)
        {
            By locator = By.XPath(xpath);
            return GetElements(locator);
        }
        public static IList<IWebElement> GetElementsByTagName(string tagname)
        {
            By locator = By.TagName(tagname);
            return GetElements(locator);
        }
        private static IWebElement GetElement(By locator)
        {
            IWebElement element = null;
            int tryCount = 0;
            while (element == null)
            {
                try
                {
                    element = driver.FindElement(locator);
                }
                catch (Exception e)
                {
                    if (tryCount == 3)
                    {
                        SaveScreenshot();
                        throw e;
                    }
                }
                var waitTime = new TimeSpan(0, 0, 2);
                Thread.Sleep(waitTime);

                tryCount++;
            }
            Console.WriteLine("{0} is now retrieved", element.ToString());
            return element;
        }

        private static IList<IWebElement> GetElements(By locator)
        {
            IList<IWebElement> element = null;
            int tryCount = 0;
            while (element == null)
            {
                try
                {
                    element = driver.FindElements(locator);
                }
                catch (Exception e)
                {
                    if (tryCount == 3)
                    {
                        SaveScreenshot();
                        throw e;
                    }
                }
                var waitTime = new TimeSpan(0, 0, 2);
                Thread.Sleep(waitTime);

                tryCount++;
            }
            Console.WriteLine("{0} is now retrieved", element.ToString());
            return element;
        }

        private static Screenshot TakeScreenshot()
        {
            return ((ITakesScreenshot)driver).GetScreenshot();
        }

        public static string ScreenShotLocation()
        {
            var dateNow = DateTime.Now.Date.ToString().Replace(@"/", "").Replace(@":", "");
            dateNow = dateNow.Substring(0, 8);

            var timeNow = DateTime.Now.TimeOfDay.ToString().Replace(@"/", "").Replace(@" ", "").Replace(@":", "").Replace(@".", "");
            timeNow = timeNow.Substring(0, 6);

            //Change the location(i.e C:\\Screenshots) to anydrive as required provided you want others to see the screenshot e.g f drive
            return String.Format("C:\\Screenshots\\{0}_{1}.png", dateNow, timeNow);
        }
        private static void SaveScreenshot()
        {
            try
            {
                
                var location = ScreenShotLocation();
                var screenshot = TakeScreenshot();

                // screenshot.SaveAsFile(fileName,System.Drawing.Imaging.ImageFormat.Png);
                screenshot.SaveAsFile(location, ScreenshotImageFormat.Png);
                TestController.ExtentLogScreenshotLocation(location);
            }
            catch (Exception e)
            {
                Console.Write(String.Format("Screenshot cannot be saved because {0}", e));
            }
        }

        public static AutotraderHomePage GivenINavigateToAutotraderHomepage()
        {
            LaunchUrl("http://www.autotrader.co.uk/");

            return new AutotraderHomePage();
        }
    }
}
