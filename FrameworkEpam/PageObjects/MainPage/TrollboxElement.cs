using FrameworkEpam.Utils;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace FrameworkEpam.PageObjects.MainPage
{
    public class TrollboxElement : BasePageElement
    {
        private bool _isOpen = false;

        public IWebElement PopUpChat => WaitUtil.WaitForElement(UIMap.Get("Trollbox"));
        public IWebElement ChatInput => WaitUtil.WaitForElement(UIMap.Get("ChatInput"));
        public ICollection<IWebElement> MyMessages => WaitUtil.WaitForElements(UIMap.Get("ChatMyMessage"), 1);

        public TrollboxElement(IWebDriver driver) : base(driver)
        {
        }

        public TrollboxElement Open()
        {
            if (!_isOpen)
            {
                PopUpChat.Click();
                _isOpen = true;
            }

            return this;
        }
    }
}
