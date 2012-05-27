namespace FactoryMethod
{
    public class HourlyNonExemptEmployee : Employee
    {
        public HourlyNonExemptEmployee(decimal unitSalary) : base(unitSalary)
        {
        }

        public override decimal ComputeWages(int hours)
        {
            decimal grossWages = 0;

            int overtimeHours = hours - 40;

            if(overtimeHours > 0)
            {
                grossWages = 40 * _unitSalary;
                grossWages += (_unitSalary*(overtimeHours*1.5m));
            }

            return grossWages;
        }
    }
}