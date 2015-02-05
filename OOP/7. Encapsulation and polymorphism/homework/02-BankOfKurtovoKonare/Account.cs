using System;

public abstract class Account : IInterestColculatable, IDepositable
{
    private string customer;
    private double balance;
    private double monthInterest;
    private AccountType accountType;

    protected Account(string customer, double balance, double interestRate, AccountType accountType)
    {
        this.Customer = customer;
        this.Balance = balance;
        this.MonthInterest = interestRate / 12 / 100;
        this.AccountType = accountType;
    }

    public virtual double CalculateInterest(int periodByMonths)
    {
        double interstForPeriod = this.Balance * this.monthInterest * periodByMonths;

        return interstForPeriod;
    }

    public void DepositMoney(double amount)
    {
        this.Balance = this.Balance + amount;
    }

    public string Customer
    {
        get
        {
            return this.customer;
        }
        set
        {
            if (value == null || value == "")
            {
                throw new ArgumentException("Customer cannot be null or empty!");
            }

            this.customer = value;
        }
    }

    public double Balance
    {
        get
        {
            return this.balance;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Balance cannot be negative!");
            }

            this.balance = value;
        }
    }

    public double MonthInterest
    {
        get
        {
            return this.monthInterest;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("Interest rate cannot be negative or zero!");
            }

            this.monthInterest = value;
        }
    }

    public AccountType AccountType { get; set; }
}