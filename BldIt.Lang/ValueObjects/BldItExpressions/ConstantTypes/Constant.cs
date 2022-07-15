using BldIt.Lang.ValueObjects.BldItExpressions.ExpressionTypes;

namespace BldIt.Lang.ValueObjects.BldItExpressions.ConstantTypes;

public class Constant<T> : Expression
{
    public T Value { get; set; }
    
    /// <summary>
    /// Gets the static type of the constant that its generic value T represents.
    /// </summary>
    /// <returns>The <see cref="System.Type"/> that represents the static type of the constant expression.</returns>
    public override Type Type => Value == null ? typeof(object) : Value.GetType();

    protected Constant(T value, ExpressionType expressionType) : base (expressionType)
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