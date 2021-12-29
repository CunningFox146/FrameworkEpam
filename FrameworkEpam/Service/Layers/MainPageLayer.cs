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
        public int MyMessagesCount => Page.TrollBox.MyMessages.Count;
        public bool HasOpenPositions => Page.PositionSellMarket != null;

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

        public MainPageLayer WriteChatMessage(string message)
        {
            Page.TrollBox.ChatInput.SendKeys(message);
            Page.TrollBox.ChatInput.SendKeys(Keys.Enter);
            return this;
        }

        public MainPageLayer CloseAllNotifications()
        {
            foreach (var button in Page.CloseNotificationButtons)
            {
                button.Click();
            }
            return this;
        }


        public MainPageLayer OpenTrollBox()
        {
            Page.TrollBox.Open();
            return this;
        }

        public MainPageLayer OpenPositionsTab()
        {
            Page.PositionsTab.Click();
            Page.PositionsExpandBtn.Click();
            return this;
        }

        public MainPageLayer CloseSelectedPosition()
        {
            Page.PositionSellMarket?.Click();
            Page.DialogConfirmButton.Click();
            return this;
        }
    }
}
