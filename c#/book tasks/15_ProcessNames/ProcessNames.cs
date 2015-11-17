using System;
using System.IO;
using System.Linq;

class ProcessNames
{
    public static void Main()
    {
        string namesFilePath = "../../names.txt";
        var names = File.ReadAllLines(namesFilePath).ToList<string>();

        names.Sort();

        TextWriter tw = new StreamWriter("../../sortedNames.txt");

        foreach (string name in names)
        {
            tw.WriteLine(name);
        }

        tw.Close();
    }
}