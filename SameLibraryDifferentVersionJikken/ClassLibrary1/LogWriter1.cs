using ClassLibraryInterface;
using NLog;

namespace ClassLibrary1
{
    internal class LogWriter1 : ILogWriter1
    {
        NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public LogWriter1()
        {
            // NLog設定
            var config = new NLog.Config.LoggingConfiguration();
            var logconsole = new NLog.Targets.ConsoleTarget();
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            NLog.LogManager.Configuration = config;
        }

        public void Write(string str)
        {
            Logger.Info("LogWriter1:Write:" + str);
        }
    }
}
