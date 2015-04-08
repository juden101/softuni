using System;

namespace Logger.Appenders
{
    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }
        void Append(string message, ReportLevel reportLevel, DateTime date);
    }
}