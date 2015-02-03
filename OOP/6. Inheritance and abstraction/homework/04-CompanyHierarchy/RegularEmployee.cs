using System;

public abstract class RegularEmployee : Employee, IRegularEmployee
{
    public RegularEmployee(string firstname, string lastname, int id, decimal salary, Department department)
        : base(firstname, lastname, id, salary, department)
    {
    }

    public override string ToString()
    {
        return base.ToString();
    }
}