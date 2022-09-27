using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibs.Implementation;
using Guru99Application.Pages;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Guru99Tests.tests
{
    public class BaseTests
    {
        public CommonDriver CmnDriver;
        public LoginPage loginPage;
        private IConfigurationRoot _configuration;
        string _url;
        string _currentProjectDirectory;

        [OneTimeSetUp]
        public void PreSetup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            _currentProjectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            _configuration = new ConfigurationBuilder().AddJsonFile(_currentProjectDirectory + "/config/appSetting.json").Build();
        }

        [SetUp]
        public void Setup()
        {
            string browserType = _configuration["browserType"];
            CmnDriver = new CommonDriver(browserType);
            _url = _configuration["baseUrl"];
            CmnDriver.NavigateToFirstUrl(_url);
            loginPage = new LoginPage(CmnDriver.Driver);
        }

        [TearDown]
        public void TearDown()
        {
            CmnDriver.CloseAllBrowsers();
        }

    }
}