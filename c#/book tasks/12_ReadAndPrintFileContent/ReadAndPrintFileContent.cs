using System;
using System.IO;

public class ReadAndPrintFileContent
{
    public static void Main()
    {
        string filePath = @"C:\Windows\win.ini";
        string fileContent = File.ReadAllText(filePath);

        Console.WriteLine(fileContent);
    }
}