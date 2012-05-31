using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee hourlyExemptEmployee = GetEmployee(EmployeeType.HourlyExcempt);
            Employee hourlyNonExemptEmployee = GetEmployee(EmployeeType.HourlyNonExempt);
            Employee salariedEmployee = GetEmployee(EmployeeType.Salaried);

            Console.WriteLine("Wages for 50 hours for hourly exempt employee are {0}", hourlyExemptEmployee.ComputeWages(50));
            Console.WriteLine("Wages for 50 hours for hourly non-exempt employee are {0}", hourlyNonExemptEmployee.ComputeWages(50));
            Console.WriteLine("Wages for 50 hours for hourly salaried employee are {0}", salariedEmployee.ComputeWages(50));

            Console.ReadLine();
        }



        static Employee GetEmployee(EmployeeType employeeType)
        {
            Employee employee;

            switch (employeeType)
            {
                case EmployeeType.Salaried:
                    employee = new SalariedEmployee(52000);
                    break;
                case EmployeeType.HourlyExcempt:
                    employee = new HourlyExemptEmployee(25);
                    break;
                default:
                    employee = new HourlyNonExemptEmployee(20);
                    break;
            }

            return employee;
        }
    }
}
