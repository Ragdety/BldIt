namespace BldIt.Lang.ValueObjects.BldItExpressions.ExpressionTypes;

public enum ExpressionType
{
    Constant,
    Void,
    Identifier,
    FunctionCall,
    Parenthesized,
    Not,
    Multiplicative,
    Additive,
    Comparison,
    Boolean
}