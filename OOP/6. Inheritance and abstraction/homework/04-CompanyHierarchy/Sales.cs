using System;

public class Sales : ISales
{
    private string productName;
    private DateTime productDate;
    private decimal price;

    public Sales(string productName, DateTime productDate, decimal price)
    {
        this.ProductName = productName;
        this.ProductDate = productDate;
        this.Price = price;
    }

    public string ProductName
    {
        get { return this.productName; }
        set
        {
            if (value.Length < 2)
            {
                throw new ArgumentOutOfRangeException("Product Name",
                    "Product Name can not be less thand 2 characters");
            }

            this.productName = value;
        }
    }

    public DateTime ProductDate
    {
        get { return this.productDate; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Product Date",
                    "Product Date can not be empty");
            }

            this.productDate = value;
        }
    }

    public decimal Price
    {
        get { return this.price; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Product Price",
                    "Product Price can not be a negative sum.");
            }

            this.price = value;
        }
    }

    public override string ToString()
    {
        return String.Format(" {0} from: {1}, price: {2:0.00}", this.productName, this.productDate, this.price);
    }
}