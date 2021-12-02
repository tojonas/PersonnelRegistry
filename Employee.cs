using System;

namespace PersonnelRegistry
{
    public class Employee
    {
        public string Name { get; }
        public float Salary { get; }

        public Employee(string name, float salary)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name), $"Invalid {nameof(name)} [{name}]"); 
            }
            if (salary < 0 )
            {
                throw new ArgumentException(nameof(salary), $"Invalid {nameof(salary)} [{salary}]");
            }
            Name = name;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"Name:{Name} Salary:{Salary}";
        }

        public static Employee TryParse(string input, out string error)
        {
            error = null;

            string[] parts = input.Split(",");
            if (parts.Length < 2)
            {
                error = "Invalid format. Name and salary should be separated by comma Name,Salary";
                return null;
            }

            string name = parts[0].Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                error = $"Invalid name [{parts[0]}]";
                return null;
            }

            float salary = 0;

            if (float.TryParse(parts[1], out salary) == false || salary < 0)
            {
                error = $"Invalid salary [{parts[1]}]";
                return null;
            }
            return new Employee(name, salary);
        }
    }
}
