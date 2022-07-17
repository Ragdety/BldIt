namespace BldIt.Lang.ValueObjects.BldItPipeline.PipelineExpressions;

public abstract class PipelineExpression
{
    public PipelineExpressionType PipelineExpressionType { get; }

    //Default implementation of Type
    public virtual Type Type => GetType();

    protected PipelineExpression(PipelineExpressionType pipelineExpressionType)
    {
        PipelineExpressionType = pipelineExpressionType;
    }
}