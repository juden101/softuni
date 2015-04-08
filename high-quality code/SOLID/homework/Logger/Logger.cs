using Logger.Appenders;
using System;

namespace Logger
{
    public class Logger : ILogger
    {
        private IAppender[] appenders = null;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public virtual void Info(string msg)
        {
            AppendToAll(msg, ReportLevel.Info);
        }

        public virtual void Warn(string msg)
        {
            AppendToAll(msg, ReportLevel.Warning);
        }

        public virtual void Error(string msg)
        {
            AppendToAll(msg, ReportLevel.Error);
        }

        public virtual void Critical(string msg)
        {
            AppendToAll(msg, ReportLevel.Critical);
        }

        public virtual void Fatal(string msg)
        {
            AppendToAll(msg, ReportLevel.Fatal);
        }

        private void AppendToAll(string msg, ReportLevel reportLevel)
        {
            foreach (var appender in this.appenders)
            {
                appender.Append(msg, reportLevel, DateTime.Now);
            }
        }
    }
}
