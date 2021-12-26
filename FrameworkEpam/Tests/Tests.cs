using FrameworkEpam.PageObjects.LoginPage;
using FrameworkEpam.PageObjects.MainPage;
using FrameworkEpam.Service;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkEpam.Tests
{
    [TestFixture]
    public class Test : CommonCases
    {
        public Test() : base("https://testnet.bitmex.com/login") { }

        [Test, Order(1)]
        public void LogInTest()
        {
            var loginPage = new LoginPage(Driver)
                .LogInUser(UserCreator.CreateFromConfig());

            Assert.DoesNotThrow(() => loginPage.GetLogo());
        }

        [Test, Order(2)]
        public void BuyWithInvalidValueTest()
        {
            var mainPage = new MainPage(Driver);

            mainPage.OrderElement.OpenTab(OrderType.Market)
                .WriteValueField("0");

            Assert.True(mainPage.IsSuccessSellButtonDisabled);
        }
    }
}
