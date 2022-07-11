namespace BldIt.Lang.ValueObjects.BldItExpressions.ConstantTypes;

public class NullValue : Constant<object?>
{
    public NullValue(object? value) : base(value) { }
    
    public override string ToString() => "null";
}