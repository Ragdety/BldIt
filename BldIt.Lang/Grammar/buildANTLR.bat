@echo off

if [%1] == [parser] (
    antlr4 -Dlanguage=CSharp -o csharp %cd%\BldItParser.g4 -no-listener -visitor
) else if [%1] == [lexer] (
    antlr4 -Dlanguage=CSharp -o csharp %cd%\BldItLexer.g4 -no-listener -visitor
) else (
    echo "ERROR: Unknown argument. Choose between 'parser' and 'lexer'."
    exit /b 1
)

echo INFO: Exiting with error level: %ERRORLEVEL%
exit /b %ERRORLEVEL%