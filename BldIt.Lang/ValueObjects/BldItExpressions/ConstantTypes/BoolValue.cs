namespace BldIt.Lang.ValueObjects.BldItExpressions.ConstantTypes;

public class BoolValue : Constant<bool>
{
    public BoolValue(bool value) : base(value) { }

    public override string ToString()
    {
        return Value ? "true" : "false"; 
    }
}