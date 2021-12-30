using FrameworkEpam.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace FrameworkEpam.Driver
{
    public static class DriverSingleton
    {
        private static WebDriver _driver;
        public static WebDriver Driver => _driver;

        static DriverSingleton()
        {
            var config = ConfigurationManager.Configuration;
            string browserSetting = config.Browser;
            string driverPath = config.DriverPath;

            switch (browserSetting.ToLower())
            {
                case "firefox":
                    _driver = InitFirefox(driverPath);
                    break;
                default:
                    _driver = InitChrome(driverPath);
                    break;
            }
        }

        public static void CloseDriver()
        {
            _driver.Quit();
            _driver = null;
        }

        private static WebDriver InitChrome(string driverPath)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--ignore-certificate-errors");
            options.AddArguments("--ignore-ssl-errors");
            options.AddUserProfilePreference("download.default_directory", ConfigurationManager.Configuration.DownloadPath);
            options.AddUserProfilePreference("download.prompt_for_download", false);

            return new ChromeDriver(options);
        }

        private static WebDriver InitFirefox(string driverPath)
        {
            var options = new FirefoxOptions();
            options.BrowserExecutableLocation = driverPath;
            options.AddAdditionalOption("browser.download.dir", ConfigurationManager.Configuration.DownloadPath);
            options.AddAdditionalOption("browser.download.manager.showWhenStarting", false);
            options.AddAdditionalOption("browser.helperApps.neverAsk.saveToDisk", "text/csv");

            return new FirefoxDriver(options);
        }

    }
}
