namespace Observer.example1
{
    public interface IColumnChangingObserver
    {
        void Handle(DemoDataRow row, ColumnChangedArgs columnChangedArgs);
    }
}