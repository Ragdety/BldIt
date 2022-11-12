@echo off

setlocal enabledelayedexpansion

:: Build the Identity project

set contractsPrj=BldIt.Identity.Contracts\BldIt.Identity.Contracts.csproj
set corePrj=BldIt.Identity.Core\BldIt.Identity.Core.csproj
set servicePrj=BldIt.Identity.Service\BldIt.Identity.Service.csproj


echo INFO: Building %contractsPrj%
dotnet build %contractsPrj%
if [!errorlevel!] neq [0] goto :error

echo INFO: Building %corePrj%
dotnet build %corePrj%
if [!errorlevel!] neq [0] goto :error

echo INFO: Building %servicePrj%
dotnet build %servicePrj%
if [!errorlevel!] neq [0] goto :error

if [!errorlevel!] equ [0] goto :success

:error
echo ERROR: Build failed with exit code !errorlevel!
exit /b !errorlevel!

:success
echo INFO: Build succeeded!
exit /b 0