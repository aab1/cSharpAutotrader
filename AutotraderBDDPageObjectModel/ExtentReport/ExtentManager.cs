using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutotraderBDDPageObjectModel.ExtentReport
{
   internal static class ExtentManager
    {
        private const string DefaultLogFolder = "C:\\TestAutomation\\AutomationReport";

        private static readonly ExtentReports _Instance =
            new ExtentReports(SetReportLocation(), DisplayOrder.OldestFirst);

        static ExtentManager() { }

        public static ExtentReports Instance
        {
            get
            {
                return _Instance;
            }
        }
        private static string SetReportLocation()
        {
            var reportLocation = DefaultLogFolder;

           
            if (!Directory.Exists(reportLocation))
            {
                Directory.CreateDirectory(reportLocation);
            }
            var dateNow = DateTime.Now.Date.ToString().Replace(@"/", "").Replace(@":", "");
            dateNow = dateNow.Substring(0, 8);

            var timeNow = DateTime.Now.TimeOfDay.ToString().Replace(@"/", "").Replace(@" ", "").Replace(@":", "").Replace(@".", "");
            timeNow = timeNow.Substring(0, 6);
            //  String.Format("C:\\Screenshots\\{0}_{1}.png", dateNow, timeNow);
            //const string report = @"\\TestReport.html";
             string report = String.Format("\\TestReport{0}_{1}.html", dateNow, timeNow);
            var fullPath = reportLocation + report;

           

            return fullPath;
        }
    }
}
