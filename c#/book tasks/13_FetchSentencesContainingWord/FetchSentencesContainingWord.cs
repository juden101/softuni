using System;
using System.Linq;
using System.Text;

// sample input
// We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.
public class FetchSentencesContainingWord
{
    public static void Main()
    {
        string text = Console.ReadLine();
        string searchedWord = "in";
        string[] sentences = text.Split('.');
        StringBuilder output = new StringBuilder();

        foreach (var sentence in sentences)
        {
            var words = sentence.Split(' ');

            if (words.Contains(searchedWord))
            {
                output.AppendLine(sentence.Trim());
            }
        }

        Console.WriteLine(output.ToString().Trim());
    }
}