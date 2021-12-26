using OpenQA.Selenium;

namespace FrameworkEpam.Utils
{
    public static class UIMap
    {
        public static By Get(string elementName)
        {
            if (ConfigurationManager.Configuration.UIMapConfig.CssSelectors.TryGetValue(elementName, out var selector))
                return By.CssSelector(selector);

            throw new System.Exception($"Failed to get elemet: {elementName}");
        }
    }
}
