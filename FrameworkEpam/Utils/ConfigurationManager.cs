using FrameworkEpam.Model;
using Newtonsoft.Json;
using System;
using System.IO;

namespace FrameworkEpam.Utils
{
    public static class ConfigurationManager
    {
        public static TestsConfiguration Configuration { get; private set; }
        public static readonly string ConfigPath = @"D:\Labs\TestFrameworkEpam\testsConfig.json";

        static ConfigurationManager()
        {
            try
            {
                string json = File.ReadAllText(ConfigPath);
                Configuration = JsonConvert.DeserializeObject<TestsConfiguration>(json);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error($"Failed to load config {ex.Message}");
            }
            finally
            {
                if (Configuration == null)
                {
                    Configuration = new TestsConfiguration().FillDefaultValues();
                }
            }

        }
    }
}
