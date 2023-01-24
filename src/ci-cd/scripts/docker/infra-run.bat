@echo off

call infra-down.bat

docker-compose -f infra.yml up