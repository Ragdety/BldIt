@echo off

setlocal enabledelayedexpansion

set service=%1

if [!service!] equ [] (
    echo ERROR: Service name is required
    exit /b 1
)

if [!service!] equ [builds] (
    set blditService=BldIt.Builds
) else if [!service!] equ [identity] (
    set blditService=BldIt.Identity
) else if [!service!] equ [jobs] (
    set blditService=BldIt.Jobs
) else if [!service!] equ [projects] (
    set blditService=BldIt.Projects
) else (
    echo ERROR: Invalid service name %service%
    echo        Options are: builds, identity, projects
    exit /b 1
)

echo INFO: all option was selected
echo WARN: This script will update the shared library for all %service% projects
echo INFO: Press Ctr + C to exit and install only in specific projects (builds, identity, projects, etc)
pause

:: Install latest version of the BldIt API shared library

set apiPrjPath=!blditService!.Api
set contractsPrjPath=!blditService!.Contracts
set corePrjPath=!blditService!.Core
set sharedApiLibName=BldIt.Api.Shared

pushd %service%\%apiPrjPath%
echo.
echo INFO: Adding %sharedApiLibName% to %apiPrjPath%.csproj
dotnet add package %sharedApiLibName%
if [!errorlevel!] neq [0] goto :error
popd

rem Don't want contracts to depend on other projects. 
rem This should be fully independent of others.
rem pushd %service%\%contractsPrjPath%
rem echo INFO: Adding %sharedApiLibName% to %contractsPrjPath%.csproj
rem dotnet add package %sharedApiLibName%
rem if [!errorlevel!] neq [0] goto :error
rem popd

pushd %service%\%corePrjPath%
echo.
echo INFO: Adding %sharedApiLibName% to %corePrjPath%.csproj
dotnet add package %sharedApiLibName%
if [!errorlevel!] neq [0] goto :error
popd

if [!errorlevel!] equ [0] goto :success

:error
echo ERROR: Adding packages failed with exit code !errorlevel!
exit /b !errorlevel!

:success
echo INFO: Added packages successfully!
exit /b 0