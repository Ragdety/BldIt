using System.Globalization;

namespace BldIt.Lang.ValueObjects.BldItExpressions.ConstantTypes;

public class FloatValue : Constant<float>
{
    public FloatValue(float value) : base(value) { }

    public override string ToString()
    {
        return Value.ToString(CultureInfo.InvariantCulture);
    }
}