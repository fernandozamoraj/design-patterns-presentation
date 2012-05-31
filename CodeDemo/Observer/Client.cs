using System;
using Observer.example1;

namespace Observer
{
    public class Client : IColumnChangedObserver, IColumnChangingObserver
    {
        /// <summary>
        /// Demonstrates the ColumnChangedEvent via an interface
        /// </summary>
        public void RunDemo1()
        {
            DemoDataRow dataRow = new DemoDataRow();
            dataRow.AttachColumnChangedObserver(this);

            dataRow["FirstName"] = "John";
            dataRow["LastName"] = "Doe";
            dataRow["FirstName"] = "Jane";

            dataRow.ToConsole();

            Console.ReadLine();
        }

        /// <summary>
        /// Demonstrates the column changing event
        /// </summary>
        public void RunDemo2()
        {
            DemoDataRow dataRow = new DemoDataRow();
            dataRow.AttachColumnChangedObserver(this);
            dataRow.AttachColumnChangedObserver(this);
            dataRow.AttachColumnChangingObserver(this);

            dataRow["FirstName"] = "John";
            dataRow["LastName"] = "Doe";
            dataRow["FirstName"] = "*Jane%";
            dataRow["Age"] = "39";
            dataRow["Age"] = "40";

            dataRow.ToConsole();

            Console.ReadLine();
        }

        /// <summary>
        /// Demonstates the ColumnDeleted event using a pseudo delegate (function pointer in other languages)
        /// </summary>
        public void RunDemo3()
        {
            DemoDataRow dataRow = new DemoDataRow();
            dataRow.AttachColumnDeletedObserver(OnColumnDeleted);

            dataRow["FirstName"] = "John";
            dataRow["LastName"] = "Doe";
            dataRow["Age"] = "34";

            dataRow.DeleteColumn("LastName");

            dataRow.ToConsole();

            Console.ReadLine();
        }

        void OnColumnDeleted(DemoDataRow row, ColumnChangedArgs columnChangedArgs)
        {
            Console.WriteLine("The following column: {0} with the value: {1} was deleted.", columnChangedArgs.ColumnName, columnChangedArgs.OldValue);
        }

        void IColumnChangedObserver.Handle(DemoDataRow row, ColumnChangedArgs columnChangedArgs)
        {
            Console.WriteLine("Data was changed as follows: Column Name: {0} Changed From: {1} To: {2}", 
                              columnChangedArgs.ColumnName, columnChangedArgs.OldValue, columnChangedArgs.NewValue);
        }

        void IColumnChangingObserver.Handle(DemoDataRow row, ColumnChangedArgs columnChangedArgs)
        {
            if(ContainsInvalidCharacters(columnChangedArgs.NewValue))
            {
                Console.WriteLine("The newValue {0} has invalid characters changed rejected", columnChangedArgs.NewValue);
                columnChangedArgs.CancelEvent = true;
            }
        }

        private bool ContainsInvalidCharacters(string newValue)
        {
            foreach (var invalidChar in "!@#$%^&*()_+-=,./<>?;\':\"~")
            {
                if (newValue.Contains(invalidChar.ToString()))
                {
                    return true;
                }
            }

            return false;
        }
    }
}