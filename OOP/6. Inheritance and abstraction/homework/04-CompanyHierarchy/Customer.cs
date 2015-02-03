using System;

public class Customer : Person, ICustomer
{
    private decimal netPurchaseAmount;

    public Customer(string firstName, string lastName, int id, decimal netPurchaseAmount)
        : base(firstName, lastName, id)
    {
        this.NetPurchaseAmount = netPurchaseAmount;
    }

    public decimal NetPurchaseAmount
    {
        get { return this.netPurchaseAmount; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Net Purchase Amount",
                    "Net Purchase Amount can not be a negative sum");
            }

            this.netPurchaseAmount = value;
        }
    }

    public override string ToString()
    {
        return base.ToString() + String.Format("Net Purchase Amount: {0.0:00}", this.netPurchaseAmount);
    }
}