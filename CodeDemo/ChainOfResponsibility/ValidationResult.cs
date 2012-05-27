namespace ChainOfResponsibility
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public string InvalidReason { get; set; }
        public string SerialNumber { get; set; }

        public override string ToString()
        {
            if(!IsValid)
                return string.Format("Serial NUmber: \"{0}\" failed validation: {1}", SerialNumber,
                                 InvalidReason);

            return string.Format("Serial Number: \"{0}\" is valid.", SerialNumber);
        }
    }
}