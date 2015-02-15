using System;
using System.Text;
using System.Collections.Generic;

public static class StringBuilderExtensions
{
    public static String Substring(this StringBuilder strBuilder, int startIndex, int length)
    {
        if (startIndex < 0 || length <= 0)
        {
            throw new ArgumentOutOfRangeException("Invalid range!");
        }

        return strBuilder.ToString().Substring(startIndex, length);
    }

    public static StringBuilder RemoveText(this StringBuilder strBuilder, string text)
    {
        return strBuilder.Replace(text, "");
    }

    public static StringBuilder AppendAll<T>(this StringBuilder strBuilder, IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            strBuilder.Append(item);
        }

        return strBuilder;
    }
}