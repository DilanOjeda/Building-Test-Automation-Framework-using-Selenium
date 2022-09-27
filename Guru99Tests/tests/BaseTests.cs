using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibs.Implementation;
using Guru99Application.Pages;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using CommonLibs.Utils;
using AventStack.ExtentReports;

namespace Guru99Tests.tests
{
    public class BaseTests
    {
        public CommonDriver CmnDriver;
        public LoginPage loginPage;
        private IConfigurationRoot _configuration;
        public ExtentReportUtils extentReportsUtils;
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
        }

        [TearDown]
        public void TearDown()
        {
            CmnDriver.CloseAllBrowsers();
        }

        [OneTimeTearDown]
        public void PostCleanUp()
        {
            extentReportsUtils.flushReport();
        }

    }
}