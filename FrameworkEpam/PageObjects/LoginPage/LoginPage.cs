using FrameworkEpam.Model;
using FrameworkEpam.Utils;
using OpenQA.Selenium;

namespace FrameworkEpam.PageObjects.LoginPage
{
    public class LoginPage : BasePageObject
    {
        public IWebElement EmailField => Driver.FindElement(UIMap.Get("EmailField"));
        public IWebElement PasswordField => Driver.FindElement(UIMap.Get("PasswordField"));
        public IWebElement LogInButton => Driver.FindElement(UIMap.Get("LogInButton"));

        public IWebElement GetLogo() => WaitUtil.WaitForElement(UIMap.Get("Logo"));

        public LoginPage(IWebDriver driver) : base(driver) { }

        public LoginPage WriteEmail(string email)
        {
            EmailField.Clear();
            EmailField.SendKeys(email);
            return this;
        }

        public LoginPage WritePassword(string password)
        {
            PasswordField.Clear();
            PasswordField.SendKeys(password);
            return this;
        }

        public LoginPage LogIn()
        {
            LogInButton.Click();
            return this;
        }
    }
}
