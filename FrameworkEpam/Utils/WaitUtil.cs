using FrameworkEpam.Driver;
using FrameworkEpam.Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrameworkEpam.Utils
{
    public static class WaitUtil
    {
        private static readonly IWebDriver Driver = DriverSingleton.Driver;
        public static IWebElement WaitForElement(By element, double seconds = 3)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds))
                .Until(Driver => Driver.FindElement(element));
        }
        public static ICollection<IWebElement> WaitForElements(By element, double seconds = 3)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds))
                .Until(Driver => Driver.FindElements(element));
        }

        public static Task DoTaskInTime(int delay, Action action)
        {
            var task = Task.Run(async delegate
            {
                await Task.Delay(delay);
                action?.Invoke();
            });
            task.Wait();
            return task;
        }
    }
}
