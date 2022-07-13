using BldIt.Lang.ValueObjects.BldItExpressions.ExpressionTypes;

namespace BldIt.Lang.ValueObjects.BldItExpressions;

public class Identifier : Expression
{
    public string Id { get; set; }

    public Identifier(string id) : base(ExpressionType.Identifier)
    {
        Id = id;
    }

    public override string ToString()
    {
        return Id;
    }
}