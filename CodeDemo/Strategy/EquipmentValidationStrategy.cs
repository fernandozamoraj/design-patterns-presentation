namespace Strategy
{
    public class EquipmentValidationStrategy : IValidationStrategy
    {
        private string _rawRecord;
        private string _invalidReason;

        public EquipmentValidationStrategy(string record)
        {
            _rawRecord = record;
        }

        public bool IsValid()
        {
            string[] fields = new []{"PRODUCTID", "SERIALNUMBER", "DESCRIPTION"};
            _invalidReason = string.Empty;

            foreach(var field in fields)
            {
                if (_rawRecord.Contains(field) == false)
                    _invalidReason += "\r\n!!Missing field:  " + field;

            }

            return string.IsNullOrEmpty(_invalidReason);
        }

        public string InvalidReason
        {
            get { return _invalidReason; }

        }
    }
}