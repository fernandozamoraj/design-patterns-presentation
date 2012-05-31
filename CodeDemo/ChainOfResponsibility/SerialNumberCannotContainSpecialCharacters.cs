namespace ChainOfResponsibility
{
    public class SerialNumberCannotContainSpecialCharacters : SerialNumberRuleHandler
    {
        public override void Handle(string serialNumber, ValidationResult result)
        {
            foreach(var invalidChar in "!@#$%^&*()_+-=`~;':\",.<>?/|\\{}[]")
            {
                if(serialNumber.Contains(invalidChar.ToString()))
                {
                    result.IsValid = false;
                    result.InvalidReason = string.Format("Serial number cannot contain the character \"{0}\"", invalidChar);
                    break;
                }
            }

            if(result.IsValid)
                base.Handle(serialNumber, result);
        }
    }
}