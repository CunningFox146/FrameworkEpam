using FrameworkEpam.Utils;
using OpenQA.Selenium;

namespace FrameworkEpam.PageObjects.MainPage
{
    public class MainPage : BasePageObject
    {
        public IWebElement SuccessSellButton => Driver.FindElement(UIMap.Get("SuccessSellButton"));
        public IWebElement XbtValueElement => _driver.FindElement(UIMap.Get("XBTValue"));

        public OrderElement OrderElement { get; private set; }
        public SettingsValueElement AccountValueElement { get; private set; }
        
        public MainPage(IWebDriver driver) : base(driver)
        {
            Driver.Navigate().GoToUrl("https://testnet.bitmex.com/app");

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
