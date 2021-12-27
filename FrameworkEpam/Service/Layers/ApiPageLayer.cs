using FrameworkEpam.Model;
using FrameworkEpam.PageObjects.ApiPage;
using OpenQA.Selenium;

namespace FrameworkEpam.Service.Layers
{
    public class ApiPageLayer
    {
        public ApiPage Page { get; private set; }
        public int KeysCount => Page.TableColumns.Count;
        public ApiPageLayer(IWebDriver driver)
        {
            Page = new ApiPage(driver);
        }

        public ApiPageLayer CreateFromConfig(ApiConfig config)
        {
            Page.WriteName(config.Name)
                .WriteCIDR(config.CIDR)
                .Submit();

            return this;
        }
    }
}
