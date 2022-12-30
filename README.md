# ShowReportsInGame


P.S, I'm not that good with C# so there will be some small brain moments here so if you have any code suggestions lmk, Also I plan on adding way more configs and stuff, Just message me on Discord if you got suggestions for that.

### How do I download this?
  - Go here and download the latest release, https://github.com/DentyTxR/ShowReportsInGame/releases

### Configs

```yml
# Whether or not the plugin is enabled.
is_enabled: true
# Should debug logs be enabled?
enable_debug: false
# Should a broadcast be sent to the player that reported themself?
self_report_broadcast_enabled: true
# Broadcast string for selfreport message.
self_report_broadcast: Why are you trying to report yourself?
# Selfreport broadcast duration
self_report_broadcast_duration: 5
# Duration for hint message sent to all RA access players
report_hint_duration: 5
# Normal selfreport hint first line
normal_self_report_string_one: '\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n<size=20><color=red>[</color><color=yellow>ShowReportsInGame</color><color=red>]</color></size>\n<size=20><color=red>/|\</color>[<color=red>NOTE: THIS IS A SELF-REPORT</color>]<color=red>/|\</color></size>\n<size=20>[<color=yellow>Player Report, Check Console (`) For Info</color>]</size>'
# Normal selfreport console message
local_self_report_console_msg: '[ShowReportsInGame Plugin]\n<size=23>[<color=yellow>Normal Self-Report</color>]</size>\n<size=23><color=orange>Reporter</color>: <color=red>%IssuerNickname%</color></size>\n<size=18>  - GameID: %IssuerGameId%</size>\n<size=18>  - UserID: %IssuerUserId%</size>\n<size=23><color=orange>Reported</color>: <color=red>%TargetNickname%</color></size>\n<size=18>  - GameID: %TargetGameId%</size>\n<size=18>  - UserID: %TargetUserId%</size>\n<size=23><color=orange>Reason</color>: <color=red>%ReportReason% </color></size>'
# Normal report hint first line
normal_report_string_one: '\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n<size=20><color=red>[</color><color=yellow>ShowReportsInGame</color><color=red>]</color></size>\n<size=20><color=red>/|\</color>[<color=green>NOTE: This is a normal report.</color>]<color=red>/|\</color></size>\n<size=20>[<color=yellow>Player Report, Check Console (`) For Info</color>]</size>'
# Normal selfreport console message
local_report_console_msg: '[ShowReportsInGame Plugin]\n<size=23>[<color=yellow>Normal Report</color>]</size>\n<size=23><color=orange>Reporter</color>: <color=red>%IssuerNickname%</color></size>\n<size=18>  - GameID: %IssuerGameId%</size>\n<size=18>  - UserID: %IssuerUserId%</size>\n<size=23><color=orange>Reported</color>: <color=red>%TargetNickname%</color></size>\n<size=18>  - GameID: %TargetGameId%</size>\n<size=18>  - UserID: %TargetUserId%</size>\n<size=23><color=orange>Reason</color>: <color=red>%ReportReason% </color></size>'
# Cheater selfreport hint first line
cheater_self_report_string_one: '\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n<size=20><color=red>[</color><color=yellow>ShowReportsInGame</color><color=red>]</color></size>\n<size=20><color=red>/|\</color>[<color=red>WARNING: THIS IS A CHEATER SELFREPORT</color>]<color=red>/|\</color></size>\n<size=20>[<color=yellow>Cheater Report, Check Console (`) For Info</color>]</size>'
# Normal selfreport console message
cheater_self_report_console_msg: '[ShowReportsInGame Plugin]\n<size=23>[<color=red>CHEATER SELF-REPORT</color>]</size>\n<size=23><color=orange>Reporter</color>: <color=red>%IssuerNickname%</color></size>\n<size=18>  - GameID: %IssuerGameId%</size>\n<size=18>  - UserID: %IssuerUserId%</size>\n<size=23><color=orange>Reported</color>: <color=red>%TargetNickname%</color></size>\n<size=18>  - GameID: %TargetGameId%</size>\n<size=18>  - UserID: %TargetUserId%</size>\n<size=23><color=orange>Reason</color>: <color=red>%ReportReason% </color></size>'
# Cheater report hint first line
cheater_report_string_one: '\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n<size=20><color=red>[</color><color=yellow>ShowReportsInGame</color><color=red>]</color></size>\n<size=20><color=red>/|\</color>[<color=red>WARNING: THIS IS A CHEATER REPORT</color>]<color=red>/|\</color></size>\n<size=20>[<color=yellow>Cheater Report, Check Console (`) For Info</color>]</size>'
# Normal selfreport console message
cheater_report_console_msg: '[ShowReportsInGame Plugin]\n<size=23>[<color=red>CHEATER REPORT</color>]</size>\n<size=23><color=orange>Reporter</color>: <color=red>%IssuerNickname%</color></size>\n<size=18>  - GameID: %IssuerGameId%</size>\n<size=18>  - UserID: %IssuerUserId%</size>\n<size=23><color=orange>Reported</color>: <color=red>%TargetNickname%</color></size>\n<size=18>  - GameID: %TargetGameId%</size>\n<size=18>  - UserID: %TargetUserId%</size>\n<size=23><color=orange>Reason</color>: <color=red>%ReportReason% </color></size>'

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
