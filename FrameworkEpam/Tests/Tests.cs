using FrameworkEpam.PageObjects.MainPage;
using FrameworkEpam.Service;
using FrameworkEpam.Service.Layers;
using NUnit.Framework;
using Serilog;

namespace FrameworkEpam.Tests
{
    [TestFixture]
    public class Test : CommonCases
    {
        public Test() : base("https://testnet.bitmex.com/login") { }

        [Test, Order(1)]
        public void LogInTest()
        {
            string startUrl = Driver.Url;
            var loginLayer = new LoginLayer(Driver);

            loginLayer.LogInUser(UserCreator.CreateWithEmptyUsername());
            Assert.AreEqual(startUrl, Driver.Url);

            loginLayer.LogInUser(UserCreator.CreateWithEmptyPassword());
            Assert.AreEqual(startUrl, Driver.Url);

            loginLayer.LogInUser(UserCreator.CreateFromConfig());
            Assert.AreEqual(startUrl, Driver.Url);
        }

        //[Test, Order(2)]
        //public void BuyWithInvalidValueTest()
        //{
        //    var mainPage = new MainPage(Driver);

        //    mainPage.OrderElement.OpenTab(OrderType.Market)
        //        .WriteValueField("0");

        //    Assert.True(mainPage.IsSuccessSellButtonDisabled);
        //}
    }
}
