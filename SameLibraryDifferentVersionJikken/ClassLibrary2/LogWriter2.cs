using ClassLibraryInterface;
using NLog;

namespace ClassLibrary2
{
    internal class LogWriter2 : ILogWriter2
    {
        NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public LogWriter2()
        {
            // NLog設定
            var config = new NLog.Config.LoggingConfiguration();
            var logconsole = new NLog.Targets.ConsoleTarget();
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            NLog.LogManager.Configuration = config;
        }

        public void Write(string str)
        {
            Logger.Info("LogWriter2:Write:" + str);
        }

        public void Write2(string str)
        {
            Logger.Info("LogWriter2:Write2:" + str);
        }
    }
}
