namespace FactoryMethod
{
    public class HourlyExemptEmployee : Employee
    {
        public HourlyExemptEmployee(decimal unitSalary)
            : base(unitSalary)
        {
        }

        public override decimal ComputeWages(int hours)
        {
            decimal grossWages = 0;

            grossWages = hours * _unitSalary;

            return grossWages;
        }
    }
}