using System;

class DepositAccount : Account, IWithdrawable
{
    public DepositAccount(string customer, double balance, double interestRate, AccountType accountType)
        : base(customer, balance, interestRate, accountType)
    {
    }

    public void WithdrawMoney(double amount)
    {
        if (this.Balance < amount)
        {
            throw new ArithmeticException("Insufficient amount.");
        }

        this.Balance = this.Balance - amount;
    }

    public override double CalculateInterest(int periodByMonths)
    {
        if (this.Balance < 1000)
        {
            return 0;
        }

        return base.CalculateInterest(periodByMonths);
    }
}