namespace ChainOfResponsibility
{
    public interface ISerialNumberRuleHandler
    {
        ISerialNumberRuleHandler Successor { get; set; }
        void Handle(string serialNumber, ValidationResult result);
    }
}