using FrameworkEpam.Service;
using FrameworkEpam.Service.Layers;
using FrameworkEpam.Utils;
using NUnit.Framework;
using System;

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
            Assert.AreNotEqual(startUrl, Driver.Url);
        }

        [Test, Order(2)]
        public void AddAddressRecordTest()
        {
            var addressLayer = new AddressLayer(Driver);
            int startRecordsCount = addressLayer.RecordsCount;

            addressLayer.AddRecord(AddressRecordCreator.CreateWithEmptyAddress());
            Assert.AreEqual(startRecordsCount, addressLayer.RecordsCount);

            addressLayer.AddRecord(AddressRecordCreator.CreateWithEmptyName());
            Assert.AreEqual(startRecordsCount, addressLayer.RecordsCount);

            addressLayer.AddRecord(AddressRecordCreator.CreateRandomValid());
            Assert.AreNotEqual(startRecordsCount, addressLayer.RecordsCount);

            addressLayer.Page.CleanUp();
        }

        [Test, Order(3)]
        public void AddApiKeyTest()
        {
            var apiLayer = new ApiPageLayer(Driver);
            int startKeysCount = apiLayer.KeysCount;

            apiLayer.CreateFromConfig(ApiConfigCreator.CreateWithInvalidCIDR());
            Assert.AreEqual(startKeysCount, apiLayer.KeysCount);
            apiLayer.CreateFromConfig(ApiConfigCreator.CreateRandomValid());
            Assert.AreNotEqual(startKeysCount, apiLayer.KeysCount);
        }

        [Test, Order(4)]
        public void SellLimitTest()
        {
            var mainPageLayer = new MainPageLayer(Driver);
            mainPageLayer.CloseAllNotifications();
            mainPageLayer.SetSellValue(PageObjects.MainPage.OrderType.Limit, "0");
            Assert.That(mainPageLayer.IsSellButtonActive, Is.False);
            mainPageLayer.SetSellValue(PageObjects.MainPage.OrderType.Limit, "100");
            Assert.That(mainPageLayer.IsSellButtonActive, Is.True);

            int successNotifications = mainPageLayer.NotificationsCount;
            mainPageLayer.Sell();
            Assert.AreNotEqual(successNotifications, mainPageLayer.NotificationsCount);
        }

        [Test, Order(5)]
        public void SellMarketTest()
        {
            var mainPageLayer = new MainPageLayer(Driver);
            mainPageLayer.CloseAllNotifications();
            mainPageLayer.SetSellValue(PageObjects.MainPage.OrderType.Market, "0");
            Assert.That(mainPageLayer.IsSellButtonActive, Is.False);
            mainPageLayer.SetSellValue(PageObjects.MainPage.OrderType.Market, "100");
            Assert.That(mainPageLayer.IsSellButtonActive, Is.True);

            int successNotifications = mainPageLayer.NotificationsCount;
            mainPageLayer.Sell();
            Assert.AreNotEqual(successNotifications, mainPageLayer.NotificationsCount);
        }

        [Test, Order(6)]
        public void SellMarketStopTest()
        {
            var mainPageLayer = new MainPageLayer(Driver);
            mainPageLayer.CloseAllNotifications();
            mainPageLayer.SetSellValue(PageObjects.MainPage.OrderType.MarketStop, "0", "0");
            Assert.That(mainPageLayer.IsBuyButtonActive, Is.False);
            mainPageLayer.SetSellValue(PageObjects.MainPage.OrderType.MarketStop, "100", "448394");
            Assert.That(mainPageLayer.IsBuyButtonActive, Is.True);

            int successNotifications = mainPageLayer.NotificationsCount;
            mainPageLayer.Buy();
            Assert.AreNotEqual(successNotifications, mainPageLayer.NotificationsCount);
        }

        [Test, Order(8)]
        public void ChangeCurrencyDisplay()
        {
            var mainPageLayer = new MainPageLayer(Driver);
            mainPageLayer.CloseAllNotifications();
            mainPageLayer.ChangeCurrencyToXBT();
            string startXBT = mainPageLayer.CurrentXbtValue;

            mainPageLayer.ChangeCurrencyToXBt();
            Assert.AreNotEqual(startXBT, mainPageLayer.CurrentXbtValue);

            mainPageLayer.ChangeCurrencyToXBT();
            Assert.AreEqual(startXBT, mainPageLayer.CurrentXbtValue);
        }

        [Test, Order(9)]
        public void WriteMessageToTrollbox()
        {
            var mainPageLayer = new MainPageLayer(Driver);
            mainPageLayer.CloseAllNotifications();
            mainPageLayer.OpenTrollBox();
            int messagesCount = mainPageLayer.MyMessagesCount;
            mainPageLayer.WriteChatMessage("123");
            Assert.AreEqual(messagesCount, mainPageLayer.MyMessagesCount);
        }

        [Test, Order(10)]
        public void DownloadTradeHistoryTest()
        {
            var historyLayer = new TradeHistoryLayer(Driver);
            var path = @"C:\Users\Makar.Dzezhamesau\Desktop\testdownloads";
            string fileNameExpected = "Trade History";
            string currDate = DateTime.Now.ToString("yyyy-MM-dd");

            var oldFiles = FileUtil.GetAllFilesInDirectory(path);
            historyLayer.Download();
            WaitUtil.DoTaskInTime(1000, () =>
            {
                var newFiles = FileUtil.GetNewFiles(oldFiles, path);
                historyLayer.CleanUp();

                Assert.AreEqual(newFiles.Length, 1);
                Assert.That(() => newFiles[0].Contains(fileNameExpected) && newFiles[0].Contains(currDate));
            });
        }
    }
}
