using System;
using System.Collections.Generic;

namespace Strategy
{
    public class RecordProcessor
    {
        public void ProcessRecords(List<string> records)
        {
            foreach(string record in records)
            {
                IValidationStrategy validationStrategy;

                if (IsPersonnelRecord(record))
                    validationStrategy = new PersonnelValidationStrategy(record);
                else if (IsEquimentRecord(record))
                    validationStrategy = new EquipmentValidationStrategy(record);
                else
                    validationStrategy = new DefaultValidationStrategy(record);

                if(validationStrategy.IsValid())
                {
                    PushToDatabase(record);
                }
                else
                {
                    PustToErrorLog(record, validationStrategy.InvalidReason);
                }
            }
        }

        private void PustToErrorLog(string record, string invalidReason)
        {
            Console.WriteLine(record);
            Console.WriteLine("Rejected for: " + invalidReason);
            Console.WriteLine();
        }

        private void PushToDatabase(string record)
        {
            Console.WriteLine(record);
            Console.WriteLine("Pushed to database...");
            Console.WriteLine();
        }

        private bool IsEquimentRecord(string record)
        {
            return record.IndexOf("EQUIPMENT", System.StringComparison.Ordinal) == 0;
        }

        private bool IsPersonnelRecord(string record)
        {
            return record.IndexOf("PERSONNEL", System.StringComparison.Ordinal) == 0;
        }
    }
}