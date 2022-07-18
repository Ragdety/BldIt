using BldIt.Lang.ValueObjects.BldItExpressions.ExpressionTypes;

namespace BldIt.Lang.ValueObjects.BldItExpressions;

public class VoidValue : Expression
{
    public VoidValue() : base(ExpressionType.Void)
    {
    }
    
    public override string ToString()
    {
        return "void";
    }
}