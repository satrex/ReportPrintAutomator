set typ=dd
cd /d %~dp0
.\AutomationClient.exe -%typ% > C:\%typ%.log
