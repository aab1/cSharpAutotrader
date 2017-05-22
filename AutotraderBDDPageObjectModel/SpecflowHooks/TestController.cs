using AutotraderBDDPageObjectModel.ExtentReport;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutotraderBDDPageObjectModel.SpecflowHooks
{
    public static class TestController
    {
        private static ExtentReports _extent;
        private static ExtentTest _test;

        public static void InitialiseReport()
        {
            _extent = ExtentManager.Instance;
            _test = _extent.StartTest(TestContext.CurrentContext.Test.Name);
            _test.Log(LogStatus.Info, String.Format("{0} is up and running", TestContext.CurrentContext.Test.Name));
        }


        public static void ExtentTearDown()
        {
            try
            {
                ExtentReportCaptureTearDown();

            }
            catch (IOException ioException)
            {
                //Helper.MsgOutput("Report could not be written to specified location", ioException.ToString());
            }
        }

        public static void ExtentLogScreenshotLocation(string path)
        {
            _test.Log(LogStatus.Info, "The screenshot of the failed page is attached below: " + _test.AddScreenCapture(path));
        }

        public static void ExtentLogPassInformation(string step)
        {
            var text = String.Format("{0} step has been successfully completed", step);
            _test.Log(LogStatus.Pass, text);
        }
        public static void ExtentLogFailInformation(string step, string message)
        {
            var text = String.Format("{0} failed because of the following error message {1}", step, message);
            _test.Log(LogStatus.Fail, text);
        }

        public static void ExtentLogFatalInformation()
        {
            const string text = "Unable to create a new Remote WebDriver instance";
            _test.Log(LogStatus.Fatal, text);
        }

        public static void ExtentLogInformation(string value, string enteredOrRetrieved)
        {
            var text = String.Format("{0} has been successfully {1}", value, enteredOrRetrieved);
            _test.Log(LogStatus.Info, text);
        }

        public static void ExtentLogFeatureInformation(string value)
        {
            var text = String.Format("{0} has finished running", value);
            _test.Log(LogStatus.Info, text);
        }

        public static void ExtentLogInformation()
        {
            const string text = "Step successfully completed";
            _test.Log(LogStatus.Info, text);
        }

        public static void ExtentIgnoreInformation(string message)
        {
            _test.Log(LogStatus.Info, message);
        }

        public static void ExtentReportCaptureTearDown()
        {
            var status = TestContext.CurrentContext.Result.Status;

            LogStatus logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = LogStatus.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = LogStatus.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = LogStatus.Skip;
                    break;
                default:
                    logstatus = LogStatus.Pass;
                    break;
            }

            _test.Log(logstatus, "Test ended with " + logstatus);

            _extent.EndTest(_test);
            _extent.Flush();
        }
    }
}
