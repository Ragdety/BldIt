using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using BldIt.Shared.Processes;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace BldIt.Shared.Tests.Processes;

public sealed class ProcessServiceTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly ProcessService _processService;

    public ProcessServiceTests(
        ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _processService = new ProcessService();
    }

    [Fact]
    public async Task Should_Return_ExitCode_0()
    {
        //Given
        var scriptFile = CreateDummyFile(FileType.Batch, "exit 0");
        _processService.Program = scriptFile;
        
        //When
        var exitCode = await _processService.RunAsync();
        
        //Then
        exitCode.Should().Be(0);
    }
    
    [Fact]
    public async Task Should_Return_ExitCode_1()
    {
        //Given
        var scriptFile = CreateDummyFile(FileType.Batch, "exit 1");
        _processService.Program = scriptFile;
        
        //When
        var exitCode = await _processService.RunAsync();
        
        //Then
        exitCode.Should().Be(1);
    }
    
    [Fact]
    public async Task Should_Throw_When_Raw_HelloWorld_Given()
    {
        //Given
        const string script = "echo Hello World";
        _processService.Program = script;

        //When
        var result = await Record.ExceptionAsync(async () => await _processService.RunAsync());
    
        //Then
        result.Should().NotBeNull();
    }
    
    [Fact]
    public async Task Should_Throw_When_Program_IsEmpty()
    {
        //Given
        _processService.Program = string.Empty;

        //When
        var result = await Record.ExceptionAsync(async () => await _processService.RunAsync());
    
        //Then
        result.Should().NotBeNull();
        result.Should().BeOfType<ArgumentNullException>();
    }

    [Fact]
    public async Task Should_PrintOutputToLogs()
    {
        //Given
        const string script = "@echo off\n" +
                              "echo Hello World\n" +
                              "dir C:/nonexistent && (\n" +
                              "   echo Directory exists\n" +
                              ") || (\n" +
                              "   echo Directory does not exist\n" +
                              "   exit 10\n" +
                              ")\n";
        
        var scriptFile = CreateDummyFile(FileType.Batch, script);
        var outputLogFile = CreateDummyFile(FileType.Log);
    
        _processService.Program = scriptFile;
        _processService.OutputLogPath = outputLogFile;
        
        //When
        var exitCode = await _processService.RunAsync();
        var output = await File.ReadAllTextAsync(outputLogFile);

        //Then
        output.Should().ContainAny("Hello World", "Directory does not exist");
        output.Should().NotContainAny("Directory exists");
        exitCode.Should().Be(10);
    }

    //Output callback tests
    [Fact]
    public async Task Should_ExecuteFileHelloWorld()
    {
        //Given
        const string script = "@echo off\necho Hello World";
        var scriptFile = CreateDummyFile(FileType.Batch, script);
        var stringBuilder = new StringBuilder();
    
        _processService.Program = scriptFile;
        var outputCallback = new Func<string, Task>(async output =>
        {
            stringBuilder.Append(output);
            await Task.CompletedTask;
        });

        //When
        await _processService.RunAsync(outputCallback);
        
        //Then
        stringBuilder.ToString().Should().Be("Hello World");
    }
    
    //Argument tests here
    [Fact]
    public async Task Should_PrintArgumentsPassed()
    {
        //Given
        const string script = "@echo off\n" +
                              "echo %1\n" +
                              "echo %2\n" +
                              "echo %3";
        var scriptFile = CreateDummyFile(FileType.Batch, script);
        var stringBuilder = new StringBuilder();
    
        _processService.Program = scriptFile;
        _processService.Arguments = new[] {"arg1", "arg2", "arg3"};
        
        var outputCallback = new Func<string, Task>(async output =>
        {
            stringBuilder.AppendLine(output);
            await Task.CompletedTask;
        });

        //When
        await _processService.RunAsync(outputCallback);
        
        //Then
        _testOutputHelper.WriteLine(stringBuilder.ToString());
        stringBuilder.ToString().Should().ContainAll("arg1", "arg2", "arg3");
    }

    //Working directory tests here
    [Fact]
    public async Task Should_PrintCurrentWorkingDirectory()
    {
        //Given
        const string script = "@echo off\n" +
                              "echo %cd%\n";
        var scriptFile = CreateDummyFile(FileType.Batch, script);
        var directory = Directory.GetParent(scriptFile)?.FullName;
        var stringBuilder = new StringBuilder();

        _processService.Program = scriptFile;
        _processService.WorkingDirectory = directory!;
        
        var outputCallback = new Func<string, Task>(async output =>
        {
            stringBuilder.AppendLine(output);
            await Task.CompletedTask;
        });

        //When
        await _processService.RunAsync(outputCallback);
        
        //Then
        _testOutputHelper.WriteLine(stringBuilder.ToString());
        stringBuilder.ToString().Should().ContainAny(directory);
    }
    
    //Testing outputHandler and environment variables together
    [Fact]
    public async Task Should_PrintEnvironmentVars_WorkingWith_OutputHandler()
    {
        //Given
        const string script = "@echo off\n" +
                              "echo %var1%\n" +
                              "echo %var2%\n" +
                              "echo %var3%\n";
        var scriptFile = CreateDummyFile(FileType.Batch, script);
        var stringBuilder = new StringBuilder();
        var environmentVars = new Dictionary<string, string?>
        {
            {"var1", "value1"},
            {"var2", "value2"},
            {"var3", "value3"}
        };

        _processService.Program = scriptFile;
        _processService.EnvironmentVariables = environmentVars;
        
        var outputHandler = new Action<string>(output =>
        {
            stringBuilder.AppendLine(output);
        });

        //When
        var exitCode = await _processService.RunAsync(outputHandler);
        
        //Then
        stringBuilder.ToString().Should().NotBeEmpty();
        stringBuilder.ToString().Should().ContainAll("value1", "value2", "value3");
        exitCode.Should().Be(0);
    }

    private static string CreateDummyFile(FileType type, string? content = null)
    {
        var fileName = Path.GetTempFileName();
        var extension = GetFileTypeExtension(type);
        var newFileName = Path.ChangeExtension(fileName, extension);

        if (content is null) return newFileName;
        
        File.Move(fileName, newFileName);
        File.WriteAllText(newFileName, content);

        return newFileName;
    }

    private static string GetFileTypeExtension(FileType type)
    {
        return type switch
        {
            FileType.Batch => ".bat",
            FileType.PowerShell => ".ps1",
            FileType.Bash => ".sh",
            FileType.Python => ".py",
            FileType.Log => ".log",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }

    private enum FileType
    {
        Batch,
        PowerShell,
        Bash,
        Python,
        Log
    }
}