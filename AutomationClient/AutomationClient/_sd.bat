set typ=sd
cd /d %~dp0
.\AutomationClient.exe -%typ% > C:\%typ%.log
