using FrameworkEpam.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;

namespace FrameworkEpam.Utils
{
    public static class Screenshoter
    {
        public static void TakeScreenshot()
        {
            string screenshotName = $"{DateTime.Now.ToString("dd-MM-yy HH.mm")} - {TestContext.CurrentContext.Test.MethodName}.png";
            string screenshotPath = ConfigurationManager.Configuration.ScreenshotsPath;

            if (!Directory.Exists(screenshotPath))
            {
                Directory.CreateDirectory(screenshotPath);
            }

            ((ITakesScreenshot)DriverSingleton.Driver)
               .GetScreenshot().
               SaveAsFile(screenshotPath + screenshotName, ScreenshotImageFormat.Png);
        }
    }
}
