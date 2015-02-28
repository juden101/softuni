namespace FarmersCreed
{
    using System;
    using FarmersCreed.Simulator;

    class FarmersCreedMain
    {
        static void Main()
        {
            EnhancedFarmSimulator simulator = new EnhancedFarmSimulator();
            simulator.Run();
        }
    }
}
