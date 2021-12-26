using OpenQA.Selenium;

namespace FrameworkEpam.PageObjects
{
    public class BasePageElement
    {
        protected IWebDriver _driver;
        public IWebDriver Driver => _driver;

        public BasePageElement(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
