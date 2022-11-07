using BldIt.Lang.ValueObjects.BldItExpressions.ExpressionTypes;

namespace BldIt.Lang.ValueObjects.BldItExpressions.ConstantTypes;

public class StringValue : Constant<string>
{
    public StringValue(string value) : base(value, ExpressionType.Constant) { }
    
    public override Type Type => typeof(string);

    public override string ToString()
    {
        return Value;
    }
}