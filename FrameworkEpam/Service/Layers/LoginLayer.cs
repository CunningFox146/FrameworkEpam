using FrameworkEpam.Model;
using FrameworkEpam.PageObjects.LoginPage;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkEpam.Service.Layers
{
    public class LoginLayer
    {
        public LoginPage Page { get; private set; }

        public LoginLayer(IWebDriver driver)
        {
            Page = new LoginPage(driver);
        }

        public LoginLayer LogInUser(User user)
        {
            Page.WriteEmail(user.Login);
            Page.WritePassword(user.Password);
            Page.LogIn();
            return this;
        }
    }
}
