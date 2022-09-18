using Antlr4.Runtime;
using BldIt.Api.Services.Processes;
using BldIt.Lang.Exceptions;
using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItExpressions;
using BldIt.Lang.ValueObjects.BldItExpressions.ConstantTypes;
using BldIt.Lang.ValueObjects.BldItExpressions.ExpressionHelpers;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineExpressions;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineParameterTypes;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps.SimpleStageSteps;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps.SimpleStageSteps.Enums;
using BldIt.Lang.Visitors.PipelineVisitors.PipelineExpressions;

namespace BldIt.Lang.Visitors.PipelineVisitors.PipelineSections.Stages.Steps;

public class SimpleStepStatementVisitor : StepStatementVisitor
{
    public SimpleStepStatementVisitor(
        List<string> semanticErrors, 
        Dictionary<string, Expression> globalVariables, 
        Dictionary<string, Func<Expression?[], Expression?>> functions, 
        Dictionary<string, Expression> globalEnv, 
        HashSet<Parameter> parameters) 
        : base(semanticErrors, globalVariables, functions, globalEnv, parameters)
    { }

    public override SimpleStageStep VisitSimpleStepStatement(BldItParser.SimpleStepStatementContext context)
    {
        var stepStatementText = context.GetText();
        if (context.pipelineSimpleStepCall() is { } pipelineSimpleStepCall)
            return VisitPipelineSimpleStepCall(pipelineSimpleStepCall);
        throw new CompilingException($"Invalid step statement: {stepStatementText}");
    }

    public override SimpleStageStep VisitPipelineSimpleStepCall(BldItParser.PipelineSimpleStepCallContext context)
    {
        var stepIdentifier = context.IDENTIFIER().GetText();

        return stepIdentifier switch
        {
            "echo" => VisitEchoStep(context),
            "run" => VisitRunStep(context),
            "error" => VisitErrorStep(context),
            _ => throw new CompilingException($"Step {stepIdentifier} is not supported")
        };
    }
    
    private EchoStep VisitEchoStep(BldItParser.PipelineSimpleStepCallContext context)
    {
        var stepExpressions = context.pipelineExpression();
        
        if (stepExpressions.Length is < 1 or > 1)
            throw new CompilingException("Step \'echo\' requires 1 argument");
        
        var pipelineExpressionVisitor = new PipelineExpressionVisitor(SemanticErrors, GlobalVariables, Functions, GlobalEnv, Parameters);
        var expressionResult = pipelineExpressionVisitor.VisitPipelineExpression(context.pipelineExpression()[0]);
        var exprTypeValueObject = ExpressionTypeHelper.GetValueFromType(expressionResult);

        Console.WriteLine(exprTypeValueObject.ToString());
        
        return new EchoStep(exprTypeValueObject.ToString());
    }
    
    private ErrorStep VisitErrorStep(BldItParser.PipelineSimpleStepCallContext context)
    {
        var stepExpressions = context.pipelineExpression();
        
        if (stepExpressions.Length is < 1 or > 1)
            throw new CompilingException("Step \'error\' requires 1 argument");
        
        var pipelineExpressionVisitor = new PipelineExpressionVisitor(SemanticErrors, GlobalVariables, Functions, GlobalEnv, Parameters);
        var expressionResult = pipelineExpressionVisitor.VisitPipelineExpression(context.pipelineExpression()[0]);
        var exprTypeValueObject = ExpressionTypeHelper.GetValueFromType(expressionResult);

        Console.Error.WriteLine(exprTypeValueObject.ToString());
        
        //If the parent is a handleErrorsStep
        if (IsHandleErrorParent(context)) return new ErrorStep(exprTypeValueObject.ToString());
        
        //Otherwise, exit the program
        Console.Out.WriteLine("Error signal. Skipping all other actions...");
        Environment.Exit(-255);

        return new ErrorStep(exprTypeValueObject.ToString());
    }
    
