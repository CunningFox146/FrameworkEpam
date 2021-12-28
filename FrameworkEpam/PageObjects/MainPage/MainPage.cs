using FrameworkEpam.Utils;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace FrameworkEpam.PageObjects.MainPage
{
    public class MainPage : BasePageObject
    {
        public IWebElement SuccessSellButton => Driver.FindElement(UIMap.Get("SuccessSellButton"));
        public IWebElement XbtValueElement => _driver.FindElement(UIMap.Get("XBTValue"));
        public IWebElement DialogConfirmButton => WaitUtil.WaitForElement(UIMap.Get("DialogConfirm"));
        public ICollection<IWebElement> Notifications => WaitUtil.WaitForElements(UIMap.Get("NotificationSuccess"), 1);
        public ICollection<IWebElement> CloseNotificationButtons => WaitUtil.WaitForElements(UIMap.Get("CloseNotificationButton"), 1);

        public OrderElement OrderElement { get; private set; }
        public SettingsValueElement AccountValueElement { get; private set; }
        public TrollboxElement TrollBox { get; private set; }

        public MainPage(IWebDriver driver) : base(driver)
        {
            Driver.Navigate().GoToUrl("https://testnet.bitmex.com/app");

            TrollBox = new TrollboxElement(driver);
            OrderElement = new OrderElement(driver);
            AccountValueElement = new SettingsValueElement(driver);
        }
        
        public MainPage OpenSettings()
        {
            AccountValueElement.SettingsButton.Click();
            return this;
        }
    }
}
