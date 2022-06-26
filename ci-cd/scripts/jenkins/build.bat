@echo off

setlocal enabledelayedexpansion
set PATH=C:\Program Files\dotnet;%USERPROFILE%\.dotnet\tools;!PATH!

pushd ..\..\..\
dotnet build

echo INFO: Exit with code: !errorlevel!
exit /b !errorlevel!