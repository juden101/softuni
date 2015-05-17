namespace VehicleParkSystem
{
    using System;

    class UserInterface : IUserInterface
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string format, params string[] args)
        {
            Console.WriteLine(string.Format(format, args));
        }
    }
}
