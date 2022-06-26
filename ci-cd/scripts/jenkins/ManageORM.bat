@echo off
setlocal enabledelayedexpansion

set BLDIT_JENKINS_SCRIPTS_PATH=C:\Users\ragde\OneDrive\Desktop\Programming\BldIt\ci-cd\scripts\jenkins
set Action=%1
set MigrationName=%2

echo %BLDIT_JENKINS_SCRIPTS_PATH%
pushd %BLDIT_JENKINS_SCRIPTS_PATH%

if [%Action%] == [Add] (
   echo INFO: Option set to migration add
   if [!MigrationName!] == [] (
      echo ERROR: MigrationName not specified...
      exit /b 1
   ) else (
      echo INFO: Adding migration !MigrationName!
      call ManageDatabaseMigrations.bat add !MigrationName!
   )
) else if [%Action%] == [Remove] (
   echo INFO: Option set to migration remove
   call ManageDatabaseMigrations.bat remove
) else if [%Action%] == [Update] (
   echo INFO: Option set to update database
   call ManageDatabaseMigrations.bat update
)

:eof
popd
echo Exit with error code: !errorlevel!
exit /b !errorlevel!