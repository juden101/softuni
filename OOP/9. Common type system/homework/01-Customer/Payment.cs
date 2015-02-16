using System;

class Payment
{
    public string ProductName { get; set; }
    public decimal Price { get; set; }

    public Payment(string productName, decimal price)
    {
        this.ProductName = productName;
        this.Price = price;
    }
    
    public override string ToString()
    {
        return String.Format("(Product name: {0}, Price: {1})", this.ProductName, this.Price);
    }
}