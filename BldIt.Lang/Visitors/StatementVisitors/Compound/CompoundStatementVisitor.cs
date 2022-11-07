using Antlr4.Runtime.Tree;
using BldIt.Lang.Exceptions;
using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItExpressions;
using BldIt.Lang.ValueObjects.BldItExpressions.ConstantTypes;
using BldIt.Lang.ValueObjects.BldItExpressions.ExpressionTypes;
using BldIt.Lang.ValueObjects.BldItStatements;
using BldIt.Lang.ValueObjects.BldItStatements.Compound;
using BldIt.Lang.ValueObjects.BldItStatements.Simple;
using BldIt.Lang.Visitors.ExpressionVisitors;

namespace BldIt.Lang.Visitors.StatementVisitors.Compound;

public class CompoundStatementVisitor : StatementVisitor
{
    public Dictionary<string, Expression> LocalVariables { get; }
    //public Dictionary<string, Expression> OriginalGlobalVariables { get; }

    public CompoundStatementVisitor(
        List<string> semanticErrors,
        Dictionary<string, Expression> globalVariables,
        Dictionary<string, Func<Expression?[], Expression?>> functions
    ) : base(semanticErrors, globalVariables, functions)
    {
        LocalVariables = new Dictionary<string, Expression>();
    }
    
    public override Statement VisitCompoundStatement(BldItParser.CompoundStatementContext context)
    {
        if(context.ifStatement() is {} ifStatement)
            return VisitIfStatement(ifStatement);
        if (context.whileStatement() is {} whileStatement)
            return VisitWhileStatement(whileStatement);
        if (context.functionDefinition() is { } functionDefinition)
            return VisitFunctionDefinition(functionDefinition);
        SemanticErrors.Add($"Unknown compound statement type: {context.GetText()}");
        throw new CompilingException(SemanticErrors[^1]);
    }
    
    public override Statement VisitIfStatement(BldItParser.IfStatementContext context)
    {
        var txt = context.GetText();

        var expressionVisitor = new ExpressionVisitor(SemanticErrors, GlobalVariables, Functions);
        var expressionResult = expressionVisitor.Visit(context.singleIfBlock().expression());
        BoolValue boolValue;

        switch (expressionResult.ExpressionType)
        {
            case ExpressionType.Boolean:
                boolValue = (BoolValue) expressionResult;
                break;
            case ExpressionType.Identifier:
            {
                var identifier = (Identifier) expressionResult;
                boolValue = (BoolValue) GlobalVariables[identifier.Id];
                break;
            }
            default:
                throw new ArgumentOutOfRangeException();
        }

        if (boolValue.Value)
            return Visit(context.singleIfBlock().block());

        //After checking single if statement, if we have else blocks, we need to check them too
        if (context.elseIfBlock().Length != 0)
        {
            //Loop through each else if blocks
            foreach (var eib in context.elseIfBlock())
            {
                expressionResult = expressionVisitor.Visit(eib.expression());
                if (expressionResult.ExpressionType != ExpressionType.Boolean)
                    throw new InvalidDataTypeException("Condition must be a boolean");
                
                boolValue = (BoolValue) expressionResult;
                
                //If the condition is not true, skip to the next else if block (eib) - continue
                if (!boolValue.Value) continue;
                
                //If the condition is true, goto block and return (since we don't want to execute the else block)
                return Visit(eib.block());
            }
            
            //This point is reached if all else if blocks are false
            //Make sure to check the else block if no else if block was executed
            if (context.elseBlock() is { } elseBlock)
                return Visit(elseBlock.block());
        }
        else if (context.elseBlock() is {} elseBlock)
            return Visit(elseBlock.block());

        return new IfStatementResult(boolValue.Value);
    }

