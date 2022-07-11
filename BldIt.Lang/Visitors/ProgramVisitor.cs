using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects;
using BldIt.Lang.Visitors.PipelineVisitors;
using BldIt.Lang.Visitors.StatementVisitors;

namespace BldIt.Lang.Visitors;

public class ProgramVisitor : BldItParserBaseVisitor<BldItFile>
{
    public List<string> SemanticErrors { get; }

    public ProgramVisitor()
    {
        SemanticErrors = new List<string>();
    }

    public override BldItFile VisitBldItFile(BldItParser.BldItFileContext context)
    {
        var bldItFile = new BldItFile();
        
        //Helper object to transform each subtree into a Statement object
        var statementVisitorVisitor = new StatementVisitor(SemanticErrors);
        var pipelineVisitor = new PipelineVisitor(SemanticErrors);

        for (var i = 0; i < context.ChildCount; i++)
        {
            var child = context.GetChild(i).GetText();
            if (i == context.ChildCount - 1)
            {
                //Last child of the start symbol (bldItFile) is EOF
                //Do not visit this child and attempt to convert it to a Statement object
            }
            else if (i == 1)
            {
                //Child index 1 (second child) is the pipeline, so we set it here
                bldItFile.SetPipeline(pipelineVisitor.Visit(context.GetChild(i)));
            }
            else
            {
                bldItFile.AddStatement(statementVisitorVisitor.Visit(context.GetChild(i)));
            }
        }

        return bldItFile;
    }
}