using System;

class Program
{
    static void Main()
    {
        Battery liIon = new Battery("Li-Ion, 4-cells, 2550 mAh");
        Battery niCd = new Battery("Ni-Cd", (float)4.5);
        
        Laptop lenovo = new Laptop("Lenovo Yoga 2 Pro", (decimal)2259.00, "Lenovo", "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)", "8 GB", "128GB SSD", "Intel HD Graphics 4400", liIon, "13.3\" (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display");
        Laptop hp = new Laptop("HP 250 G2", (decimal)699.00);
        Laptop acer = new Laptop("Acer Aspire", (decimal)1567.43, battery: niCd, processor: "3.2 GHz", ram: "16 GB");

        Console.Write(lenovo.ToString());
        Console.WriteLine("########################");
        Console.Write(hp.ToString());
        Console.WriteLine("########################");
        Console.Write(acer.ToString());
    }
}