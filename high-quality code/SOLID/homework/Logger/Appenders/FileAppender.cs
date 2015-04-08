using Logger.Layouts;
using System;

namespace Logger.Appenders
{
    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout)
            : base(layout)
        { }

        public string File { get; set; }

        public override void Append(string message, ReportLevel reportLevel, DateTime date)
        {
            if (string.IsNullOrEmpty(this.File))
            {
                throw new InvalidOperationException("Please set file name first!");
            }

            var log = base.ProcessLog(message, reportLevel, date);
            if (log != null)
            {
                using (var sw = System.IO.File.AppendText(this.File))
                {
                    sw.WriteLine(log);
                }
            }
        }
    }
}
