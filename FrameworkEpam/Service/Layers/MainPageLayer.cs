using FrameworkEpam.PageObjects.MainPage;
using OpenQA.Selenium;

namespace FrameworkEpam.Service.Layers
{
    public class MainPageLayer
    {
        public MainPage Page { get; set; }

        public string CurrentXbtValue => Page.XbtValueElement.Text;

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
    }
}
