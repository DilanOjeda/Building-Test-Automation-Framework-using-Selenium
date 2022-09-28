using System.IO;
using System;
using CommonLibs.Implementation;
using Guru99Application.Pages;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using CommonLibs.Utils;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;

namespace Guru99Tests.tests
{
    public class BaseTests
    {
        public CommonDriver CmnDriver;
        public LoginPage loginPage;
        private IConfigurationRoot _configuration;
        public ExtentReportUtils extentReportsUtils;
        ScreenshotUtils screenshot;
        string _url;
        string _currentProjectDirectory;
        string _currentSolutionDirectory;
        string _reportGileName;

        [OneTimeSetUp]
        public void PreSetup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            _currentProjectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            _currentSolutionDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
            _reportGileName = _currentSolutionDirectory + "/reports/guru99TestReport.html";
            extentReportsUtils = new ExtentReportUtils(_reportGileName);
            _configuration = new ConfigurationBuilder().AddJsonFile(_currentProjectDirectory + "/config/appSetting.json").Build();
        }

        [SetUp]
        public void Setup()
        {
            extentReportsUtils.CreateATestCase("Setup");
            string browserType = _configuration["browserType"];
            CmnDriver = new CommonDriver(browserType);
            extentReportsUtils.AddTestLog(Status.Info, "Browser Type: " + browserType);
            _url = _configuration["baseUrl"];
            extentReportsUtils.AddTestLog(Status.Info, "Base Url: " + _url);
            CmnDriver.NavigateToFirstUrl(_url);

            loginPage = new LoginPage(CmnDriver.Driver);

            screenshot = new ScreenshotUtils(CmnDriver.Driver);
        }

        [TearDown]
        public void TearDown()
        {
            string currentExecutionTime = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'-'mm'-'ss");
            string screenshotFileName = $"{_currentSolutionDirectory}/screenshots/test-{currentExecutionTime}.jpeg";
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
            {
                extentReportsUtils.AddTestLog(Status.Fail, "One or more step failed");
                screenshot.CaptureAndSaveScreenshot(screenshotFileName);
                extentReportsUtils.AddScreenshot(screenshotFileName);
            }
            CmnDriver.CloseAllBrowsers();
            // CmnDriver.CloseBrowser();
        }

        [OneTimeTearDown]
        public void PostCleanUp()
        {
            extentReportsUtils.flushReport();
        }

    }
}