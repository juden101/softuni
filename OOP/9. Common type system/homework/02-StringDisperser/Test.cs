using System;

class Test
{
    static void Main()
    {
        StringDisperser firstStringDisperser = new StringDisperser("hello", "beautifull", "World!");
        StringDisperser secondStringDisperser = new StringDisperser("gosho", "pesho", "tanio");
        StringDisperser thirdStringDisperser = (StringDisperser)firstStringDisperser.Clone();

        Console.WriteLine(firstStringDisperser + "\n");

        Console.WriteLine(firstStringDisperser.Equals(secondStringDisperser));
        Console.WriteLine(firstStringDisperser.Equals(thirdStringDisperser) + "\n");

        foreach (string character in secondStringDisperser)
        {
            Console.Write(character);
        }

        Console.WriteLine();
    }
}