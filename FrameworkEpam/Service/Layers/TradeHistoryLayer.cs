using FrameworkEpam.PageObjects.TradeHistory;
using FrameworkEpam.Utils;
using OpenQA.Selenium;

namespace FrameworkEpam.Service.Layers
{
    public class TradeHistoryLayer
    {
        public TradeHistoryPage Page { get; set; }

        public TradeHistoryLayer(IWebDriver driver)
        {
            Page = new TradeHistoryPage(driver);
        }

        public TradeHistoryLayer Download()
        {
            Page.DownloadButton.Click();
            return this;
        }

        public void CleanUp() => FileUtil.RemoveAllFilesInDirectory(ConfigurationManager.Configuration.DownloadPath);
    }
}
