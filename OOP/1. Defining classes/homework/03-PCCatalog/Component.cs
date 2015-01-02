using System;

class Component
{
    private string name;
    private string details;
    private decimal price;

    public Component(string name, decimal price, string details = null)
    {
        this.Name = name;
        this.Details = details;
        this.Price = price;
    }

    public Component(string name, decimal price)
    {
        this.Name = name;
        this.Price = price;
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Component name cannot be empty.");
            }

            this.name = value;
        }
    }

    public decimal Price
    {
        get { return this.price; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Component price cannot be negative number.");
            }

            this.price = value;
        }
    }

    public string Details
    {
        get { return this.details; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Component details cannot be empty.");
            }

            this.details = value;
        }
    }

}