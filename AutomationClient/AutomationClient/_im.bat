set typ=im
cd /d %~dp0
.\AutomationClient.exe -%typ% > C:\%typ%.log
