using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CountSymbols
{
    static void Main()
    {
        string input = Console.ReadLine();
        var hashTable = new HashTable<char, int>();

        foreach (char character in input)
        {
            if (!hashTable.ContainsKey(character))
            {
                hashTable.Add(character, 0);
            }

            hashTable[character]++;
        }

        var orderedHashTable = hashTable.OrderBy(ht => ht.Key);

        foreach (var element in orderedHashTable)
        {
            Console.WriteLine("{0}: {1} time/s", element.Key, element.Value);
        }
    }
}