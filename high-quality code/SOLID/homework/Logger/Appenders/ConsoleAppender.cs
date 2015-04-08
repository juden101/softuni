using Logger.Layouts;
using System;

namespace Logger.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            :base(layout)
        { }

        public override void Append(string message, ReportLevel reportLevel, DateTime date)
        {
            var log = base.ProcessLog(message, reportLevel, date);
            if (log != null)
            {
                Console.Write(log);
            }
        }
    }
}
