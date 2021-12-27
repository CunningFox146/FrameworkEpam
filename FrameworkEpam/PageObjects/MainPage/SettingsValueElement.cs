using FrameworkEpam.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkEpam.PageObjects.MainPage
{
    public class SettingsValueElement : BasePageElement
    {
        public IWebElement SettingsButton => _driver.FindElement(UIMap.GetXpath("SettingsButton"));
        public IWebElement XBtOption => _driver.FindElement(UIMap.Get("XBtOption"));
        public IWebElement XBTOption => _driver.FindElement(UIMap.Get("XBTOption"));

        public SettingsValueElement(IWebDriver driver) : base(driver) { }

    }
}