    public override Statement VisitWhileStatement(BldItParser.WhileStatementContext context)
    {
        Func<object?, bool> condition = context.WHILE().GetText() == "while"
                ? IsTrue
                : IsFalse;

        var expressionVisitor = new ExpressionVisitor(SemanticErrors, GlobalVariables, Functions);
        var expressionResult = expressionVisitor.Visit(context.expression());
        
        if (expressionResult.ExpressionType != ExpressionType.Boolean)
            throw new InvalidDataTypeException("Condition must be a boolean");
        
        var boolValue = (BoolValue) expressionResult;

        while (condition(boolValue.Value))
        {
            //Visit Block
            VisitBlock(context.block());
            
            //Then reevaluate the condition
            expressionResult = expressionVisitor.Visit(context.expression());
        
            if (expressionResult.ExpressionType != ExpressionType.Boolean)
                throw new InvalidDataTypeException("Condition must be a boolean");
        
            boolValue = (BoolValue) expressionResult;
        }
 
        //Always should end in false, otherwise infinite loop...
        //Undecidable Turing Machine...?
        return new WhileStatementResult(boolValue.Value);
    }
    
    public override Statement VisitFunctionDefinition(BldItParser.FunctionDefinitionContext context)
    {
        var functionName = context.IDENTIFIER().GetText();

        var functionParameters = context.parameters() != null ? 
            context.parameters().IDENTIFIER().ToArray() : 
            Array.Empty<ITerminalNode>();
        
        //
        // var globalVariablesBeforeFunc = 
        //     GlobalVariables.Select(x => x)
        //         .ToDictionary(x => x.Key, x => x.Value);
        
        Expression FunctionDelegate(Expression?[] arguments)
        {
            /*
             * 1. Loop through each argument and visit their value as expression
             * 2. Save it temporarily to Global variables dictionary
             *    with the parameter name as key and result as value
             * 3. Visit the function body
             * 4. Remove the temporary variables from the global variables dictionary
             * 5. Return the result expression of the function body (if any)
             */
            for (var i = 0; i < functionParameters.Length; i++)
            {
                //Add variables inside function to local variables
                LocalVariables.Add(functionParameters[i].GetText(), arguments[i] ?? new NullValue(null));
            }

            foreach (var localVariable in LocalVariables)
            {
                //Temporarily add local variables to global variables (simulating the stack)
                GlobalVariables.Add(localVariable.Key, localVariable.Value);
            }

            var returnStatement = VisitFunctionBlock(context.functionBlock());
            var result = (ReturnStatement) returnStatement;

            //After we evaluate the result, clean up local variables.
            //Must be after that since we still want to access those when evaluating return's expression
            
            //CLEAN UP:
            //Select keys that were previously in local variables
            var prev = GlobalVariables
                .Select(kv => kv.Key)
                .Where(key => !LocalVariables.ContainsKey(key));
            
            foreach (var key in prev)
            {
                GlobalVariables.Remove(key);
            }
            LocalVariables.Clear();
            return result.Expression;
        }

        Functions.Add(functionName, FunctionDelegate);
        return new FunctionDefinition(functionName, FunctionDelegate);
    }

    public override Statement VisitBlock(BldItParser.BlockContext context)
    {
        var t = context.GetText();
        var statements = context.statements().statement().ToArray();
        var statementVisitor = new StatementVisitor(SemanticErrors, GlobalVariables, Functions);

        //Loop through each statement
        foreach (var statementContext in statements)
        {
            //If the result is a return statement, return (exit out of the function)
            var res = statementVisitor.VisitStatement(statementContext);
            if (res is ReturnStatement)
                return res;
        }
        return new BlockResult();
    }

    public override Statement VisitFunctionBlock(BldItParser.FunctionBlockContext context)
    {
        var t = context.GetText();
        //Function blocks must have a return statement (either explicit or implicit) 
        //For return value, if it does not exist, return Void
        //Otherwise visit expression and return it
        var statements = context.statements().statement().ToArray();

        //Loop through each statement
        foreach (var statementContext in statements)
        {
            //If the result is a return statement, return (exit out of the function)
            var res = VisitStatement(statementContext);
            if (res is ReturnStatement)
                return res;
        }
        //If end of the loop, implicitly return Void
        return new ReturnStatement(new VoidValue());
    }

    private static bool IsTrue(object? value)
    {
        if(value is bool b)
            return b;
        
        throw new InvalidDataTypeException("Expected boolean type");
    }

    private static bool IsFalse(object? value) => !IsTrue(value);
}