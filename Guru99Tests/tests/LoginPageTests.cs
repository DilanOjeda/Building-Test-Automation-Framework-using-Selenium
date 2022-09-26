using Guru99Tests.tests;
using NUnit.Framework;

namespace Guru99Tests
{
    public class LoginPageTests : BaseTests
    {
        [Test]
        public void VerifyLoginTest()
        {
            loginPage.LoginToApplication("mngr288890", "mngr288890");
        }
    }
}