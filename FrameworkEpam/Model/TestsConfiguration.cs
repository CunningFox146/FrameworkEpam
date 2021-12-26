using Newtonsoft.Json;
using System.Collections.Generic;

namespace FrameworkEpam.Model
{
    public class TestsConfiguration
    {
        public string LogsPath { get; set; }
        public string UIMapPath { get; set; }
        public User User { get; set; }

        [JsonIgnore]
        public UIMapConfiguration UIMapConfig { get; set; }

        public TestsConfiguration FillDefaultValues()
        {
            User = new User("makar.papca@gmail.com", "Cunning84");
            UIMapConfig = new UIMapConfiguration().FillDefaultValues();

            return this;
        }
    }
}
