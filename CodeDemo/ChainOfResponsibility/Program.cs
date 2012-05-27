using System;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialNumberValidator serialNumberValidator = new SerialNumberValidator(null);

            ValidationResult validationResult = serialNumberValidator.IsValid("ABC 123");
            Console.WriteLine(validationResult);

            validationResult = serialNumberValidator.IsValid("");
            Console.WriteLine(validationResult);

            validationResult = serialNumberValidator.IsValid("MYSERIAL!@#$%^&");
            Console.WriteLine(validationResult);

            serialNumberValidator = new SerialNumberValidator(new SerialNumberCannotContainInvalidCharacters());
            validationResult = serialNumberValidator.IsValid("MYSERIAL!@#$%^&");
            Console.WriteLine(validationResult);

            Console.ReadLine();
        }
    }

    public class SerialNumberCannotContainInvalidCharacters : SerialNumberRuleHandler
    {
        public override void Handle(string serialNumber, ValidationResult result)
        {
            foreach(var invalidChar in "*%|'`")
            {
                if(serialNumber.Contains(invalidChar.ToString()))
                {
                    result.IsValid = false;
                    result.InvalidReason = string.Format("Serial number cannot contain the character \"{0}\"", invalidChar);
                }
            }

            if(result.IsValid)
                base.Handle(serialNumber, result);
        }
    }
}
