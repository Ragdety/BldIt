@echo off

setlocal enabledelayedexpansion

echo WARN: This script will update the shared library for the entire Identity Service 
echo       This includes the Contracts, Core and Service projects
echo INFO: Press Ctr + C to exit and install only in specific projects
pause

:: Install latest version of the BldIt API shared library

set apiPrjPath=BldIt.Identity.Api
set contractsPrjPath=BldIt.Identity.Contracts
set corePrjPath=BldIt.Identity.Core
set sharedApiLibName=BldIt.Api.Shared

pushd %apiPrjPath%
echo.
echo INFO: Adding %sharedApiLibName% to %apiPrjPath%.csproj
dotnet add package %sharedApiLibName%
if [!errorlevel!] neq [0] goto :error
popd

pushd %contractsPrjPath%
echo INFO: Adding %sharedApiLibName% to %contractsPrjPath%.csproj
dotnet add package %sharedApiLibName%
if [!errorlevel!] neq [0] goto :error
popd

pushd %corePrjPath%
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