using System.Collections.Generic;

namespace FrameworkEpam.Model
{
    public class UIMapConfiguration
    {
        public Dictionary<string, string> CssSelectors { get; set; }
        public Dictionary<string, string> XpathSelectors { get; set; }

        public UIMapConfiguration()
        {
            CssSelectors = new Dictionary<string, string>();
            XpathSelectors = new Dictionary<string, string>();
        }

        public UIMapConfiguration FillDefaultValues()
        {
            CssSelectors.Add("EmailField", "#email");
            CssSelectors.Add("PasswordField", "#password");
            CssSelectors.Add("LogInButton", "button[type='submit']");
            CssSelectors.Add("Logo", "a[href='/app/']");

            return this;
        }
    }
}
