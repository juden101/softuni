using System;

public abstract class Employee : Person, IEmployee
{
    private decimal salary;
    private Department department;

    public Employee(string firstname, string lastname, int id, decimal salary, Department department)
        : base(firstname, lastname, id)
    {
        this.Salary = salary;
        this.Department = department;
    }

    public decimal Salary
    {
        get { return this.salary; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Salary", "Salary can not be a negative sum.");
            }

            this.salary = value;
        }
    }

    public Department Department
    {
        get { return this.department; }
        set { this.department = value; }
    }

    public override string ToString()
    {
        return base.ToString() + String.Format(" Salary: {0:0.00}, Department: {1} ",
            this.salary, this.department);
    }
}