using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class LINQExtensionMethods
{
    public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        foreach (var item in collection)
        {
            if(!predicate(item)) {
                yield return item;
            }
        }
    }

    public static IEnumerable<T> Repeat<T>(this IEnumerable<T> collection, int count)
    {
        for (int i = 0; i < count; i++)
        {
            foreach (var item in collection)
            {
                yield return item;
            }
        }
    }

    public static IEnumerable<string> WhereEndsWith(this IEnumerable<string> collection, IEnumerable<string> suffixes)
    {
        foreach (var word in collection)
        {
            foreach (var suffix in suffixes)
            {
                if (word.ToString().Trim().EndsWith(suffix))
                {
                    yield return word.Trim();
                }
            }
        }
    }
}