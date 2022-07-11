namespace BldIt.Lang.ValueObjects.BldItExpressions;

public class Identifier : Expression
{
    public string Id { get; set; }

    public Identifier(string id)
    {
        Id = id;
    }

    public override string ToString()
    {
        return Id;
    }
}