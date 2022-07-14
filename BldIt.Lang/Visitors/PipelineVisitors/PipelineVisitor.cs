using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItExpressions;
using BldIt.Lang.ValueObjects.BldItPipeline;

namespace BldIt.Lang.Visitors.PipelineVisitors;

public class PipelineVisitor : BldItParserBaseVisitor<Pipeline>
{
    protected List<string> SemanticErrors { get; }
    protected Dictionary<string, Expression> GlobalVariables { get; }

    public PipelineVisitor(
        List<string> semanticErrors, 
        Dictionary<string, Expression> globalVariables)
    {
        SemanticErrors = semanticErrors;
        GlobalVariables = globalVariables;
    }
    
    public override Pipeline VisitPipeline(BldItParser.PipelineContext context)
    {
        //Method stub. TODO: Implement it
        var txt = context.pipelineSections().pipelineSectionOrder().globalEnvStatement().GetText();
        return new Pipeline();
    }
}