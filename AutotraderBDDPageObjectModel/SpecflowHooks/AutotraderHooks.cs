using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace AutotraderBDDPageObjectModel.SpecflowHooks
{
    [Binding]
    public sealed class AutotraderHooks : BaseClass
    {
       

        [BeforeScenario]
        public void BeforeScenario()
        {
            LaunchBrowser("Chrome");
            TestController.InitialiseReport();
        }

        [BeforeStep]
        public static void BeforeStep()
        {

        }
        [AfterStep]
        public static void AfterStep()
        {
            var step = ScenarioContext.Current.StepContext.StepInfo.Text;
            if (ScenarioContext.Current.TestError == null)
            {
                //the steps on the report are sent from here
                TestController.ExtentLogInformation(step, "Retrieved");
                return;
            }

            TestController.ExtentLogFailInformation(driver.Title, ScenarioContext.Current.TestError.Message);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            CloseBrowser();
            TestController.ExtentTearDown();
        }
    }
}
