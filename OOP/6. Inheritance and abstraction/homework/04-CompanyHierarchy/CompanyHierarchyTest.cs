using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        Sales dairy = new Sales("Milk", new DateTime(2014, 10, 1), 2.50m);
        Sales chocolate = new Sales("Chocolate", new DateTime(2014, 10, 1), 1.80m);
        Sales meat = new Sales("Meat", new DateTime(2014, 10, 1), 4.80m);
        Sales vegitables = new Sales("Vegitables", new DateTime(2014, 10, 1), 3.80m);
        Sales books = new Sales("C# Programming", new DateTime(2014, 10, 2), 9.90m);
        Sales laptop = new Sales("Toshiba Satelite", new DateTime(2014, 10, 2), 999.90m);
        Sales beer = new Sales("Stolichno tymno", new DateTime(2014, 10, 3), 1.75m);
        Sales whiskey = new Sales("Jameson", new DateTime(2014, 10, 3), 29.50m);

        var foodSales = new List<Sales>();
        foodSales.Add(dairy);
        foodSales.Add(chocolate);
        foodSales.Add(meat);
        foodSales.Add(vegitables);

        var otherSales = new List<Sales>();
        otherSales.Add(books);
        otherSales.Add(laptop);
        otherSales.Add(beer);
        otherSales.Add(whiskey);

        Project CSharp = new Project("Accounting system", new DateTime(2014, 9, 15), "N/A");
        Project Java = new Project("Booking system", new DateTime(2014, 5, 13), "N/A");
        Project PHP = new Project("Database Center", new DateTime(2014, 8, 20), "N/A");
        Project JavaScript = new Project("On-line games", new DateTime(2014, 7, 28), "N/A");
        Project HTML_CSS = new Project("A fancy web-site", new DateTime(2014, 8, 8), "N/A");

        var webPoejcts = new List<Project>();
        webPoejcts.Add(HTML_CSS);
        webPoejcts.Add(JavaScript);
        webPoejcts.Add(Java);

        var otherProjects = new List<Project>();
        otherProjects.Add(CSharp);
        otherProjects.Add(PHP);

        RegularEmployee foodSalesEmployee = new SalesEmployee("Ivan", "Ivanov", 100, 1000, Department.Sales, foodSales);
        RegularEmployee othersSalesEmployee = new SalesEmployee("Dragan", "Peshev", 97, 1400, Department.Sales, otherSales);

        RegularEmployee webDeveloper = new Developer("Maria", "Mainova", 333, 1800, Department.Marketing, webPoejcts);
        RegularEmployee appDevelooper = new Developer("Gosho", "Topciev", 666, 2800, Department.Production, otherProjects);

        var otherEmployees = new List<Employee>();
        otherEmployees.Add(foodSalesEmployee);
        otherEmployees.Add(othersSalesEmployee);

        var programmerEmployees = new List<Employee>();
        programmerEmployees.Add(webDeveloper);
        programmerEmployees.Add(appDevelooper);

        Employee programmingManager = new Manager("Muncho", "Gunchev", 1, 5000, Department.Sales, programmerEmployees);
        Employee accountingManager = new Manager("Iskra", "Gringo", 2, 4000, Department.Accounting, otherEmployees);

        var managers = new List<Person>();
        managers.Add(programmingManager);
        managers.Add(accountingManager);

        foreach (var manager in managers)
        {
            Console.WriteLine(manager);
        }
    }
}