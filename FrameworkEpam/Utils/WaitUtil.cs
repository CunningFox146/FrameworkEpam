using FrameworkEpam.Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace FrameworkEpam.Utils
{
    public static class WaitUtil
    {
        public static IWebElement WaitForElement(By element, double seconds = 10)
        {
            return new WebDriverWait(CommonCases.Driver, TimeSpan.FromSeconds(seconds))
                .Until(Driver => Driver.FindElement(element));
        }
    }
}
