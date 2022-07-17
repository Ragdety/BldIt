using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItExpressions;
using BldIt.Lang.ValueObjects.BldItPipeline;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineExpressions;

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
    protected Dictionary<string, PipelineExpression> GlobalEnv { get; }
    
    /// <summary>
    /// Represents the set of stages in the pipeline.
    /// No duplicate stage names are allowed.
    /// </summary>
    protected HashSet<Stage> Stages { get; }

    public PipelineVisitor(
        List<string> semanticErrors, 
        Dictionary<string, Expression> globalVariables)
    {
        SemanticErrors = semanticErrors;
        GlobalVariables = globalVariables;
        GlobalEnv = new Dictionary<string, PipelineExpression>();
        Stages = new HashSet<Stage>();
    }
    
    public override Pipeline VisitPipeline(BldItParser.PipelineContext context)
    {
        //Method stub. TODO: Implement it
        var txt = context.pipelineSections().pipelineSectionOrder().globalEnvStatement().GetText();
        return new Pipeline();
    }
}