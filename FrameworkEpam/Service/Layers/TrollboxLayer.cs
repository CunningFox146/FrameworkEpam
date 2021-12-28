using FrameworkEpam.PageObjects.Trollbox;
using OpenQA.Selenium;

namespace FrameworkEpam.Service.Layers
{
    public class TrollboxLayer
    {
        public TrollboxPage Page { get; set; }
        public int MyMessagesCount => Page.MyMessages.Count;
        private bool _isOpen = false;

        public TrollboxLayer(IWebDriver driver)
        {
            Page = new TrollboxPage(driver);
        }

        public TrollboxLayer Open()
        {
            Page.PopUpChat.Click();
            _isOpen = !_isOpen;

            return this;
        }

        public TrollboxLayer WriteChatMessage(string message)
        {
            Page.ChatInput.SendKeys(message);
            Page.ChatInput.SendKeys(Keys.Enter);
            return this;
        }
    }
}
