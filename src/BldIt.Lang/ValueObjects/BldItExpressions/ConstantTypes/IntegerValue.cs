using BldIt.Lang.ValueObjects.BldItExpressions.ExpressionTypes;

namespace BldIt.Lang.ValueObjects.BldItExpressions.ConstantTypes;

public class IntegerValue : Constant<int>
{
    public IntegerValue(int value) : base(value, ExpressionType.Constant) { }
    
    public override Type Type => typeof(int);

    public override string ToString()
    {
        return Value.ToString();
    }
}