using System;
using System.Collections.Generic;
using System.Linq;

public class Department
{
    public string name;
    public List<Employee> employees;

    public Department(string name)
    {
        this.name = name;
        this.employees = new List<Employee>();
    }
}

public class Employee
{
    private string name;
    private decimal salary;
    private string position;
    private string department;
    private string email;
    private int age;

    public string Name { get; set; }
    public decimal Salary { get; set; }
    public string Position { get; set; }
    public string Department { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }

    public Employee(string name, string position, string department, decimal salary)
    {
        this.Name = name;
        this.Position = position;
        this.Department = department;
        this.Salary = salary;
        this.Email = "n/a";
        this.Age = -1;
    }
}
public class CompanyRoster
{
    public static void Main()
    {
        var departments = new List<Department>();

        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var employee_Information = Console.ReadLine().Split();
            var employee_Name = employee_Information[0];
            var salary = decimal.Parse(employee_Information[1]);
            var possition = employee_Information[2];
            var departmentName = employee_Information[3];

            if (!departments.Any(d => d.name == departmentName))
            {
                var department = new Department(departmentName);
                departments.Add(department);
            }

            if (!departments.Any(d => d.employees.Any(e => e.Name == employee_Name)))
            {
                var employee = new Employee(employee_Name, possition, departmentName, salary);

                if (employee_Information.Length == 6)
                {
                    employee.Email = employee_Information[4];
                    employee.Age = int.Parse(employee_Information[5]);
                }
                else if (employee_Information.Length == 5)
                {
                    if (employee_Information[4].Contains("@"))
                    {
                        employee.Email = employee_Information[4];
                    }
                    else
                    {
                        employee.Age = int.Parse(employee_Information[4]);
                    }
                }

                departments.FirstOrDefault(d => d.name == departmentName).employees.Add(employee);
            }
        }

        var average_Salary =
            departments
                .OrderByDescending(d => d.employees.Average(e => e.Salary))
                .FirstOrDefault();

        Console.WriteLine($"\nHighest average salary: \n{average_Salary.name}");

        foreach (var employee in average_Salary.employees.OrderByDescending(e => e.Salary))
        {
            Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
        }
    }
}
