using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData
{
    class Program
    {
        static void Main()
        {
            string firstName = "Peter";
            string lastName = "Green";
            char gender = 'm';
            long personalID = 8306112507;
            int uniqueNumber = 27569999;

            Console.WriteLine("first name: {0} \nlast name: {1} \ngender: {2} \npersonal ID: {3} \nunique number: {4}", firstName, lastName, gender, personalID, uniqueNumber);
        }
    }
}
