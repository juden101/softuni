using System;

class Program
{
    static void Main()
    {
        int oddProduct = 1, evenProduct = 1;

        Console.Write("numbers = ");
        string[] numbers = Console.ReadLine().Split();

        for (int i = 0; i < numbers.Length; i++)
        {
            if(i % 2 == 0)
            {
                oddProduct *= Convert.ToInt32(numbers[i]);
            }
            else
            {
                evenProduct *= Convert.ToInt32(numbers[i]);
            }
        }

        if(oddProduct == evenProduct)
        {
            Console.WriteLine("yes\nproduct = {0}", oddProduct);
        }
        else
        {
            Console.WriteLine("no\nodd_product = {0}\neven_product = {1}", oddProduct, evenProduct);
        }
    }
}