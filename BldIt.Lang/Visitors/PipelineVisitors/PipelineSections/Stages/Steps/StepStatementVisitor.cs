﻿using BldIt.Lang.Exceptions;
using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItExpressions;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineParameterTypes;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps;

namespace BldIt.Lang.Visitors.PipelineVisitors.PipelineSections.Stages.Steps;

public class StepStatementVisitor : BldItParserBaseVisitor<StageStep>
{
    protected List<string> SemanticErrors { get; }
    protected Dictionary<string, Expression> GlobalVariables { get; }
    protected Dictionary<string, Func<Expression?[], Expression?>> Functions { get; }
    protected Dictionary<string, Expression> GlobalEnv { get; }
    protected HashSet<Parameter> Parameters { get; }

    public StepStatementVisitor(
        List<string> semanticErrors, 
        Dictionary<string, Expression> globalVariables,
        Dictionary<string, Func<Expression?[], Expression?>> functions, 
        Dictionary<string, Expression> globalEnv, 
        HashSet<Parameter> parameters)
    {
        SemanticErrors = semanticErrors;
        GlobalVariables = globalVariables;
        Functions = functions;
        GlobalEnv = globalEnv;
        Parameters = parameters;
    }

    public override StageStep VisitStepStatement(BldItParser.StepStatementContext context)
    {
        var stepStatementText = context.GetText();
        if (context.simpleStepStatement() is {} simpleStepStatement)
            return VisitSimpleStepStatement(simpleStepStatement);
        if (context.compoundStepStatement() is { } compoundStepStatement)
            return VisitCompoundStepStatement(compoundStepStatement);
        throw new CompilingException($"Invalid step statement: {stepStatementText}");
    }

    public override SimpleStageStep VisitSimpleStepStatement(BldItParser.SimpleStepStatementContext context)
    {
        return new SimpleStepStatementVisitor(
                SemanticErrors, 
                GlobalVariables, 
                Functions, 
                GlobalEnv, 
                Parameters)
            .VisitSimpleStepStatement(context);
    }

    public override CompoundStageStep VisitCompoundStepStatement(BldItParser.CompoundStepStatementContext context)
    {
        return new CompoundStepStatementVisitor(
                SemanticErrors, 
                GlobalVariables, 
                Functions, 
                GlobalEnv, 
                Parameters)
            .VisitCompoundStepStatement(context);
    }
}