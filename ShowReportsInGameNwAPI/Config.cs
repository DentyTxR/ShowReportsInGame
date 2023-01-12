using System.ComponentModel;

namespace ShowReportsInGameNwAPI
{
    public class Config
    {

        [Description("Whether or not the plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Should debug logs be enabled?")]
        public bool Debug { get; set; } = false;

        [Description("Should hints be enabled for report events?")]
        public bool EnableHints { get; set; } = true;

        [Description("Duration for hint message sent to all RA access players.")]
        public ushort ReportHintDuration { get; set; } = 5;

        [Description("Should AdminChat be enabled for report events?")]
        public bool EnableAdminChat { get; set; } = false;

        [Description("Duration for AdminChat message sent to all RA access players.")]
        public ushort AdminChatReportDuration { get; set; } = 5;

        //Normal report custom text
        [Description("Normal report hint first line")]
        public string LocalReportHintMsg { get; set; } = @"\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n<size=20><color=red>[</color><color=yellow>ShowReportsInGame</color><color=red>]</color></size>\n<size=20><color=red>/|\</color>[<color=green>NOTE: This is a normal report.</color>]<color=red>/|\</color></size>\n<size=20>[<color=yellow>Player Report, Check Console (`) For Info</color>]</size>";

        //Normal report custom console string
        [Description("Normal report console message")]
        public string LocalReportConsoleMsg { get; set; } = @"<size=23>[<color=yellow>Normal Report</color>]</size>\n<size=23><color=orange>Reporter</color>: <color=red>%IssuerNickname%</color></size>\n<size=18>  - GameID: %IssuerGameId%</size>\n<size=18>  - UserID: %IssuerUserId%</size>\n<size=23><color=orange>Reported</color>: <color=red>%TargetNickname%</color></size>\n<size=18>  - GameID: %TargetGameId%</size>\n<size=18>  - UserID: %TargetUserId%</size>\n<size=23><color=orange>Reason</color>: <color=red>%ReportReason% </color></size>";

        //Normal report custom adminchat string
        [Description("Normal report adminchat")]
        public string LocalReportAdminChatMsg { get; set; } = @"<size=25>Normal Report!\n[Check Console (`) For Info]</size>";

        //Cheater report custom text
        [Description("Cheater report hint first line")]
        public string CheatReportHintMsg { get; set; } = @"\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n<size=20><color=red>[</color><color=yellow>ShowReportsInGame</color><color=red>]</color></size>\n<size=20><color=red>/|\</color>[<color=red>WARNING: THIS IS A CHEATER REPORT</color>]<color=red>/|\</color></size>\n<size=20>[<color=yellow>Cheater Report, Check Console (`) For Info</color>]</size>";

        //Cheater report custom console string
        [Description("Normal report console message")]
        public string CheatReportConsoleMsg { get; set; } = @"<size=23>[<color=red>CHEATER REPORT</color>]</size>\n<size=23><color=orange>Reporter</color>: <color=red>%IssuerNickname%</color></size>\n<size=18>  - GameID: %IssuerGameId%</size>\n<size=18>  - UserID: %IssuerUserId%</size>\n<size=23><color=orange>Reported</color>: <color=red>%TargetNickname%</color></size>\n<size=18>  - GameID: %TargetGameId%</size>\n<size=18>  - UserID: %TargetUserId%</size>\n<size=23><color=orange>Reason</color>: <color=red>%ReportReason% </color></size>";

        //Cheater report custom adminchat string
        [Description("Normal report adminchat")]
        public string CheatReportAdminChatMsg { get; set; } = @"<size=25>Cheater Report!\n[Check Console (`) For Info]</size>";
    }
}