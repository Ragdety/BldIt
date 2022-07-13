using BldIt.Lang.ValueObjects.BldItExpressions.ExpressionTypes;

namespace BldIt.Lang.ValueObjects.BldItExpressions.ConstantTypes;

public class NullValue : Constant<object?>
{
    public NullValue(object? value) : base(value, ExpressionType.Constant) { }
    
    public override Type Type => typeof(object);
    
    public override string ToString() => "null";
}