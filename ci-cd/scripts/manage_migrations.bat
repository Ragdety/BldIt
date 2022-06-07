@echo off
setlocal enabledelayedexpansion

set mainProject=%cd%\..\..\BldIt.Api\BldIt.Api.csproj
set dataProject=%cd%\..\..\BldIt.Data\BldIt.Data.csproj

rem Manage database migration commands:
if [%1] == [add] (
    if [%2] == [] (
        echo ERROR: No migration name specified
        set errorlevel=1
    ) else (
        dotnet ef migrations add %2 -s %mainProject% -p %dataProject%
    )
) else if [%1] == [remove] (
    dotnet ef migrations remove -s %mainProject% -p %dataProject%
) else if [%1] == [update] (
    dotnet ef database update -s %mainProject% -p %dataProject%
) else (
    echo ERROR: No option defined
    echo Options are: add 'migration_name', remove, update
    set errorlevel=1
)

echo Exit with code: !errorlevel!
exit /b !errorlevel!