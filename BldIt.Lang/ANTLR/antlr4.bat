@echo off
echo INFO: Setting CLASSPATH variable...
set CLASSPATH=C:\Program Files\Java\libs\antlr-4.10.1-complete.jar;%CLASSPATH%

java org.antlr.v4.Tool %*