using System.Collections.Generic;

public interface ISalesEmployee : IRegularEmployee
{
    List<Sales> SalesList { get; set; }
}