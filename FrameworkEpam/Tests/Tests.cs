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

        //[Test, Order(2)]
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

        //[Test, Order(3)]
        public void AddApiKeyTest()
        {
            var apiLayer = new ApiPageLayer(Driver);
            int startKeysCount = apiLayer.KeysCount;

            apiLayer.CreateFromConfig(ApiConfigCreator.CreateWithInvalidCIDR());
            Assert.AreEqual(startKeysCount, apiLayer.KeysCount);
            apiLayer.CreateFromConfig(ApiConfigCreator.CreateRandomValid());
            Assert.AreNotEqual(startKeysCount, apiLayer.KeysCount);

        }

        //[Test, Order(10)]
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

        [Test, Order(8)]
        public void ChangeCurrencyDisplay()
        {
            var mainPageLayer = new MainPageLayer(Driver);
            mainPageLayer.ChangeCurrencyToXBT();
            string startXBT = mainPageLayer.CurrentXbtValue;

            mainPageLayer.ChangeCurrencyToXBt();
            Assert.AreNotEqual(startXBT, mainPageLayer.CurrentXbtValue);

            mainPageLayer.ChangeCurrencyToXBT();
            Assert.AreEqual(startXBT, mainPageLayer.CurrentXbtValue);
        }
    }
}
