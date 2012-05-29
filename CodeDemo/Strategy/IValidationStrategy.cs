namespace Strategy
{
    public interface IValidationStrategy
    {
        bool IsValid();
        string InvalidReason { get;}
    }
}