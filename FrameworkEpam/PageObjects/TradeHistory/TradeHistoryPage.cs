using FrameworkEpam.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkEpam.PageObjects.TradeHistory
{
    public class TradeHistoryPage : BasePageObject
    {
        public IWebElement DownloadButton => WaitUtil.WaitForElement(UIMap.Get("TradeHistoryDownloadButton"));

        public TradeHistoryPage(IWebDriver driver) : base(driver) {

            driver.Navigate().GoToUrl("https://testnet.bitmex.com/app/tradeHistory");
        }
    }
}
