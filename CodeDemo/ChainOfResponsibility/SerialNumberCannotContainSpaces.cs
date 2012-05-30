namespace ChainOfResponsibility
{
    public class SerialNumberCannotContainSpaces : SerialNumberRuleHandler
    {
        public override void Handle(string serialNumber, ValidationResult result)
        {
            if (serialNumber.Contains(" "))
            {
                result.IsValid = false;
                result.InvalidReason = "Serial Number cannot contain any spaces";
                return;
            }

            base.Handle(serialNumber, result);
        }
    }
}