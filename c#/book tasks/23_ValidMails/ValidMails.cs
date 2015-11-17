using System;
using System.IO;
using System.Text.RegularExpressions;

public class ValidMails
{
    public static void Main()
    {
        string[] lines = File.ReadAllLines(@"..\..\mails.txt");

        using (StreamWriter file = new StreamWriter(@"..\..\validMails.txt"))
        {
            foreach (string line in lines)
            {
                Regex regex = new Regex(@"([a-zA-Z]+)\s([a-zA-Z]+)\s([a-zA-Z_]+@[a-z]+\.[a-z]{2,4})");
                Match match = regex.Match(line);

                if (match.Success)
                {
                    string firstName = match.Groups[1].Value;
                    string lastName = match.Groups[2].Value;
                    string email = match.Groups[3].Value;

                    file.WriteLine(string.Format("{0} {1} {2}", firstName, lastName, email));
                }
            }
        }
    }
}