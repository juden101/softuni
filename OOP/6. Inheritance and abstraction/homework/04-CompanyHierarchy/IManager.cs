using System.Collections.Generic;

public interface IManager : IEmployee
{
    List<Employee> EmployeeList { get; set; }
}