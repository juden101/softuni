using System;

class MortgageAccount : Account
{
    public MortgageAccount(string customer, double balance, double interestRate, AccountType accountType)
        : base(customer, balance, interestRate, accountType)
    {
    }

    public override double CalculateInterest(int periodByMonths)
    {
        var halfInterestMonths = 0;

        switch (this.AccountType)
        {
            case AccountType.Company:
                halfInterestMonths = 12;
                break;
            case AccountType.Individual:
                halfInterestMonths = 6;
                break;
            default:
                throw new NotImplementedException("There is no such case.");
        }

        var fullInterestMonths = periodByMonths - halfInterestMonths;

        if (fullInterestMonths <= 0)
        {
            return base.CalculateInterest(halfInterestMonths) / 2;
        }

        return base.CalculateInterest(halfInterestMonths) / 2 + base.CalculateInterest(fullInterestMonths);
    }
}