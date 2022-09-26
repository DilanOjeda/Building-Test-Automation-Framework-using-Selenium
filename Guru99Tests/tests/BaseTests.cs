using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibs.Implementation;
using Guru99Application.Pages;
using NUnit.Framework;

namespace Guru99Tests.tests
{
    public class BaseTests
    {
        public CommonDriver CmnDriver;
        public LoginPage loginPage;
        string url = "http://demo.guru99.com/v4";

        [SetUp]
        public void Setup()
        {
            CmnDriver = new CommonDriver("chrome");
            CmnDriver.NavigateToFirstUrl(url);
            loginPage = new LoginPage(CmnDriver.Driver);
        }

        [TearDown]
        public void TearDown()
        {
            CmnDriver.CloseAllBrowsers();
        }

    }
}