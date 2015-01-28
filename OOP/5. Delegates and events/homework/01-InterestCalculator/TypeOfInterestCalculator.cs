using System;

public static class TypeOfInterestCalculator
{

    public static decimal GetSimpleInterest(decimal sum, double interest, int years)
    {
        decimal simpleInterest = sum * (decimal)(1 + (interest * years / 100));
        return simpleInterest;
    }

    public static decimal GetCompoundInterest(decimal sum, double interest, int years)
    {
        decimal compoundInterest = sum * (decimal)Math.Pow(1 + (interest / 12 / 100), years * 12);
        return compoundInterest;
    }

}