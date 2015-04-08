using System;

namespace Logger.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format(string message, ReportLevel reportLevel, DateTime date)
        {
            string formatted = string.Format("{0} - {1} - {2}\n", date, reportLevel, message);
            return formatted;
        }
    }
}
