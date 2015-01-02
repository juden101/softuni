using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Computer> computers = new List<Computer>();

        Computer PC1 = new Computer(
            name: "Lenovo",
            motherboard: new Component("Asrock", 334m, "laptop"),
            processor: new Component("Pentium", 234m, "4 cores"),
            ram: new Component("4GB", 200m, "DDR3")
        );

        Computer PC2 = new Computer(
            name: "Asus",
            motherboard: new Component("Gigabyte", 144m, "desktop"),
            processor: new Component("i5 2345", 134m, "6 cores"),
            ram: new Component("8GB", 100m, "DDR3")
        );

        Computer PC3 = new Computer(
            name: "HP",
            motherboard: new Component("Asus", 112m),
            processor: new Component("i3 2200", 104m),
            ram: new Component("8GB", 80m)
        );

        computers.Add(PC1);
        computers.Add(PC2);
        computers.Add(PC3);

        computers = computers.OrderBy(o => o.totalPrice).ToList();

        foreach (var computer in computers)
        {
            Console.WriteLine(computer);
            Console.WriteLine("###############");
        }
    }
}