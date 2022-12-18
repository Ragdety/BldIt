@echo off

call app-run.bat

docker-compose -f app.yml logs --tail 500 -f 