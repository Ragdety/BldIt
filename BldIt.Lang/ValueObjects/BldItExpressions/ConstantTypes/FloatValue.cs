using System.Globalization;
using BldIt.Lang.ValueObjects.BldItExpressions.ExpressionTypes;

namespace BldIt.Lang.ValueObjects.BldItExpressions.ConstantTypes;

public class FloatValue : Constant<float>
{
    public FloatValue(float value) : base(value, ExpressionType.Constant) { }

    public override Type Type => typeof(float);

    public override string ToString()
    {
        return Value.ToString(CultureInfo.InvariantCulture);
    }
}