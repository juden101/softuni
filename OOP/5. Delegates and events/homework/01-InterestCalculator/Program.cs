using System;

class Program
{
    static void Main()
    {
        InterestCalculator firstInterest = new InterestCalculator(500, 5.6, 10, TypeOfInterestCalculator.GetCompoundInterest);
        Console.WriteLine(firstInterest.ToString());

        InterestCalculator secondInterest = new InterestCalculator(2500, 7.2, 15, TypeOfInterestCalculator.GetSimpleInterest);
        Console.WriteLine(secondInterest.ToString());
    }
}