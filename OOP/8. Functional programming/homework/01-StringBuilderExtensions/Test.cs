using System;
using System.Collections.Generic;
using System.Text;

class Test
{
    static void Main()
    {
        StringBuilder text = new StringBuilder("He had his dog since his childhood.");

        String substringedText = StringBuilderExtensions.Substring(text, 5, 18);
        Console.WriteLine(substringedText.ToString());
        //String substringedText = StringBuilderExtensions.Substring(text, 5, -2); // exception

        text = StringBuilderExtensions.RemoveText(text, "his");
        Console.WriteLine(text.ToString());

        StringBuilder chat = new StringBuilder();
        chat.AppendAll(new List<string>() { "Hi", ", ", "how ", "are ", "you" })
            .AppendAll(new List<string>() { "\nI ", "am ", "fine" });
        Console.WriteLine(chat);
    }
}