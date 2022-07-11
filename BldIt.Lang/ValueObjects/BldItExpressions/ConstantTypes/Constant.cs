namespace BldIt.Lang.ValueObjects.BldItExpressions.ConstantTypes;

public class Constant<T> : Expression
{
    public T Value { get; }

    public Constant(T value)
    {
        Value = value;
    }

    public override string? ToString()
    {
        if (Value is null)
        {
            throw new ArgumentNullException(nameof(Value));
        }
        return Value.ToString();
    }
}