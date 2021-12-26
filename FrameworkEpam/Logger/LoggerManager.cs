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
            string logPath = @"D:\Labs\EPAM_TEST_FRAMEWORK\Logs\log.txt";

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(logPath)
                .CreateLogger();

            Log.Information("test");



        }
    }
}
