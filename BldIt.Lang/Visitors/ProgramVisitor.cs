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

        /*
         * Loop through each child: bldItFile: 'statements pipeline EOF'
         * 1. statement*
         * 2. pipeline
         * 3. EOF
         */
        for (var i = 0; i < context.ChildCount; i++)
        {
            var child = context.GetChild(i).GetText();
            if (i == 0)
            {
                foreach (var statement in context.statement())
                {
                    //First child is the statement* grammar rule, visit each one:
                    bldItFile.AddStatement(statementVisitorVisitor.VisitStatement(statement));
                }
            }
            else if (i == 1)
            {
                //Second child is the pipeline grammar rule
                bldItFile.SetPipeline(pipelineVisitor.VisitPipeline(context.pipeline()));
            }
            //Last child of the start symbol (bldItFile) is EOF
            //Do not visit this child and attempt to convert it to a Statement object
        }

        return bldItFile;
    }
}