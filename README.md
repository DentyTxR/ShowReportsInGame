# ShowReportsInGame
### Simple plugin to show ingame reports to all online staff, Made in with the EXILED framework for SCP:SL (EXILED 6)
[![Github All Releases](https://img.shields.io/github/downloads/DentyTxR/ShowReportsInGame/total.svg)]()

P.S, I'm not that good with C# so there will be some small brain moments here so if you have any code suggestions lmk, Also I plan on adding way more configs and stuff, Just message me on Discord if you got suggestions for that.

### How do I download this?
  - Go here and download the latest release, https://github.com/DentyTxR/ShowReportsInGame/releases

### Configs

```yml
# Whether or not the plugin is enabled.
is_enabled: true
# Should debug logs be enabled?
debug: false
# Should hints be enabled for report events?
enable_hints: true
# Duration for hint message sent to all RA access players.
report_hint_duration: 5
# Should AdminChat be enabled for report events?
enable_admin_chat: false
# Duration for AdminChat message sent to all RA access players.
admin_chat_report_duration: 5
# Normal report hint first line
local_report_hint_msg: '\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n<size=20><color=red>[</color><color=yellow>ShowReportsInGame</color><color=red>]</color></size>\n<size=20><color=red>/|\</color>[<color=green>NOTE: This is a normal report.</color>]<color=red>/|\</color></size>\n<size=20>[<color=yellow>Player Report, Check Console (`) For Info</color>]</size>'
# Normal report console message
local_report_console_msg: '<size=23>[<color=yellow>Normal Report</color>]</size>\n<size=23><color=orange>Reporter</color>: <color=red>%IssuerNickname%</color></size>\n<size=18>  - GameID: %IssuerGameId%</size>\n<size=18>  - UserID: %IssuerUserId%</size>\n<size=23><color=orange>Reported</color>: <color=red>%TargetNickname%</color></size>\n<size=18>  - GameID: %TargetGameId%</size>\n<size=18>  - UserID: %TargetUserId%</size>\n<size=23><color=orange>Reason</color>: <color=red>%ReportReason% </color></size>'
# Normal report adminchat
local_report_admin_chat_msg: <size=25>Normal Report!\n[<color=yellow>Check Console (`) For Info</color>]</size>
# Cheater report hint first line
cheat_report_hint_msg: '\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n<size=20><color=red>[</color><color=yellow>ShowReportsInGame</color><color=red>]</color></size>\n<size=20><color=red>/|\</color>[<color=red>WARNING: THIS IS A CHEATER REPORT</color>]<color=red>/|\</color></size>\n<size=20>[<color=yellow>Cheater Report, Check Console (`) For Info</color>]</size>'
# Normal report console message
cheat_report_console_msg: '<size=23>[<color=red>CHEATER REPORT</color>]</size>\n<size=23><color=orange>Reporter</color>: <color=red>%IssuerNickname%</color></size>\n<size=18>  - GameID: %IssuerGameId%</size>\n<size=18>  - UserID: %IssuerUserId%</size>\n<size=23><color=orange>Reported</color>: <color=red>%TargetNickname%</color></size>\n<size=18>  - GameID: %TargetGameId%</size>\n<size=18>  - UserID: %TargetUserId%</size>\n<size=23><color=orange>Reason</color>: <color=red>%ReportReason% </color></size>'
# Normal report adminchat
cheat_report_admin_chat_msg: <size=25>Cheater Report!\n[<color=yellow>Check Console (`) For Info</color>]</size>
```
### Custom variables (For now this is just for the hint, Working on custom console message)
#### Lets just call them variables, These can be used in config string messages to return info, These are case sensitive!!!

| Variable Name | Returns |
| --- | --- |
| `%IssuerUserId%` | Reporter's User ID (@steam/@discord included) |
| `%IssuerGameId%` | Reporter's Game ID (# In RA) |
| `%IssuerNickname%` | Reporter's Nickname |
| `%IssuerRole%` | Reporter's Current Role At Report Time |
| ------------------ | ------------------------------------------ |
| `%TargetUserId%` | Reported User ID (@steam/@discord included) |
| `%TargetGameId%` | Reported Game ID (# In RA) |
| `%TargetNickname%` | Reported Nickname |
| `%TargetRole%` | Reported Current Role At Report Time |
| ------------------ | ------------------------------------------ |
| `%ReportReason%` | Reason In Report |


### Previews

![Hint](https://raw.githubusercontent.com/DentyTxR/ShowReportsInGame/master/img/Screenshot%20(1635).png)
![HintCustom](https://raw.githubusercontent.com/DentyTxR/ShowReportsInGame/master/img/Screenshot%20(1641).png)
![ConsoleMessage](https://raw.githubusercontent.com/DentyTxR/ShowReportsInGame/master/img/Screenshot%20(1636).png)
