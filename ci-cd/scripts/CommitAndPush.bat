@echo off
setlocal enabledelayedexpansion

git status
git add .
git status
pause
git commit -m "%1"
git push

echo INFO: Exit with code !errorlevel!
exit /b !errorlevel!