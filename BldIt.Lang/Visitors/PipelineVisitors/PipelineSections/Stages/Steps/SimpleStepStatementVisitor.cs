using BldIt.Lang.Exceptions;
using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItExpressions;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineParameterTypes;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps.SimpleStageSteps;

namespace BldIt.Lang.Visitors.PipelineVisitors.PipelineSections.Stages.Steps;

public class SimpleStepStatementVisitor : StepStatementVisitor
{
    public SimpleStepStatementVisitor(
        List<string> semanticErrors, 
        Dictionary<string, Expression> globalVariables, 
        Dictionary<string, Func<Expression?[], Expression?>> functions, 
        Dictionary<string, Expression> globalEnv, 
        HashSet<Parameter> parameters) 
        : base(semanticErrors, globalVariables, functions, globalEnv, parameters)
    { }

    public override SimpleStageStep VisitSimpleStepStatement(BldItParser.SimpleStepStatementContext context)
    {
        var stepStatementText = context.GetText();
        if (context.pipelineSimpleStepCall() is { } pipelineSimpleStepCall)
            return VisitPipelineSimpleStepCall(pipelineSimpleStepCall);
        throw new CompilingException($"Invalid step statement: {stepStatementText}");
    }

    public override SimpleStageStep VisitPipelineSimpleStepCall(BldItParser.PipelineSimpleStepCallContext context)
    {
        var stepIdentifier = context.IDENTIFIER().GetText();

        return stepIdentifier switch
        {
            "echo" => VisitEchoStep(context),
            //"run" => VisitRunStep(context),
            //"error" => VisitErrorStep(context),
            _ => throw new CompilingException($"Step {stepIdentifier} is not supported")
        };
    }
    
    private EchoStep VisitEchoStep(BldItParser.PipelineSimpleStepCallContext context)
    {
        var stepExpressions = context.pipelineExpression();
        
        if (stepExpressions.Length is < 1 or > 1)
            throw new CompilingException("Step 'echo' requires 1 argument");
        
        //TODO: Create PipelineExpressionVisitor
        var expression = VisitPipelineExpression(context.pipelineExpression()[0]);
        //return new EchoStep(stepIdentifier, expression);
        return new EchoStep();
    }
}