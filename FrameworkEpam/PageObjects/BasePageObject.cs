using OpenQA.Selenium;

namespace FrameworkEpam.PageObjects
{
    public abstract class BasePageObject
    {
        protected IWebDriver _driver;
        public IWebDriver Driver => _driver;

        public BasePageObject(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
