namespace Observer.example1
{
    public interface IColumnChangedObserver
    {
        void Handle(DemoDataRow row, ColumnChangedArgs columnChangedArgs);
    }
}