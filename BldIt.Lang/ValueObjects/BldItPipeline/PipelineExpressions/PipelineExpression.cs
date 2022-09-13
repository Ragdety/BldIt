using BldIt.Lang.ValueObjects.BldItExpressions;
using BldIt.Lang.ValueObjects.BldItExpressions.ExpressionTypes;

namespace BldIt.Lang.ValueObjects.BldItPipeline.PipelineExpressions;

public class PipelineExpression : Expression
{
    public PipelineExpression(ExpressionType expressionType) : base(expressionType)
    { }
}