using FrameworkEpam.Driver;
using FrameworkEpam.Logger;
using FrameworkEpam.Utils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Serilog;
using System;

namespace FrameworkEpam.Tests
{
    public abstract class CommonCases
    {
        protected static IWebDriver _driver;
        public static IWebDriver Driver => _driver;

        private string _url;

        public CommonCases(string url)
        {
            new LoggerManager();
            _url = url;

            var browser = TestContext.Parameters.Get("Browser");
        }

        [OneTimeSetUp]
        public virtual void OneTimeSetUp()
        {
            _driver = DriverSingleton.Driver;

            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            Driver.Navigate().GoToUrl(_url);
        }

        [TearDown]
        public virtual void TearDown()
        {
            bool havePassed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            if (havePassed) return;

            Screenshoter.TakeScreenshot();
        }

        [OneTimeTearDown]
        public virtual void OneTimeTearDown()
        {
            LoggerManager.StopLogger();
            Driver.Quit();
        }

    }
}
