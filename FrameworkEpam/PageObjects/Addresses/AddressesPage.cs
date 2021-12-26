using FrameworkEpam.Utils;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace FrameworkEpam.PageObjects.Addresses
{
    public class AddressesPage : BasePageObject
    {
        public IWebElement AddRecordBtn => WaitUtil.WaitForElement(UIMap.Get("AddRecordButton"));
        public IWebElement NameField => WaitUtil.WaitForElement(UIMap.Get("AddressNameField"));
        public IWebElement AddressField => WaitUtil.WaitForElement(UIMap.Get("AddressAddressField"));
        public IWebElement NoteField => WaitUtil.WaitForElement(UIMap.Get("AddressNoteField"));
        public IWebElement CurrencySelect => WaitUtil.WaitForElement(UIMap.Get("CurrencySelect"));
        public IWebElement SubmitButton => WaitUtil.WaitForElement(UIMap.Get("AddressSubmitButton"));
        public IWebElement SkipConfirmToggle => WaitUtil.WaitForElement(UIMap.Get("skipConfirm"));
        public ICollection<IWebElement> CurrencySelectOptions => WaitUtil.WaitForElements(UIMap.Get("CurrencySelectOptions"));

        public AddressesPage(IWebDriver driver) : base(driver)
        {
            Driver.Navigate().GoToUrl("https://testnet.bitmex.com/app/addresses");
        }

        public AddressesPage WriteName(string name)
        {
            NameField.Clear();
            NameField.SendKeys(name);
            return this;
        }

        public AddressesPage WriteAddress(string address)
        {
            AddressField.Clear();
            AddressField.SendKeys(address);
            return this;
        }

        public AddressesPage WriteNote(string note)
        {
            NoteField.Clear();
            NoteField.SendKeys(note);
            return this;
        }

        public AddressesPage SelectCurrency(int idx)
        {
            CurrencySelect.Click();
            CurrencySelectOptions.ToArray()[idx].Click();

            return this;
        }
    }
}
