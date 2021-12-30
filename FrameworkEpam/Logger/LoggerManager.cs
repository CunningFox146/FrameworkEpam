using FrameworkEpam.Utils;
using Serilog;
using System;
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
                .WriteTo.File($"{logPath}/{DateTime.Now.ToString().Replace('/', '-').Replace(':', '.')}.log")
                .CreateLogger();
        }

        public static void StopLogger()
        {
            Log.CloseAndFlush();
        }
    }
}
