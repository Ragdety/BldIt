@echo off

docker login -u %BLDIT_DOCKER_REGISTRY_USER% bldit.jfrog.io --password-stdin

exit /b %ERRORLEVEL%