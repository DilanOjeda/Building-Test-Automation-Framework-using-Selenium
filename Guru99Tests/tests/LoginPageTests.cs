using CommonLibs.Implementation;
using NUnit.Framework;

namespace Guru99Tests
{
    public class LoginPageTests
    {
        [SetUp]
        public void SetUp()
        {
            
        }

        [Test]
        public void Test1()
        {
            CommonDriver CmnDriver = new CommonDriver("chrome");
            CmnDriver.NavigateToFirstUrl("http://demo.guru99.com/v4");
        }
    }
}