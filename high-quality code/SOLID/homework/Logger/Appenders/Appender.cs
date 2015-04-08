using Logger.Layouts;
using System;

namespace Logger.Appenders
{
    public abstract class Appender : IAppender
    {
        private ILayout layout = null;

        public Appender(ILayout layout)
        {
            this.layout = layout;
        }

        public ReportLevel ReportLevel { get; set; }

        public abstract void Append(string message, ReportLevel reportLevel, DateTime date);

        protected virtual string ProcessLog(string message, ReportLevel reportLevel, DateTime date)
        {
            if (reportLevel >= this.ReportLevel)
            {
                string formattedMessage = this.layout.Format(message, reportLevel, date);
                return formattedMessage;
            }

            return null;
        }
    }
}
