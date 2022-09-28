using AventStack.ExtentReports;
using Guru99Tests.tests;
using NUnit.Framework;

namespace Guru99Tests
{
    public class LoginPageTests : BaseTests
    {
        [Test]
        public void VerifyLoginTest()
        {
            extentReportsUtils.CreateATestCase("Verify Login Test");
            extentReportsUtils.AddTestLog(Status.Info, "Performing Login");
            string expectedTitle = "Guru99 Bank Home Page s";
            string actualTitle = CmnDriver.GetPageTitle();

            loginPage.LoginToApplication("mngr442894", "ebYjYre");

            Assert.AreEqual(expectedTitle, actualTitle);
        }
    }
}