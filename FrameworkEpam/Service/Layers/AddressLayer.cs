using FrameworkEpam.Model;
using FrameworkEpam.PageObjects.Addresses;
using FrameworkEpam.PageObjects.LoginPage;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkEpam.Service.Layers
{
    public class AddressLayer
    {
        public AddressesPage Page { get; private set; }

        public AddressLayer(IWebDriver driver)
        {
            Page = new AddressesPage(driver);
        }

        public AddressLayer AddRecord(AddressRecord record)
        {
            Page.AddRecordBtn.Click();
            Page.WriteAddress(record.Address);
            Page.WriteName(record.Name);
            Page.WriteNote(record.Note);
            Page.SelectCurrency(record.Currency);
            if (record.IsSkipConfirm)
            {
                Page.SkipConfirmToggle.Click();
            }

            return this;
        }
    }
}
