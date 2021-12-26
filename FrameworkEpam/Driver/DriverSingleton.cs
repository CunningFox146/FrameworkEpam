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

            return new ChromeDriver(options);
        }

        private static WebDriver InitFirefox(string driverPath)
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(driverPath);
            return new FirefoxDriver(service);
        }

    }
}
