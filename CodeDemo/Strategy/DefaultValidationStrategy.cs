namespace Strategy
{
    public class DefaultValidationStrategy : IValidationStrategy
    {
        private string _rawRecord;


        public DefaultValidationStrategy(string record)
        {
            _rawRecord = record;
        }

        public bool IsValid()
        {
            return false;
        }

        public string InvalidReason
        {
            get { return "Unknown Record Type"; }
        }

    }
}