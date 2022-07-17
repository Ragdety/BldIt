using BldIt.Lang.ValueObjects.BldItExpressions;

namespace BldIt.Lang.ValueObjects.BldItStatements.Compound;

public class FunctionDefinition : CompoundStatement
{
    public string Name { get; }
    //public Expression?[] Parameters { get; }
    public Func<Expression?[], Expression?> FunctionCall { get; }

    public FunctionDefinition(
        string name, 
        //Expression?[] parameters,
        Func<Expression?[], Expression?> functionCall)
    {
        Name = name;
        //Parameters = parameters;
        FunctionCall = functionCall;
    }
}