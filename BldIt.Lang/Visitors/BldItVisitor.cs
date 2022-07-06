using BldIt.Lang.Grammar;

namespace BldIt.Lang.Visitors;

public class BldItVisitor : BldItBaseVisitor<object?>
{
    private Dictionary<string, object?> Variables { get; } = new();

    public override object? VisitAssignment(BldItParser.AssignmentContext context)
    {
        var varName = context.IDENTIFIER().GetText();
        var value = Visit(context.expression());

        Variables[varName] = value;
        
        return null;
    }

    public override object? VisitConstant(BldItParser.ConstantContext context)
    {
        if (context.INTEGER() is { } intValue)
            return int.Parse(intValue.GetText());
        
        if (context.FLOAT() is { } floatValue)
            return float.Parse(floatValue.GetText());
        
        if (context.STRING() is { } stringValue)
            return stringValue.GetText()[1..^1]; //Skip 1st and last char
        
        if(context.BOOL() is { } boolValue)
            return boolValue.GetText() == "true";

        if (context.NULL() is { })
            return null;

        throw new NotSupportedException("Data type not supported");
    }
}