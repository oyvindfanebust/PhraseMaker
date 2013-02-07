@echo off

SET DIR=%~dp0%packages\psake.4.2.0.1\tools

if '%1'=='/?' goto help
if '%1'=='-help' goto help
if '%1'=='-h' goto help

powershell -NoProfile -ExecutionPolicy Bypass -Command "& '%DIR%\psake.ps1' %*; if ($psake.build_success -eq $false) { exit 1 } else { exit 0 }"
goto :eof

:help
powershell -NoProfile -ExecutionPolicy Bypass -Command "& '%DIR%\psake.ps1' -help"
