using System;

class Program
{
    static void Main()
    {
        string[] words = Console.ReadLine().Split();
        string longestWord = "";

        foreach (string word in words)
        {
            if(word.Length > longestWord.Length)
            {
                longestWord = word;
            }
        }

        Console.WriteLine(longestWord.Trim(new Char[] { ' ', ',', '.' }));
    }
}