using System.Collections.Generic;

namespace FrameworkEpam.Model
{
    public class TestsConfiguration
    {
        public string LogsPath { get; set; }
        public User User { get; set; }
        public Dictionary<string, string> UIMapSelectors { get; set; }
        
        public TestsConfiguration FillDefaultValues()
        {
            User = new User("makar.papca@gmail.com", "Cunning84");
            UIMapSelectors = new Dictionary<string, string>();

            UIMapSelectors.Add("EmailField", "#email");
            UIMapSelectors.Add("PasswordField", "#password");
            UIMapSelectors.Add("LogInButton", "button[type='submit']");
            UIMapSelectors.Add("Logo", "a[href='/app/']");

            return this;
        }
    }
}
