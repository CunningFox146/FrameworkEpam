using FrameworkEpam.PageObjects.MainPage;
using OpenQA.Selenium;

namespace FrameworkEpam.Service.Layers
{
    public class MainPageLayer
    {
        public MainPage Page { get; set; }

        public string CurrentXbtValue => Page.XbtValueElement.Text;
        public bool IsSellButtonActive => string.IsNullOrEmpty(Page.OrderElement.SellButton.GetAttribute("disabled"));
        public bool IsBuyButtonActive => string.IsNullOrEmpty(Page.OrderElement.BuyButton.GetAttribute("disabled"));
        public int NotificationsCount => Page.Notifications.Count;

        public MainPageLayer(IWebDriver driver)
        {
            Page = new MainPage(driver);
        }

        public MainPageLayer ChangeCurrencyToXBT()
        {
            Page.OpenSettings()
                .AccountValueElement
                .XBTOption.Click();

            return this;
        }

        public MainPageLayer ChangeCurrencyToXBt()
        {
            Page.OpenSettings()
                .AccountValueElement
                .XBtOption.Click();

            return this;
        }

        public void SetSellValue(OrderType type, string value, string stopValue = "")
        {
            Page.OrderElement.OpenTab(type);
            Page.OrderElement.MarketValueField.Clear();
            Page.OrderElement.MarketValueField.SendKeys(value);
            if (!string.IsNullOrEmpty(stopValue))
            {
                Page.OrderElement.MarketStopField.Clear();
                Page.OrderElement.MarketStopField.SendKeys(stopValue);
            }
        }

        public MainPageLayer Sell()
        {
            Page.OrderElement.SellButton.Click();
            Page.DialogConfirmButton.Click();
            return this;
        }

        public MainPageLayer Buy()
        {
            Page.OrderElement.BuyButton.Click();
            Page.DialogConfirmButton.Click();
            return this;
        }
    }
}
