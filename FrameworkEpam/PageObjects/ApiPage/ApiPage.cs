using FrameworkEpam.Utils;
using OpenQA.Selenium;
using Serilog;
using System.Collections.Generic;
using System.Linq;

namespace FrameworkEpam.PageObjects.ApiPage
{
    public class ApiPage : BasePageObject
    {
        public IWebElement NameField => Driver.FindElement(UIMap.Get("ApiNameField"));
        public IWebElement CIDRField => Driver.FindElement(UIMap.Get("ApiCidrField"));
        public IWebElement PermissionSelect => Driver.FindElement(UIMap.Get("ApiSelect"));
        public IWebElement SubmitButton => Driver.FindElement(UIMap.Get("ApiSubmitButton"));
        public ICollection<IWebElement> PermissionItems => Driver.FindElements(UIMap.Get("ApiSelect"));
        public ICollection<IWebElement> TableColumns => Driver.FindElements(UIMap.Get("ApiTableCols"));

        public ApiPage(IWebDriver driver) : base(driver)
        {
            driver.Navigate().GoToUrl("https://testnet.bitmex.com/app/apiKeys");
        }

        public ApiPage WriteName(string name)
        {
            NameField.Clear();
            NameField.SendKeys(name);
            return this;
        }

        public ApiPage WriteCIDR(string cidr)
        {
            CIDRField.Clear();

            if (!string.IsNullOrEmpty(cidr))
            {
                CIDRField.SendKeys(cidr);
            }

            return this;
        }

        public ApiPage SelectPermissions(int idx)
        {
            PermissionSelect.Click();
            Log.Information(PermissionItems.Count.ToString());
            PermissionItems.ToArray()[idx].Click();

            return this;
        }

        public ApiPage Submit()
        {
            SubmitButton.Click();
            return this;
        }
    }
}
