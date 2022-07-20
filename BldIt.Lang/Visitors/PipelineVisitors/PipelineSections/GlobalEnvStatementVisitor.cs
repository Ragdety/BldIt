using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItExpressions;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections;

namespace BldIt.Lang.Visitors.PipelineVisitors.PipelineSections;

public class GlobalEnvStatementVisitor : BldItParserBaseVisitor<GlobalEnvStatement>
{
    public GlobalEnvStatementVisitor(
        List<string> semanticErrors, 
        Dictionary<string, Expression> globalVariables, 
        Dictionary<string, Expression> globalEnv, 
        Dictionary<string, Func<Expression?[], Expression?>> functions)
    {
        
    }
}