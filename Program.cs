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
                        PrintEmployees(employees);
                        break;

                    default:
                        Employee employee = null;
                        if (true == TryParseInput(input, out employee))
                        {
                            employees.Add(employee);
                        }
                        break;
                }
            }
        }
        private static bool TryParseInput(string input, out Employee employee)
        { 
            employee = new Employee();

            string[] parts = input.Split(",");
            if( parts.Length < 2 )
            {
                Console.WriteLine("Invalid format. Enter name and salary separated by comma");
                return false;
            }
            float salary = 0;
            if (string.IsNullOrEmpty(parts[0]))
            {
                Console.WriteLine("Invalid name [{0}]", parts[0]);
                return false;
            }
            employee.Name = parts[0];
            if (float.TryParse(parts[1], out salary) == false || salary < 0)
            {
                Console.WriteLine("Invalid salary [{0}]", parts[1]);
                return false;
            }
            employee.Salary = salary;
            return true;
        }

        private static void PrintEmployees(IEnumerable<Employee> list)
        {
            foreach (var employee in list)
            {
                Console.WriteLine(employee);
            }
        }

    }
}
