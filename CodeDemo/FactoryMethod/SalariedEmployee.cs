namespace FactoryMethod
{
    public class SalariedEmployee : Employee
    {
        public SalariedEmployee(decimal unitSalary) : base(unitSalary)
        {
        }

        public override decimal ComputeWages(int hours)
        {
            return _unitSalary / 52m;
        }
    }
}