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

            Console.WriteLine("\r\n\r\n**********TEST WITH EXTENSION RULES(no Special Characters)*******************\r\n");

            serialNumberValidator = new SerialNumberValidator(new SerialNumberCannotContainSpecialCharacters());
            validationResult = serialNumberValidator.IsValid("ABC 123");
            Console.WriteLine(validationResult);

            validationResult = serialNumberValidator.IsValid("");
            Console.WriteLine(validationResult);

            validationResult = serialNumberValidator.IsValid("MYSERIAL!@#$%^&");
            Console.WriteLine(validationResult);

            Console.ReadLine();
        }
    }
}
