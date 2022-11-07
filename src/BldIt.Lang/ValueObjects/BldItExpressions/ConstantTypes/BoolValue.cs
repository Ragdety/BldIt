using BldIt.Lang.ValueObjects.BldItExpressions.ExpressionTypes;

namespace BldIt.Lang.ValueObjects.BldItExpressions.ConstantTypes;

public class BoolValue : Constant<bool>
{
    public BoolValue(bool value) : base(value, ExpressionType.Boolean) { }

    public override Type Type => typeof(bool);
    
    public override string ToString()
    {
        return Value ? "true" : "false"; 
    }
}