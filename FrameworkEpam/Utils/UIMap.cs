using OpenQA.Selenium;

namespace FrameworkEpam.Utils
{
    public static class UIMap
    {
        public static By Get(string elementName)
        {
            if (ConfigurationManager.Configuration.UIMapConfig.CssSelectors.TryGetValue(elementName, out var selector))
                return By.CssSelector(selector);

            throw new System.Exception($"Failed to get css elemet: {elementName}");
        }
        public static By GetXpath(string elementName)
        {
            if (ConfigurationManager.Configuration.UIMapConfig.XpathSelectors.TryGetValue(elementName, out var selector))
                return By.XPath(selector);

            throw new System.Exception($"Failed to get xpath elemet: {elementName}");
        }
    }
}
