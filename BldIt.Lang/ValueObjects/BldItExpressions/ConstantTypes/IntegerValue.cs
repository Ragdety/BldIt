namespace BldIt.Lang.ValueObjects.BldItExpressions.ConstantTypes;

public class IntegerValue : Constant<int>
{
    public IntegerValue(int value) : base(value) { }

    public override string ToString()
    {
        return Value.ToString();
    }
}