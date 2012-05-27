namespace FactoryMethod
{
    public abstract class Employee
    {
        protected decimal _unitSalary;
        public Employee(decimal unitSalary)
        {
            _unitSalary = unitSalary;
        }

        public abstract decimal ComputeWages(int hours);
    }
}