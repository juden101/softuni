using System;

class Computer
{
    private string name;
    private Component motherboard;
    private Component processor;
    private Component ram;

    public Computer(string name, Component motherboard, Component processor, Component ram)
    {
        this.Name = name;
        this.Motherboard = motherboard;
        this.Processor = processor;
        this.Ram = ram;
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Name cannot be empty.");
            }

            this.name = value;
        }
    }

    public Component Motherboard
    {
        get { return this.motherboard; }
        set { this.motherboard = value; }
    }

    public Component Processor
    {
        get { return this.processor; }
        set { this.processor = value; }
    }

    public Component Ram
    {
        get { return this.ram; }
        set { this.ram = value; }
    }

    public decimal totalPrice
    {
        get
        {
            return this.Motherboard.Price + this.Processor.Price + this.Ram.Price;
        }
    }

    public override string ToString()
    {
        string result = "";

        string motherboardName = this.Motherboard.Name + " " + this.motherboard.Details;
        string processorName = this.Processor.Name + " " + this.Processor.Details;
        string ramName = this.Ram.Name + " " + this.Ram.Details;

        result = String.Format(
            "Computer Name: {0}\n Motherboard: {1} Price: {2}lv.\n Processor: {3} Price: {4}lv.\n Ram: {5} Price: {6}lv.\n Total price: {7}lv. ",
            this.name, motherboardName, this.Motherboard.Price, processorName, this.Processor.Price, ramName, this.Ram.Price, totalPrice
        );

        return result;
    }

}