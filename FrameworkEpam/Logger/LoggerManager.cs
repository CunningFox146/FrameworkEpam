using FrameworkEpam.Utils;
using Serilog;
using System.Diagnostics;
using System.IO;

namespace FrameworkEpam.Logger
{
    public class LoggerManager
    {
        public LoggerManager()
        {
            string logPath = ConfigurationManager.Configuration.LogsPath;

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(logPath)
                .CreateLogger();
        }

        public static void StopLogger()
        {
            Log.CloseAndFlush();
        }
    }
}
