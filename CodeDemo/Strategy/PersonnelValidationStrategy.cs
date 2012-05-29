namespace Strategy
{
    public class PersonnelValidationStrategy : IValidationStrategy
    {
        private string _rawRecord;
        private string _invalidReason;

        public PersonnelValidationStrategy(string record)
        {
            _rawRecord = record;
        }

        public bool IsValid()
        {
            string[] fields = new[] { "FIRSTNAME", "LASTNAME" };
            _invalidReason = string.Empty;

            foreach (var field in fields)
            {
                if (_rawRecord.Contains(field) == false)
                    _invalidReason += "\r\nMissing field:  " + field;

            }

            return string.IsNullOrEmpty(_invalidReason);
        }

        public string InvalidReason
        {
            get { return _invalidReason; }
        }
    }
}