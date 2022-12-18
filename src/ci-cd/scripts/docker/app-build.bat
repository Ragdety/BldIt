@echo off
setlocal enabledelayedexpansion

call app-down.bat

REM This script is used to build the application
docker-compose -f app.yml build^
    --build-arg NUGET_FEED_URL=%NUGET_FEED_URL%^
    --build-arg NUGET_FEED_USERNAME=%NUGET_FEED_USERNAME%^
    --build-arg NUGET_FEED_PASSWORD=%NUGET_FEED_PASSWORD%

echo INFO: Exit code: !ERRORLEVEL!
exit /b !ERRORLEVEL!