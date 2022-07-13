using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItPipeline;

namespace BldIt.Lang.Visitors.PipelineVisitors;

public class PipelineVisitor : BldItParserBaseVisitor<Pipeline>
{
    protected List<string> SemanticErrors { get; }

    public PipelineVisitor(List<string> semanticErrors)
    {
        SemanticErrors = semanticErrors;
    }
    
    public override Pipeline VisitPipeline(BldItParser.PipelineContext context)
    {
        //Method stub. TODO: Implement it
        var txt = context.pipelineSections().pipelineSectionOrder().globalEnvStatement().GetText();
        return new Pipeline();
    }
}