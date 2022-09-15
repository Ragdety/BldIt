using BldIt.Lang.Exceptions;
using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItExpressions;
using BldIt.Lang.ValueObjects.BldItExpressions.ConstantTypes;
using BldIt.Lang.ValueObjects.BldItExpressions.ExpressionHelpers;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineExpressions;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineParameterTypes;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps.SimpleStageSteps;
using BldIt.Lang.Visitors.PipelineVisitors.PipelineExpressions;

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
            "error" => VisitErrorStep(context),
            _ => throw new CompilingException($"Step {stepIdentifier} is not supported")
        };
    }
    
    private EchoStep VisitEchoStep(BldItParser.PipelineSimpleStepCallContext context)
    {
        var stepExpressions = context.pipelineExpression();
        
        if (stepExpressions.Length is < 1 or > 1)
            throw new CompilingException("Step \'echo\' requires 1 argument");
        
        var pipelineExpressionVisitor = new PipelineExpressionVisitor(SemanticErrors, GlobalVariables, Functions, GlobalEnv, Parameters);
        var expressionResult = pipelineExpressionVisitor.VisitPipelineExpression(context.pipelineExpression()[0]);
        var exprTypeValueObject = ExpressionTypeHelper.GetValueFromType(expressionResult);

        Console.WriteLine(exprTypeValueObject.ToString());
        
        return new EchoStep(exprTypeValueObject.ToString());
    }
    
    private ErrorStep VisitErrorStep(BldItParser.PipelineSimpleStepCallContext context)
    {
        var stepExpressions = context.pipelineExpression();
        
        if (stepExpressions.Length is < 1 or > 1)
            throw new CompilingException("Step \'error\' requires 1 argument");
        
        var pipelineExpressionVisitor = new PipelineExpressionVisitor(SemanticErrors, GlobalVariables, Functions, GlobalEnv, Parameters);
        var expressionResult = pipelineExpressionVisitor.VisitPipelineExpression(context.pipelineExpression()[0]);
        var exprTypeValueObject = ExpressionTypeHelper.GetValueFromType(expressionResult);

        Console.Error.WriteLine(exprTypeValueObject.ToString());
        
        return new ErrorStep(exprTypeValueObject.ToString());
    }
}