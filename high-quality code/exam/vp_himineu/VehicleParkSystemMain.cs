namespace VehicleParkSystem
{
    using System;
    using System.Globalization;
    using System.Threading;

    static class VehicleParkSystem
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            IUserInterface userInterface = new UserInterface();

            var engine = new Engine();
            engine.Run();
        }
    }
}