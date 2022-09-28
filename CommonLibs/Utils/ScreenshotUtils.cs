using System;
using System.IO;
using OpenQA.Selenium;

namespace CommonLibs.Utils
{
    public class ScreenshotUtils
    {
        ITakesScreenshot camera;

        public ScreenshotUtils(IWebDriver driver)
        {
            camera = (ITakesScreenshot) driver;
        }

        public void CaptureAndSaveScreenshot(string fileName)
        {
            _ = fileName.Trim();
            if (File.Exists(fileName))
            {
                throw new Exception("FileName already exists: " + fileName);
            }

            Screenshot screenshot = camera.GetScreenshot();
            screenshot.SaveAsFile(fileName);
        }
    }
}