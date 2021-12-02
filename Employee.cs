using System;

namespace PersonnelRegistry
{
    public class Employee
    {
        public string Name { get; set; }
        public float Salary { get; set; }

        public Employee(string name, float salary)
        {
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
                error = "Invalid format. Enter name and salary separated by comma";
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
