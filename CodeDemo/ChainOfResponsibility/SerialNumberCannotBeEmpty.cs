namespace ChainOfResponsibility
{
    public class SerialNumberCannotBeEmpty : SerialNumberRuleHandler
    {
        public override void Handle(string serialNumber, ValidationResult result)
        {
            if(string.IsNullOrEmpty(serialNumber))
            {
                result.IsValid = false;
                result.InvalidReason = "Serial Number Cannot Be Empty";
                return;
            }

            base.Handle(serialNumber, result);
        }
    }
}