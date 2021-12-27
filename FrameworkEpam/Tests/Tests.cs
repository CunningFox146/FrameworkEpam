using FrameworkEpam.Service;
using FrameworkEpam.Service.Layers;
using NUnit.Framework;
using System.Threading;

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
    }
}
