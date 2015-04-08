using Logger.Layouts;
using System;
using System.Text;

namespace Logger.Sample
{
    internal class XmlLayout : ILayout
    {
        public string Format(string message, ReportLevel reportLevel, DateTime date)
        {
            var sb = new StringBuilder();

            sb.AppendLine("<log>");
            sb.AppendFormat("\t<date>{0}</date>\n", date);
            sb.AppendFormat("\t<level>{0}</level>\n", reportLevel);
            sb.AppendFormat("\t<message>{0}</message>\n", message);
            sb.AppendLine("</log>");

            return sb.ToString();
        }
    }
}
