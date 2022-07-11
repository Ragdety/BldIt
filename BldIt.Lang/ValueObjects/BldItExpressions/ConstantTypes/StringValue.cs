namespace BldIt.Lang.ValueObjects.BldItExpressions.ConstantTypes;

public class StringValue : Constant<string>
{
    public StringValue(string value) : base(value) { }

    public override string ToString()
    {
        return Value;
    }
}