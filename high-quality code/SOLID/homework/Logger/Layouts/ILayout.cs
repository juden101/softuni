using System;

namespace Logger.Layouts
{
    public interface ILayout
    {
        string Format(string message, ReportLevel reportLevel, DateTime date);
    }
}
