using OpenQA.Selenium;

namespace Guru99Application.Pages
{
    public class LoginPage : BasePage
    {
        private IWebDriver _driver;
        private IWebElement usernameInput => _driver.FindElement(By.Name("uid"));
        private IWebElement passwordInput => _driver.FindElement(By.Name("password"));
        private IWebElement loginButton => _driver.FindElement(By.Name("btnLogin"));

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void LoginToApplication(string username, string password)
        {
            cmnElement.SetText(usernameInput, username);
            cmnElement.SetText(passwordInput, password);
            cmnElement.ClickElement(loginButton);
        }

    }
}