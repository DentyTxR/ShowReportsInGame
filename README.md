# ShowReportsInGame
### Simple plugin to show ingame reports to all online staff, Made in EXILED for SCP:SL


P.S, I'm not that good with C# so there will be some small brain moments here so if you have any code suggestions lmk, Also I plan on adding way more configs and stuff, Just message me on Discord if you got suggestions for that.

### How do I download this?
  - Go here and download the latest release, https://github.com/DentyTxR/ShowReportsInGame/releases

### Configs (Breaking from first release)

```yml
ShowReportsInGame:
# Whether or not the plugin is enabled.
  is_enabled: true
  # Should debug logs be enabled?
  enable_debug: false
  # Should a broadcast be sent to a player when they try reporting themself in a normal report?
  normal_self_report_broadcast_enabled: true
  # Broadcast message sent to player reporting themself in a normal report
  normal_self_report_broadcast: Why are you trying to report yourself?
  # Broadcast message duration sent to player reporting themself in a normal report
  normal_self_report_broadcast_duration: 5
  # Duration for hint message sent to all RA access players about self report in a normal report
  normal_self_report_hint_duration: 5
  # Duration for hint message sent to all RA access players about normal report
  normal_report_hint_duration: 5
  # Should a broadcast be sent to a player when they try reporting themself in a cheater report?
  cheater_self_report_broadcast_enabled: true
  # Broadcast message sent to player reporting themself in a normal report
  cheater_self_report_broadcast: Why are you trying to report yourself?
  # Broadcast message duration sent to player reporting themself in a normal report
  cheater_self_report_broadcast_duration: 5
  # Duration for hint message sent to all RA access players about self report in a normal report
  cheater_self_report_hint_duration: 5
  # Duration for hint message sent to all RA access players about normal report
  cheater_report_hint_duration: 5
  # Normal selfreport hint first line
  normal_selfreport_string_one: '<size=20><color=red>[</color><color=yellow>ShowReportsInGame</color><color=red>]</color></size>'
  # Normal selfreport hint second line
  normal_selfreport_string_two: '<size=20><color=red>/|\</color>[<color=red>NOTE: THIS IS A SELF-REPORT</color>]<color=red>/|\</color></size>'
  # Normal selfreport hint third line
  normal_selfreport_string_three: '<size=20>[<color=yellow>Player Report, Check Console (`) For Info</color>]</size>'
  # Normal report hint first line
  normalreport_string_one: '<size=20><color=red>[</color><color=yellow>ShowReportsInGame</color><color=red>]</color></size>'
  # Normal report hint second line
  normalreport_string_two: '<size=20><color=red>/|\</color>[<color=green>NOTE: This is a normal report.</color>]<color=red>/|\</color></size>'
  # Normal report hint third line
  normalreport_string_three: '<size=20>[<color=yellow>Player Report, Check Console (`) For Info</color>]</size>'
  # Cheater selfreport hint first line
  cheater_selfreport_string_one: '<size=20><color=red>[</color><color=yellow>ShowReportsInGame</color><color=red>]</color></size>'
  # Cheater selfreport hint second line
  cheater_selfreport_string_two: '<size=20><color=red>/|\</color>[<color=red>WARNING: THIS IS A CHEATER SELFREPORT</color>]<color=red>/|\</color></size>'
  # Cheater selfreport hint third line
  cheater_selfreport_string_three: '<size=20>[<color=yellow>Cheater Report, Check Console (`) For Info</color>]</size>'
  # Cheater report hint first line
  cheaterreport_string_one: '<size=20><color=red>[</color><color=yellow>ShowReportsInGame</color><color=red>]</color></size>'
  # Cheater report hint second line
  cheaterreport_string_two: '<size=20><color=red>/|\</color>[<color=red>WARNING: THIS IS A CHEATER REPORT</color>]<color=red>/|\</color></size>'
  # Cheater report hint third line
  cheaterreport_string_three: '<size=20>[<color=yellow>Cheater Report, Check Console (`) For Info</color>]</size>'
```

### Previews

[Default config]
![Hint](https://raw.githubusercontent.com/DentyTxR/ShowReportsInGame/master/img/Screenshot%20(1635).png)
[Custom config]
![HintCustom](https://raw.githubusercontent.com/DentyTxR/ShowReportsInGame/master/img/Screenshot%20(1641).png)
[DefaultConsoleMessage]
![ConsoleMessage](https://raw.githubusercontent.com/DentyTxR/ShowReportsInGame/master/img/Screenshot%20(1636).png)
