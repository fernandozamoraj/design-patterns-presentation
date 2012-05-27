namespace ChainOfResponsibility
{
    public class SerialNumberValidator
    {
        protected ISerialNumberRuleHandler _handler;

        public SerialNumberValidator(ISerialNumberRuleHandler handler)
        {
            _handler = GetCommonRules();

            AppendAdditionHandlerToTailEnd(handler);
        }

        public ValidationResult IsValid(string serialNumber)
        {
            ValidationResult validationResult = InitializeValidationResult(serialNumber);

            _handler.Handle(serialNumber, validationResult);

            return validationResult;
        }

        protected ValidationResult InitializeValidationResult(string serialNumber)
        {
            ValidationResult validationResult = new ValidationResult();
            validationResult.IsValid = true;
            validationResult.InvalidReason = string.Empty;
            validationResult.SerialNumber = serialNumber;

            return validationResult;
        }

        protected void AppendAdditionHandlerToTailEnd(ISerialNumberRuleHandler handler)
        {
            ISerialNumberRuleHandler tempHandler = _handler.Successor;

            while (true)
            {
                if (tempHandler.Successor != null)
                    tempHandler = tempHandler.Successor;
                else
                {
                    tempHandler.Successor = handler;
                    break;
                }
            }
        }

        protected ISerialNumberRuleHandler GetCommonRules()
        {
            _handler = new SerialNumberCannotBeEmpty();
            _handler.Successor = new SerialNumberCannotContainSpaces();
            return _handler;
        }
    }
}