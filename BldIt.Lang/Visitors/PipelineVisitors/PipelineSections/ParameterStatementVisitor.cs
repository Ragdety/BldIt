using BldIt.Lang.Exceptions;
using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItExpressions;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineParameterTypes;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections;

namespace BldIt.Lang.Visitors.PipelineVisitors.PipelineSections;

public class ParameterStatementVisitor : BldItParserBaseVisitor<ParameterStatement>
{
    protected List<string> SemanticErrors { get; }
    protected Dictionary<string, Expression> GlobalVariables { get; }
    protected Dictionary<string, Func<Expression?[], Expression?>> Functions { get; }
    protected HashSet<Parameter> Parameters { get; }

    public ParameterStatementVisitor(
        List<string> semanticErrors, 
        Dictionary<string, Expression> globalVariables,
        Dictionary<string, Func<Expression?[], Expression?>> functions, 
        HashSet<Parameter> parameters)
    {
        SemanticErrors = semanticErrors;
        GlobalVariables = globalVariables;
        Functions = functions;
        Parameters = parameters;
    }
    
    public override ParameterStatement VisitParameterStatement(BldItParser.ParameterStatementContext context)
    {
        var parameterStatement = context.GetText();
        if (context.parameterBlock() is {} parameterBlock)
            return VisitParameterBlock(parameterBlock);
        throw new CompilingException($"Invalid parameter statement: {parameterStatement}");
    }

    public override ParameterStatement VisitParameterBlock(BldItParser.ParameterBlockContext context)
    {
        return VisitParamAssignments(context.paramAssignments());
    }

    public override ParameterStatement VisitParamAssignments(BldItParser.ParamAssignmentsContext context)
    {
        var parameters = context.paramAssignment();
        var parameterAssignmentVisitor = new ParameterAssignmentVisitor(SemanticErrors, GlobalVariables, Functions);
        var parameterStatement = new ParameterStatement();

        foreach (var param in parameters)
        {
            var parameter = parameterAssignmentVisitor.VisitParamAssignment(param);
            if (parameterStatement.Parameters.Contains(parameter))
                throw new CompilingException($"Parameter {parameter.ParameterName} already exists");
            parameterStatement.AddParameter(parameter);
            Parameters.Add(parameter);
        }
        
        return parameterStatement;
    }
}