@echo off
cd %~dp0
echo This tool should be run to add resources post-build
pause
xcopy .\Assets\Resources\bfgminer-5.5.0-win32\ ".\Build\GamerClub_Data\Resources\bfg\"
pause