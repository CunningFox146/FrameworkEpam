using FrameworkEpam.Model;
using FrameworkEpam.PageObjects.Addresses;
using OpenQA.Selenium;

namespace FrameworkEpam.Service.Layers
{
    public class AddressLayer
    {
        public AddressesPage Page { get; private set; }

        public int RecordsCount => Page.Records.Count;

        public AddressLayer(IWebDriver driver)
        {
            Page = new AddressesPage(driver);
        }

        public AddressLayer AddRecord(AddressRecord record)
        {
            Page.AddNewRecord()
                .WriteAddress(record.Address)
                .WriteName(record.Name)
                .WriteNote(record.Note)
                .SelectCurrency(record.Currency);

            if (record.IsSkipConfirm)
            {
                Page.SkipConfirmToggle.Click();
            }
            if (Page.CanSubmit)
            {
                Page.Submit();
            }

            return this;
        }
    }
}
