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
            //"error" => VisitErrorStep(context),
            _ => throw new CompilingException($"Step {stepIdentifier} is not supported")
        };
    }
    
    private EchoStep VisitEchoStep(BldItParser.PipelineSimpleStepCallContext context)
    {
        var stepExpressions = context.pipelineExpression();
        var stepIdentifier = context.IDENTIFIER().GetText();
        
        if (stepExpressions.Length is < 1 or > 1)
            throw new CompilingException("Step 'echo' requires 1 argument");
        
        var pipelineExpressionVisitor = new PipelineExpressionVisitor(SemanticErrors, GlobalVariables, Functions, GlobalEnv, Parameters);
        
        var pipelineExpressionText = context.pipelineExpression()[0].GetText();
        var expressionResult = pipelineExpressionVisitor.VisitPipelineExpression(context.pipelineExpression()[0]);
        var exprType = expressionResult.Type;
        
        var exprTypeValueObject = ExpressionTypeHelper.GetValueFromType(expressionResult);
        object value;

        switch (exprTypeValueObject)
        {
            case IntegerValue:
            {
                if (expressionResult is not IntegerValue valueObject)
                    throw new CompilingException($"Pipeline expression {pipelineExpressionText} is not valid");
                value = new IntegerValue(valueObject.Value);
                break;
            }
            case FloatValue:
            {
                if (expressionResult is not FloatValue valueObject)
                    throw new CompilingException($"Pipeline expression {pipelineExpressionText} is not valid");
                value = new FloatValue(valueObject.Value);
                break;
            }
            case StringValue:
            {
                if (expressionResult is not StringValue valueObject)
                    throw new CompilingException($"Pipeline expression {pipelineExpressionText} is not valid");
                value = new StringValue(valueObject.Value);
                break;
            }
            case BoolValue:
            {
                if (expressionResult is not BoolValue valueObject)
                    throw new CompilingException($"Pipeline expression {pipelineExpressionText} is not valid");
                value = new BoolValue(valueObject.Value);
                break;
            }
            default:
                throw new CompilingException($"Invalid expression type {exprType} for step {stepIdentifier}");
        }
        
        Console.WriteLine(value.ToString());
        
        return new EchoStep(stepIdentifier, value.ToString());
    }
}