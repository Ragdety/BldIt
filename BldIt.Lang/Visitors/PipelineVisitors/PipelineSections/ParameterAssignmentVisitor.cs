using BldIt.Lang.Exceptions;
using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItExpressions;
using BldIt.Lang.ValueObjects.BldItExpressions.ConstantTypes;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineParameterTypes;

namespace BldIt.Lang.Visitors.PipelineVisitors.PipelineSections;

public class ParameterAssignmentVisitor : BldItParserBaseVisitor<Parameter>
{
    protected List<string> SemanticErrors { get; }
    protected Dictionary<string, Expression> GlobalVariables { get; }
    protected Dictionary<string, Func<Expression?[], Expression?>> Functions { get; }

    public ParameterAssignmentVisitor(
        List<string> semanticErrors, 
        Dictionary<string, Expression> globalVariables, 
        Dictionary<string, Func<Expression?[], Expression?>> functions)
    {
        SemanticErrors = semanticErrors;
        GlobalVariables = globalVariables;
        Functions = functions;
    }
    
    public override Parameter VisitParamAssignment(BldItParser.ParamAssignmentContext context)
    {
        /*
         * Child Indexes:
         *      0       1       2      3     4        (3/4 are optional)
         * IDENTIFIER COLON PARAM_TYPE = paramValue
         */
        
        //These positions/indexes might change in the future
        //Adding indexes instead of name to prevent NullPointer exception
        var paramName = context.GetChild(0).GetText();
        var paramTypeString = context.GetChild(2).GetText();

        var paramType = paramTypeString switch
        {
            "stringParam" => ParameterType.StringParam,
            "boolParam" => ParameterType.BoolParam,
            "choiceParam" => throw new NotImplementedException(),
            _ => throw new CompilingException("Unknown parameter type")
        };

        //Initialize with Void. If no default value is set, void will remain
        //Later we can check if the value of parameter is void,
        //Then set it to what the user specified in BltIt when pipeline is run
        object actualValue = new VoidValue();
        if (context.ChildCount <= 4) return new Parameter(paramType, paramName, actualValue);
        
        var paramValue = context.GetChild(4).GetText();
        actualValue = paramType switch
        {
            ParameterType.StringParam => new StringValue(paramValue),
            ParameterType.BoolParam => new BoolValue(paramValue == "true"),
            ParameterType.ChoiceParam => throw new NotImplementedException(),
            _ => throw new CompilingException("Unknown parameter type")
        };

        return new Parameter(paramType, paramName, actualValue);
    }
}