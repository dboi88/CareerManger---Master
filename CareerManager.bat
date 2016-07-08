@echo off
set SOURCE="C:\Users\Winston\Documents\Visual Studio 2015\Projects\CareerManager - Master\Output"
set DESTINATION="C:\Users\Winston\Documents\Visual Studio 2015\Projects\CareerManager - Master\Kerbal Space Program\GameData\CareerManager"
xcopy %SOURCE% %DESTINATION% /D /E /C /R /I /K /Y
call KSP_x64.exe
EXIT