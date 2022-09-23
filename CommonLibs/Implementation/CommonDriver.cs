using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace CommonLibs.Implementation
{
    public class CommonDriver
    {
        public IWebDriver Driver {get; private set; }
        public int PageLoadTime { private get => pageLoadTime; set => pageLoadTime = value; }

        private  int pageLoadTime;

        private int elementDetectionTimeout;

        public CommonDriver(string browserType)
        {
            browserType = browserType.Trim();
            pageLoadTime = 60;
            elementDetectionTimeout = 10;

            if (browserType.Equals("chrome"))
            {
                Driver = new ChromeDriver();
            } else if(browserType.Equals("edge"))
            {
                Driver = new EdgeDriver();
            } else {
                throw new Exception("Invalid Browser Type" + browserType);
            }
        }

        public void NavigateToFirstUrl(string url)
        {
            url = url.Trim();
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadTime);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(elementDetectionTimeout);
            Driver.Url = url;
        }
    }
}