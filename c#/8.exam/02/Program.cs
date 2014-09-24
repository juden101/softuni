using System;

class Program
{
    public static int lettersSum = 0;
    public static int symbolsSum = 0;
    public static int numbersSUm = 0;

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            char[] currentString = Console.ReadLine().ToCharArray();

            foreach (char character in currentString)
            {
                Weight(character);
            }
        }

        Console.WriteLine(lettersSum);
        Console.WriteLine(numbersSUm);
        Console.WriteLine(symbolsSum);
    }

    static void Weight(char character)
    {
        int weight = 0;
        int charNumber = (int)character;

        if (charNumber > 64 && charNumber < 91)
        {
            weight = (charNumber - 64) * 10;

            lettersSum += weight;
        }
        else if (charNumber > 96 && charNumber < 123)
        {
            weight = (charNumber - 96) * 10;

            lettersSum += weight;
        }
        else if ((charNumber > 32 && charNumber < 48) || (charNumber > 57 && charNumber < 65) || (charNumber > 90 && charNumber < 97) || (charNumber > 122 && charNumber < 127))
        {
            weight = 200;

            symbolsSum += weight;
        }
        else if (charNumber > 47 && charNumber < 58)
        {
            weight = (charNumber - 48) * 20;

            numbersSUm += weight;
        }
    }
}