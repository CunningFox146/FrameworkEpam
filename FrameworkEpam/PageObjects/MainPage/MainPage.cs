using FrameworkEpam.Utils;
using OpenQA.Selenium;

namespace FrameworkEpam.PageObjects.MainPage
{
    public class MainPage : BasePageObject
    {
        public IWebElement SuccessSellButton => Driver.FindElement(UIMap.Get("SuccessSellButton"));

        public OrderElement OrderElement { get; private set; }

        public bool IsSuccessSellButtonDisabled => !string.IsNullOrEmpty(SuccessSellButton.GetDomProperty("disabled"));

        public MainPage(IWebDriver driver) : base(driver)
        {
            OrderElement = new OrderElement(driver);
        }

    }
}
