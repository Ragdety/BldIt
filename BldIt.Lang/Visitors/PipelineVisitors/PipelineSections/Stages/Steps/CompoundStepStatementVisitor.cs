﻿using BldIt.Lang.Exceptions;
using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItExpressions;
using BldIt.Lang.ValueObjects.BldItPipeline;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineParameterTypes;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps.CompoundStageSteps;
using BldIt.Lang.Visitors.StatementVisitors;

namespace BldIt.Lang.Visitors.PipelineVisitors.PipelineSections.Stages.Steps;

public class CompoundStepStatementVisitor : StepStatementVisitor
{
    private new bool IsInsideHandleError { get; set; }
    
    public CompoundStepStatementVisitor(List<string> semanticErrors,
        Dictionary<string, Expression> globalVariables,
        Dictionary<string, Func<Expression?[], Expression?>> functions,
        Dictionary<string, Expression> globalEnv,
        HashSet<Parameter> parameters,
        bool isInsideHandleError)
        : base(semanticErrors, globalVariables, functions, globalEnv, parameters)
    {
        IsInsideHandleError = isInsideHandleError;
    }

    public override CompoundStageStep VisitCompoundStepStatement(BldItParser.CompoundStepStatementContext context)
    {
        var stepText = context.GetText();
        if (context.scriptStep() is { } scriptStep)
            return VisitScriptStep(scriptStep);
        if (context.handleErrorStep() is {} handleErrorsStep)
            return VisitHandleErrorStep(handleErrorsStep);
        throw new CompilingException($"Invalid step: {stepText}");
    }

    public override CompoundStageStep VisitScriptStep(BldItParser.ScriptStepContext context)
    {
        return VisitScriptBlock(context.scriptBlock());
    }

    public override CompoundStageStep VisitHandleErrorStep(BldItParser.HandleErrorStepContext context)
    {
        var text = context.GetText();
        
        //This is when we enter handleError step
        IsInsideHandleError = true;
        HandleErrorStep handleErrorStep;

        switch (context.ChildCount)
        {
            //This matches rule: HANDLE_ERROR OPEN_PAREN CLOSE_PAREN COLON handleErrorBlock
            case 5:
                handleErrorStep = (HandleErrorStep) VisitHandleErrorBlock(context.handleErrorBlock());
                break;
            //This matches rule: HANDLE_ERROR OPEN_PAREN STRING COMMA STRING CLOSE_PAREN COLON handleErrorBlock
            case 8:
                var buildResult = context.STRING(0).GetText().Replace("\"", "");
                var stageResult = context.STRING(1).GetText().Replace("\"", "");

                CheckBuildResultValue(buildResult);
                CheckStageResultValue(stageResult);
                
                handleErrorStep = (HandleErrorStep) VisitHandleErrorBlock(context.handleErrorBlock());
                handleErrorStep.DesiredBuildResult = buildResult;
                handleErrorStep.DesiredStageResult = stageResult;
                break;
            default:
                throw new CompilingException($"Invalid HandleErrorStep: {text}");
        }
        
        //This is after visiting every step inside handleError so setting this to false
        IsInsideHandleError = false;
        
        return handleErrorStep;
    }

    public override StageStep VisitHandleErrorBlock(BldItParser.HandleErrorBlockContext context)
    {
        var handleErrorStep = new HandleErrorStep();
        var stepStatementVisitor = 
            new StepStatementVisitor(SemanticErrors, GlobalVariables, Functions, GlobalEnv, Parameters)
                {
                    IsInsideHandleError = IsInsideHandleError
                };

        foreach (var step in context.stepStatement())
        {
            var stepResult = stepStatementVisitor.VisitStepStatement(step);
            handleErrorStep.AddStepWithErrorHandling(stepResult);
        }

        return handleErrorStep;
    }

    public override ScriptStep VisitScriptBlock(BldItParser.ScriptBlockContext context)
    {
        throw new NotImplementedException();
        
        //TODO: Implement this method
        var scriptBlock = context.GetText();
        if (context.stepStatement() is { } stepStatement)
        {
            var stagesStatementVisitor =
                new StepStatementVisitor(SemanticErrors, GlobalVariables, Functions, GlobalEnv, Parameters);
            
            //Loop here
            //var stages = stagesStatementVisitor.VisitStepStatement(stepStatement);
            
            //return (ScriptStep) stages;
        }
           
        if (context.statements() is not { } scriptStatement)
            throw new CompilingException($"Invalid script block: {scriptBlock}");
        
        var stageStep = new ScriptStep();
            
        var statementsVisitor = new StatementVisitor(SemanticErrors, GlobalVariables, Functions);
        var statementResult = statementsVisitor.Visit(scriptStatement);
        
        return stageStep;

    }
    
    private static void CheckBuildResultValue(string buildResult)
    {
        switch (buildResult)
        {
            case PipelineConstants.BuildConstants.BuildFailureValue:
            case PipelineConstants.BuildConstants.BuildSuccessValue:
                return;
            default:
                throw new CompilingException($"Invalid build result {buildResult}. Must be " +
                                             $"either {PipelineConstants.BuildConstants.BuildFailureValue} " +
                                             $"or {PipelineConstants.BuildConstants.BuildSuccessValue}");
        }
    }
    
    private static void CheckStageResultValue(string stageResult)
    {
        switch (stageResult)
        {
            case PipelineConstants.StageConstants.StageFailureValue:
            case PipelineConstants.StageConstants.StageSuccessValue:
                return;
            default:
                throw new CompilingException($"Invalid stage result {stageResult}. Must be " +
                                             $"either {PipelineConstants.StageConstants.StageFailureValue} " +
                                             $"or {PipelineConstants.StageConstants.StageSuccessValue}");
        }
    }
}