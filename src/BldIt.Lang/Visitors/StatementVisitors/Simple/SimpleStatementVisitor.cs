using BldIt.Lang.Exceptions;
using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItExpressions;
using BldIt.Lang.ValueObjects.BldItExpressions.ConstantTypes;
using BldIt.Lang.ValueObjects.BldItStatements;
using BldIt.Lang.ValueObjects.BldItStatements.Simple;
using BldIt.Lang.Visitors.ExpressionVisitors;

namespace BldIt.Lang.Visitors.StatementVisitors.Simple;

public class SimpleStatementVisitor : StatementVisitor
{
    public SimpleStatementVisitor(
        List<string> semanticErrors,
        Dictionary<string, Expression> globalVariables,
        Dictionary<string, Func<Expression?[], Expression?>> functions) 
        : base(semanticErrors, globalVariables, functions)
    {
        functions["print"] = Write;
        //functions["echo"]  = Echo;
    }

    public override Statement VisitSimpleStatement(BldItParser.SimpleStatementContext context)
    {
        var text = context.GetText();
        if(context.assignment() is {} assignment)
            return VisitAssignment(assignment);
        if (context.functionCall() is {} functionCall)
            return VisitFunctionCall(functionCall);
        if (context.returnStatement() is { } returnStatement)
            return VisitReturnStatement(returnStatement);
        SemanticErrors.Add($"Unknown statement type: {text}");
        throw new CompilingException(SemanticErrors[^1]);
    }

    public override Statement VisitAssignment(BldItParser.AssignmentContext context)
    {
        var token = context.IDENTIFIER().Symbol;
        var line = token.Line;
        var column = token.Column + 1;
        
        var expressionVisitor = new ExpressionVisitor(SemanticErrors, GlobalVariables, Functions);
        var varName = context.IDENTIFIER().GetText();
        var value = expressionVisitor.Visit(context.expression());
        
        if(GlobalVariables.ContainsKey(varName))
        {
            SemanticErrors.Add($"Variable {varName} already defined on line {line} column {column}");
        }
        else
        {
            GlobalVariables.Add(varName, value);
        }

        GlobalVariables[varName] = value;
        
        return new Assignment(varName, value);
    }

    public override Statement VisitFunctionCall(BldItParser.FunctionCallContext context)
    {
        var token = context.IDENTIFIER().Symbol;
        var line = token.Line;
        var column = token.Column + 1;
        var expressionVisitor = new ExpressionVisitor(SemanticErrors, GlobalVariables, Functions);
        
        var functionName = context.IDENTIFIER().GetText();
        
        //Visit each expression to evaluate as function arguments:
        var arguments = context.expression().Select(expression => expressionVisitor.Visit(expression)).ToArray();
        
        if(!Functions.ContainsKey(functionName))
            throw new UndefinedFunctionException(functionName);
        
        var function = Functions[functionName];
        if(function is not { } func)
        {
            SemanticErrors.Add($"{functionName} is not a function on line {line}:{column}");
            throw new CompilingException(SemanticErrors[^1]);
        }

        //Executing the function here:
        var result = func(arguments);
        return new FunctionCallStatement(func.Method.Name, arguments, result);
    }

    public override Statement VisitReturnStatement(BldItParser.ReturnStatementContext context)
    {
        //If expression is not there, it means function returns void
        if (context.expression() == null)
            return new ReturnStatement(new VoidValue());
        
        var expressionVisitor = new ExpressionVisitor(SemanticErrors, GlobalVariables, Functions);
        var expression = expressionVisitor.Visit(context.expression());
        return new ReturnStatement(expression);
    }

    private static Expression Write(Expression?[] arguments)
    {
        //Function Write returns a string with the output write
        var output = "";
        
        foreach (var argument in arguments)
        {
            Console.WriteLine(argument);
            output += argument;
        }

        return new StringValue(output);
    }

    //private static Expression Echo(Expression?[] arguments) => Write(arguments);
}