@echo off

setlocal enabledelayedexpansion

:: Build the Identity project

set prjName=BldIt.Identity
set apiPrj=%prjName%.Api\%prjName%.Api.csproj
set contractsPrj=%prjName%.Contracts\%prjName%.Contracts.csproj
set corePrj=%prjName%.Core\%prjName%.Core.csproj

echo INFO: Building %apiPrj%
dotnet build %apiPrj%
if [!errorlevel!] neq [0] goto :error

echo INFO: Building %contractsPrj%
dotnet build %contractsPrj%
if [!errorlevel!] neq [0] goto :error

echo INFO: Building %corePrj%
dotnet build %corePrj%
if [!errorlevel!] neq [0] goto :error


if [!errorlevel!] equ [0] goto :success

:error
echo ERROR: Build failed with exit code !errorlevel!
exit /b !errorlevel!

:success
echo INFO: Build succeeded!
exit /b 0