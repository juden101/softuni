using System;

class LoanAccount : Account
{
    public LoanAccount(string customer, double balance, double interestRate, AccountType accountType)
        : base(customer, balance, interestRate, accountType)
    {
    }

    public override double CalculateInterest(int periodByMonths)
    {
        var monthsInterestFree = 0;

        switch (this.AccountType)
        {
            case AccountType.Company:
                monthsInterestFree = 3;
                break;
            case AccountType.Individual:
                monthsInterestFree = 2;
                break;
            default:
                throw new NotImplementedException("There is no such case.");
        }

        if (periodByMonths <= monthsInterestFree)
        {
            return 0;
        }

        return base.CalculateInterest(periodByMonths - monthsInterestFree);
    }
}