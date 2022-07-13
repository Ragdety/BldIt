namespace BldIt.Lang.ValueObjects.BldItExpressions.ExpressionTypes;

public enum ExpressionType
{
    Constant,
    Identifier,
    FunctionCall,
    Parenthesized,
    Not,
    Multiplicative,
    Additive,
    Comparison,
    Boolean
}