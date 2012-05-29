using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            RecordProcessor recordProcessor = new RecordProcessor();


            recordProcessor.ProcessRecords( GetRecords());

            Console.ReadLine();
        }

        private static List<string> GetRecords()
        {
            return new List<string>
                       {
                           "EQUIPMENT,SERIALNUMBER:1234,",
                           "EQUIPMENT,SERIALNUMBER:1234,DESCRIPTION:PRINTER LEXMARK,PRODUCTID:LXMR5600",
                           "PERSONNEL,FIRSTNAME:JOHN",
                           "PERSONNEL,FIRSTNAME:JANE,LASTNAME:DOE",
                           "COMPONENT,DESCRIPTION:TRANSMISSION,SERIALNUMBER:ABCDEFG"
                       };
        }
    }
}