    private RunStep VisitRunStep(BldItParser.PipelineSimpleStepCallContext context)
    {
        /*
         * 1) Check arguments length
         * 2) Evaluate arguments (as stringValues)
         * 3) Check if expression evaluation is of type StringValue
         * 4) Get the actual Value of the StringValue
         * 5) Run new Process here using the argument values
         * 6) Return the result of the process execution into RunStep class
         */
        
        var stepExpressions = context.pipelineExpression();

        switch (stepExpressions.Length)
        {
            case < 1:
                throw new CompilingException("Step \'run\' requires at least 1 argument: run(command/path)");
            case > 3:
                throw new CompilingException("Step \'run\' requires at most 3 arguments (command, arguments, working directory)");
        }

        var pipelineExpressionVisitor = new PipelineExpressionVisitor(SemanticErrors, GlobalVariables, Functions, GlobalEnv, Parameters);
        var command = pipelineExpressionVisitor.VisitPipelineExpression(stepExpressions[0]);
        
        var arguments =
            stepExpressions.Length > 1 ? 
                pipelineExpressionVisitor.VisitPipelineExpression(stepExpressions[1]) 
                : new StringValue("");
        
        //If run step is called without working directory, use current directory
        //Working directory is the 3rd argument like this: run("command", "arguments", "working directory")
        var workingDirectory =
            stepExpressions.Length > 2 ? 
                pipelineExpressionVisitor.VisitPipelineExpression(stepExpressions[2]) 
                : new StringValue("");
        
        CheckRunStepExpressionTypes(command, arguments, workingDirectory);

        var commandValue = ExpressionTypeHelper.GetValueFromType(command);
        var argumentsValue = ExpressionTypeHelper.GetValueFromType(arguments);
        var workingDirectoryValue = ExpressionTypeHelper.GetValueFromType(workingDirectory);

        var runStep = new RunStep(
            commandValue.ToString() 
            ?? throw new CompilingException("Command value is null"),
            argumentsValue.ToString(), 
            workingDirectoryValue.ToString());
        
        //5) Run process here
        var launcherService = new LauncherService
        {
            ProgramFileName = runStep.Command,
        };
        
        if (runStep.Arguments is not null)
            launcherService.Arguments = runStep.Arguments;
        if(runStep.WorkingDirectory is not null)
            launcherService.WorkingDirectory = runStep.WorkingDirectory;

        //Sends process output to frontend
        async void OutputHandler(string output)
        {
            //await _hub.Clients.All.SendAsync("OutputReceived", output, cancellationToken);
            await Console.Out.WriteLineAsync(output);
        }
        
        var exitCode = launcherService.Run(OutputHandler);
        if (exitCode != 0)
        {
            Console.Out.WriteLine("ERROR: Script failed with exit code " + exitCode);
            
            //If the parent is a handleErrorsStep
            if(IsHandleErrorParent(context))
            {
                //Then do not terminate the pipeline, step is success b/c of the handleErrorsStep
                runStep.Status = RunStepStatus.Success;
                return runStep;
            }
            
            //If not, then terminate the pipeline
            Console.Out.WriteLine("Skipping all other actions...");
            Environment.Exit(exitCode);
        }
        
        runStep.Status = RunStepStatus.Success;
        return runStep;
    }

    private static void CheckRunStepExpressionTypes(Expression command, Expression arguments, Expression workingDir)
    {
        if (command is not StringValue)
            throw new InvalidDataTypeException("Step \'run\' requires a string as the first argument (command)");
        if (arguments is not StringValue)
            throw new InvalidDataTypeException(
                "Step \'run\' requires a string of command arguments as the second argument\n" + 
                "Ex: run(\"command\", \"arg1 arg2 arg3\")");
        if (workingDir is not StringValue)
            throw new InvalidDataTypeException("Step \'run\' requires a string as the third argument (working directory)");
    }
    
    private static bool IsHandleErrorParent(RuleContext context)
    {
        if (context.parent is BldItParser.CompoundStepStatementContext compoundStep)
        {
            return compoundStep.handleErrorsStep() is { };
        }

        return false;
    }
}