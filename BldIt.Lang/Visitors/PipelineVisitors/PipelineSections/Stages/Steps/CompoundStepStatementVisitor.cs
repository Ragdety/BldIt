using System.Diagnostics;
using BldIt.Lang.Exceptions;
using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItExpressions;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineParameterTypes;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps;
using BldIt.Lang.Visitors.StatementVisitors;

namespace BldIt.Lang.Visitors.PipelineVisitors.PipelineSections.Stages.Steps;

public class CompoundStepStatementVisitor : StepStatementVisitor
{
    public CompoundStepStatementVisitor(
        List<string> semanticErrors, 
        Dictionary<string, Expression> globalVariables, 
        Dictionary<string, Func<Expression?[], Expression?>> functions, 
        Dictionary<string, Expression> globalEnv, 
        HashSet<Parameter> parameters) 
        : base(semanticErrors, globalVariables, functions, globalEnv, parameters)
    { }

    public override CompoundStageStep VisitCompoundStepStatement(BldItParser.CompoundStepStatementContext context)
    {
        var stepText = context.GetText();
        if (context.scriptStep() is { } scriptStep)
            return VisitScriptStep(scriptStep);
        if (context.handleErrorsStep() is {} handleErrorsStep)
            return VisitHandleErrorsStep(handleErrorsStep);
        throw new CompilingException($"Invalid step: {stepText}");
    }

    public override CompoundStageStep VisitScriptStep(BldItParser.ScriptStepContext context)
    {
        return VisitScriptBlock(context.scriptBlock());
    }

    public override CompoundStageStep VisitHandleErrorsStep(BldItParser.HandleErrorsStepContext context)
    {
        throw new NotImplementedException();
    }

    public override ScriptStep VisitScriptBlock(BldItParser.ScriptBlockContext context)
    {
        throw new NotImplementedException();
        
        //TODO: Implement this method
        var scriptBlock = context.GetText();
        if (context.stepStatements() is { } stepStatements)
        {
            var stagesStatementVisitor =
                new StepStatementVisitor(SemanticErrors, GlobalVariables, Functions, GlobalEnv, Parameters);
            
            var stages = stagesStatementVisitor.VisitStepStatements(stepStatements);
            
            return (ScriptStep) stages;
        }
           
        if (context.statements() is not { } scriptStatement)
            throw new CompilingException($"Invalid script block: {scriptBlock}");
        
        var stageStep = new ScriptStep("script");
            
        var statementsVisitor = new StatementVisitor(SemanticErrors, GlobalVariables, Functions);
        var statementResult = statementsVisitor.Visit(scriptStatement);
        
        return stageStep;

    }
}