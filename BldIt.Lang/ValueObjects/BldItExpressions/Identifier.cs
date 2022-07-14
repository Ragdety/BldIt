using BldIt.Lang.ValueObjects.BldItExpressions.ExpressionTypes;

namespace BldIt.Lang.ValueObjects.BldItExpressions;

public class Identifier : Expression
{
    public string Id { get; }
    public Expression Value { get; }

    public override Type Type => Value.GetType();

    public Identifier(string id, Expression value) : base(ExpressionType.Identifier)
    {
        Id = id;
        Value = value;
    }

    public override string ToString()
    {
        return Id;
    }
}