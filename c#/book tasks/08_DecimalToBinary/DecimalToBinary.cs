using System;
using System.Text;

public class DecimalToBinary
{
    public static void Main()
    {
        Console.Write("Enter number: ");
        int n = int.Parse(Console.ReadLine());
        string result = "";

        while (n >= 1)
        {
            result += (n % 2).ToString();
            n /= 2;
        }

        result = Reverse(result);
        Console.WriteLine("binary = {0}", result);
    }

    private static string Reverse(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text;
        }

        StringBuilder builder = new StringBuilder(text.Length);

        for (int i = text.Length - 1; i >= 0; i--)
        {
            builder.Append(text[i]);
        }

        return builder.ToString();
    }
}