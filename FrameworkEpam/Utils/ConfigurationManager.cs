using FrameworkEpam.Model;
using Newtonsoft.Json;
using Serilog;
using System;
using System.IO;

namespace FrameworkEpam.Utils
{
    public static class ConfigurationManager
    {
        public static TestsConfiguration Configuration { get; private set; }

        static ConfigurationManager()
        {
            try
            {
                var configPath = Environment.GetEnvironmentVariable("testConfigPath");

                if (configPath == null)
                {
                    Log.Error($"Failed to get testConfigPath from PATH");
                    throw new Exception("Failed to get testConfigPath from PATH");
                }

                string configJson = File.ReadAllText(configPath);
                Configuration = JsonConvert.DeserializeObject<TestsConfiguration>(configJson) ?? new TestsConfiguration().FillDefaultValues();

                string mapJson = File.ReadAllText(Configuration.UIMapPath);
                Configuration.UIMapConfig = JsonConvert.DeserializeObject<UIMapConfiguration>(mapJson) ?? new UIMapConfiguration().FillDefaultValues();
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
