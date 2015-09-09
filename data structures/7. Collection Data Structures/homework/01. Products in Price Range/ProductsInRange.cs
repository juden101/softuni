using System;
using System.Linq;
using Wintellect.PowerCollections;

class ProductsInRange
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        OrderedMultiDictionary<decimal, Product> allProducts = new OrderedMultiDictionary<decimal, Product>(true);

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(' ');

            string name = input[0];
            decimal price = decimal.Parse(input[1]);
            Product newProduct = new Product() { Name = name, Price = price };

            allProducts.Add(price, newProduct);
        }

        string[] priceRanges = Console.ReadLine().Split(' ');
        decimal start = decimal.Parse(priceRanges[0]);
        decimal end = decimal.Parse(priceRanges[1]);

        var productsInRange = allProducts.Range(start, true, end, true).Take(20);

        Console.WriteLine();
        foreach (var price in productsInRange)
        {
            foreach (var product in price.Value)
            {
                Console.WriteLine(product);
            }
        }
    }
}