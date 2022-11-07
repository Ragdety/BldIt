using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects;
using BldIt.Lang.ValueObjects.BldItExpressions;
using BldIt.Lang.Visitors.PipelineVisitors;
using BldIt.Lang.Visitors.StatementVisitors;

namespace BldIt.Lang.Visitors;

public class BldItFileVisitor : BldItParserBaseVisitor<BldItFile>
{
    public List<string> SemanticErrors { get; }
    public Dictionary<string, Expression> GlobalVariables { get; }
    public Dictionary<string, Func<Expression?[], Expression?>> Functions { get; }

    public BldItFileVisitor()
    {
        SemanticErrors = new List<string>();
        GlobalVariables = new Dictionary<string, Expression>();
        Functions = new Dictionary<string, Func<Expression?[], Expression?>>();
    }

    public override BldItFile VisitBldItFile(BldItParser.BldItFileContext context)
    {
        var bldItFile = new BldItFile();
        
        //TODO: Use dependency injection to handle creation of visitor objects
        //Helper object to transform each subtree into a Statement object
        var statementVisitorVisitor = new StatementVisitor(SemanticErrors, GlobalVariables, Functions);
        
        //Also pass GlobalVariables to the pipeline to use them in the pipeline statements
        var pipelineVisitor = new PipelineVisitor(SemanticErrors, GlobalVariables, Functions);

        /*
         * Loop through each child: bldItFile: 'statements pipeline EOF'
         * 1. statement*
         * 2. pipeline
         * 3. EOF
         */
        for (var i = 0; i < context.ChildCount; i++)
        {
            switch (i)
            {
                case 0:
                {
                    foreach (var statement in context.statement())
                    {
                        //First child is the statement* grammar rule, visit each one:
                        bldItFile.AddStatement(statementVisitorVisitor.VisitStatement(statement));
                    }
                    break;
                }
                case 1:
                    //Second child is the pipeline grammar rule
                    bldItFile.SetPipeline(pipelineVisitor.VisitPipeline(context.pipeline()));
                    break;
            }
            //Last child of the start symbol (bldItFile) is EOF
            //Do not visit this child and attempt to convert it to a Statement object
        }

        return bldItFile;
    }
}