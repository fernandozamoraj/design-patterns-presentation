namespace Observer.example1
{
    public class ColumnChangedArgs
    {
        public string ColumnName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public bool CancelEvent { get; set; }
    }
}