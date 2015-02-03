using System;
using System.Collections.Generic;
using System.Text;

public class SalesEmployee : RegularEmployee, IRegularEmployee
{
    private List<Sales> salesList;

    public SalesEmployee(string firstname, string lastname, int id, decimal salary, Department department,
        List<Sales> salesList)
        : base(firstname, lastname, id, salary, department)
    {
        this.SalesList = salesList;
    }

    public List<Sales> SalesList
    {
        get { return new List<Sales>(this.salesList); }
        set
        {
            if (value == null)
            {
                throw new ArgumentOutOfRangeException("Sales", "Sales list can not be empty");
            }

            this.salesList = new List<Sales>(value);
        }
    }

    public override string ToString()
    {
        StringBuilder sales = new StringBuilder();
        sales.AppendLine("Sales made:");

        foreach (var sale in salesList)
        {
            sales.AppendLine(sale.ToString());
        }

        return base.ToString() + sales.ToString();
    }
}