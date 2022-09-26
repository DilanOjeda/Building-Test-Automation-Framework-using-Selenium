using Guru99Tests.tests;
using NUnit.Framework;

namespace Guru99Tests
{
    public class LoginPageTests : BaseTests
    {
        [Test]
        public void VerifyLoginTest()
        {
            string expectedTitle = "Guru99 Bank Home Page";
            string actualTitle = CmnDriver.GetPageTitle();

            loginPage.LoginToApplication("mngr442894", "ebYjYre");

            Assert.AreEqual(expectedTitle, actualTitle);
        }
    }
}