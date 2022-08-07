using BldIt.Lang.Exceptions;
using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItExpressions;
using BldIt.Lang.ValueObjects.BldItPipeline;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages;
using BldIt.Lang.Visitors.ExpressionVisitors;
using BldIt.Lang.Visitors.PipelineVisitors.PipelineSections;

namespace BldIt.Lang.Visitors.PipelineVisitors;

public class PipelineVisitor : BldItParserBaseVisitor<Pipeline>
{
    /// <summary>
    /// Represents semantic errors when parsing the file
    /// </summary>
    protected List<string> SemanticErrors { get; }
    
    /// <summary>
    /// Represents global variables defined before the pipeline.
    /// </summary>
    protected Dictionary<string, Expression> GlobalVariables { get; }
    
    /// <summary>
    /// Represents system environment variables during the lifetime of the pipeline execution.
    /// </summary>
    protected Dictionary<string, Expression> GlobalEnv { get; }
    
    /// <summary>
    /// Represents functions of the bldit file context.
    /// </summary>
    protected Dictionary<string, Func<Expression?[], Expression?>> Functions { get; }
    
    /// <summary>
    /// Represents the set of stages in the pipeline.
    /// No duplicate stage names are allowed.
    /// </summary>
    protected HashSet<Stage> Stages { get; }

    public PipelineVisitor(
        List<string> semanticErrors, 
        Dictionary<string, Expression> globalVariables, 
        Dictionary<string, Func<Expression?[], Expression?>> functions)
    {
        SemanticErrors = semanticErrors;
        GlobalVariables = globalVariables;
        Functions = functions;
        GlobalEnv = new Dictionary<string, Expression>();
        Stages = new HashSet<Stage>();
    }
    
    public override Pipeline VisitPipeline(BldItParser.PipelineContext context)
    {
        var pipeline = new Pipeline();
        
        var globalEnvVisitor = new GlobalEnvStatementVisitor(
            SemanticErrors, 
            GlobalVariables, 
            GlobalEnv, 
            Functions);
        
        var parameterStatementVisitor = new ParameterStatementVisitor(
            SemanticErrors, 
            GlobalVariables, 
            GlobalEnv, 
            Functions);
        
        for (var i = 0; i < context.ChildCount; i++)
        {
            switch (i)
            {
                //GlobalEnvStatement is index 0
                case 0:
                    pipeline.SetGlobalEnv(globalEnvVisitor
                        .VisitGlobalEnvStatement(context.globalEnvStatement()));
                    break;
                case 1:
                    pipeline.SetParameterStatement(parameterStatementVisitor
                        .VisitParameterStatement(context.parameterStatement()));
                    break;
            }
        }
        
        return pipeline;
    }
}