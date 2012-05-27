namespace ChainOfResponsibility
{
    public abstract class SerialNumberRuleHandler : ISerialNumberRuleHandler
    {
        public ISerialNumberRuleHandler Successor { get; set; }

        public virtual void Handle(string serialNumber, ValidationResult result)
        {
            PreHandle(serialNumber, result);

            if(Successor != null)
            {
                Successor.Handle(serialNumber, result);
            }
        }

        protected void PreHandle(string serialNumber, ValidationResult result)
        {
            result.IsValid = true;
            result.InvalidReason = string.Empty;
            result.SerialNumber = serialNumber;
        }
    }
}