namespace ChainOfResponsibility
{
    public class SerialNumberCannotContainSpaces : SerialNumberRuleHandler
    {
        public override void Handle(string serialNumber, ValidationResult result)
        {
            if (serialNumber.Contains(" "))
            {
                result.IsValid = false;
                result.InvalidReason = "Serial Number Cannot Spaces";
                return;
            }

            base.Handle(serialNumber, result);
        }
    }
}