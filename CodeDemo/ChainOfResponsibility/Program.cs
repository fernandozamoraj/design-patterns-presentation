using System;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialNumberValidator serialNumberValidator = new SerialNumberValidator(null);

            ValidationResult validationResult = 
                serialNumberValidator.IsValid("ABC 123");
            Console.WriteLine(validationResult);

            validationResult = serialNumberValidator.IsValid("");
            Console.WriteLine(validationResult);

            validationResult = serialNumberValidator.IsValid("MYSERIAL!@#$%^&");
            Console.WriteLine(validationResult);

            Console.WriteLine("\r\n\r\n**********TEST WITH EXTENSION RULES(no Special Characters)*******************\r\n");

            var serialNumberCannotContainSpecialChars = new SerialNumberCannotContainSpecialCharacters();
            serialNumberCannotContainSpecialChars.Successor = new SerialNumberCannotContainMoreThan20Characters();

            serialNumberValidator = new SerialNumberValidator(serialNumberCannotContainSpecialChars);
            validationResult = serialNumberValidator.IsValid("ABC 123");
            Console.WriteLine(validationResult);

            validationResult = serialNumberValidator.IsValid("");
            Console.WriteLine(validationResult);

            validationResult = serialNumberValidator.IsValid("MYSERIAL!@#$%^&");
            Console.WriteLine(validationResult);

            validationResult = serialNumberValidator.IsValid("ABCDEFGHIJKLM1234567");
            Console.WriteLine(validationResult);

            validationResult = serialNumberValidator.IsValid("ABCDEFGHIJKLM1234567890");
            Console.WriteLine(validationResult);


            Console.ReadLine();
        }
    }

    public class SerialNumberCannotContainMoreThan20Characters : SerialNumberRuleHandler
    {
        public override void Handle(string serialNumber, ValidationResult result)
        {
            if(serialNumber.Length > 20)
            {
                result.IsValid = false;
                result.InvalidReason = "Serial number should be 20 characters or less.";
                return;
            }

            base.Handle(serialNumber, result);
        }
    }
}
