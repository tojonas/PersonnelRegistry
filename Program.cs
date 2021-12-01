using System;
using System.Collections.Generic;

namespace PersonnelRegistry
{
    class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>();
            Console.WriteLine("Please enter Name and Salary separated by comma (,) exit by pressing Enter, print employees by pressing p");
            while (true)
            {
                var input = Console.ReadLine();
                switch (input)
                {
                    case "":
                        return;

                    case "p":
                        employees.ForEach( e => Console.WriteLine(e) );
                        break;

                    default:
                        string error = null;
                        Employee employee = Employee.TryParse(input, out error );
                        if (null == employee)
                        {
                            Console.WriteLine(error);
                        }
                        else
                        {
                            employees.Add(employee);
                        }
                        break;
                }
            }
        }
    }
}
