using FrameworkEpam.Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace FrameworkEpam.Utils
{
    public static class WaitUtil
    {
        public static IWebElement WaitForElement(By element, double seconds = 3)
        {
            return new WebDriverWait(CommonCases.Driver, TimeSpan.FromSeconds(seconds))
                .Until(Driver => Driver.FindElement(element));
        }
        public static ICollection<IWebElement> WaitForElements(By element, double seconds = 3)
        {
            return new WebDriverWait(CommonCases.Driver, TimeSpan.FromSeconds(seconds))
                .Until(Driver => Driver.FindElements(element));
        }
    }
}
