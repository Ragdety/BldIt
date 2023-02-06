@echo off

REM This script is used to add the Artifactory NuGet source to the NuGet.Config file
set configFile=C:\Users\%USERNAME%\AppData\Roaming\NuGet.Config

rem Get and set the url:
set "psCommand=powershell -Command "$pword = read-host 'Enter BldIt JFrog Nuget Url' -AsSecureString ; ^
    $BSTR=[System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($pword); ^
        [System.Runtime.InteropServices.Marshal]::PtrToStringAuto($BSTR)""
for /f "usebackq delims=" %%p in (`%psCommand%`) do set url=%%p

echo INFO: Setting NUGET_FEED_URL
setx NUGET_FEED_URL %url%
set NUGET_FEED_URL=%url%

rem Get and set the username:
set "psCommand=powershell -Command "$pword = read-host 'Enter BldIt JFrog Nuget Username' -AsSecureString ; ^
    $BSTR=[System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($pword); ^
        [System.Runtime.InteropServices.Marshal]::PtrToStringAuto($BSTR)""
for /f "usebackq delims=" %%p in (`%psCommand%`) do set uName=%%p

echo INFO: Setting NUGET_FEED_USERNAME
setx NUGET_FEED_USERNAME %uName%
set NUGET_FEED_USERNAME=%uName%

rem Get and set the password:
set "psCommand=powershell -Command "$pword = read-host 'Enter BldIt JFrog Nuget Password' -AsSecureString ; ^
    $BSTR=[System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($pword); ^
        [System.Runtime.InteropServices.Marshal]::PtrToStringAuto($BSTR)""
for /f "usebackq delims=" %%p in (`%psCommand%`) do set password=%%p

echo INFO: Setting NUGET_FEED_PASSWORD
setx NUGET_FEED_PASSWORD %password%
set NUGET_FEED_PASSWORD=%password%

echo URL: 
echo %NUGET_FEED_URL%
rem Set the NuGet source
dotnet nuget add source %NUGET_FEED_URL%^
    -n Artifactory^
    -u %NUGET_FEED_USERNAME%^
    -p %NUGET_FEED_PASSWORD%^
    --configfile %configFile%

echo INFO: Exit code: %ERRORLEVEL%
exit /b %ERRORLEVEL%