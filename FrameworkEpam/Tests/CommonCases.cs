using FrameworkEpam.Logger;
using NUnit.Framework;
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
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--ignore-certificate-errors");
            options.AddArguments("--ignore-ssl-errors");

            _driver = new ChromeDriver(options);

            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            Driver.Navigate().GoToUrl(_url);
        }

        [OneTimeTearDown]
        public virtual void OneTimeTearDown()
        {
            Driver.Quit();
        }
    }
}
