using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace CommonLibs.Utils
{
    public class ExtentReportUtils
    {
        private ExtentHtmlReporter _extentHtmlReporter;
        private ExtentReports _extentReports;
        private ExtentTest _extentTest;

        public ExtentReportUtils(string htmlReportFileName)
        {
            _extentHtmlReporter = new ExtentHtmlReporter(htmlReportFileName);
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(_extentHtmlReporter);
        }

        public void CreateATestCase(string testCaseName)
        {
            _extentTest = _extentReports.CreateTest(testCaseName);
        }

        public void AddTestLog(Status status, string comment)
        {
            _extentTest.Log(status, comment);
        }

        public void flushReport()
        {
            _extentReports.Flush();
        }
    }
}