using Logger.Appenders;
using Logger.Layouts;
using System;

namespace Logger.Sample
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("First example..");
            ExampleOne();
            Console.WriteLine("\n");

            Console.WriteLine("Second example...");
            ExampleTwo();
            Console.WriteLine("\n");

            Console.WriteLine("Third example...");
            ExampleThree();
            Console.WriteLine("\n");

            Console.WriteLine("Fourth example...");
            ExampleFour();
            Console.WriteLine("\n");
        }

        private static void ExampleOne()
        {
            ILayout simpleLayout = new SimpleLayout();
            IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            ILogger logger = new Logger(consoleAppender);

            logger.Error("Error parsing JSON.");
            logger.Info(string.Format("User {0} successfully registered.", "Pesho"));
        }

        private static void ExampleTwo()
        {
            var simpleLayout = new SimpleLayout();

            var consoleAppender = new ConsoleAppender(simpleLayout);
            var fileAppender = new FileAppender(simpleLayout);
            fileAppender.File = "log.txt";

            var logger = new Logger(consoleAppender, fileAppender);
            logger.Error("Error parsing JSON.");
            logger.Info(string.Format("User {0} successfully registered.", "Pesho"));
            logger.Warn("Warning - missing files.");
        }

        private static void ExampleThree()
        {
            var xmlLayout = new XmlLayout();
            var consoleAppender = new ConsoleAppender(xmlLayout);
            var logger = new Logger(consoleAppender);

            logger.Fatal("mscorlib.dll does not respond");
            logger.Critical("No connection string found in App.config");
        }

        private static void ExampleFour()
        {
            var simpleLayout = new SimpleLayout();
            var consoleAppender = new ConsoleAppender(simpleLayout);
            consoleAppender.ReportLevel = ReportLevel.Error;

            var logger = new Logger(consoleAppender);

            logger.Info("Everything seems fine");
            logger.Warn("Warning: ping is too high - disconnect imminent");
            logger.Error("Error parsing request");
            logger.Critical("No connection string found in App.config");
            logger.Fatal("mscorlib.dll does not respond");
        }
    }
}
