using Exiled.API.Interfaces;
using System.ComponentModel;

namespace ShowReportsInGame
{
	public class Config : IConfig
	{

		[Description("Whether or not the plugin is enabled.")]
		public bool IsEnabled { get; set; } = true;

		[Description("Should debug logs be enabled?")]
		public bool EnableDebug { get; set; } = false;


		[Description("Should a broadcast be sent to the player that reported themself?")]
		public bool SelfReportBroadcastEnabled { get; set; } = true;

		[Description("Broadcast string for selfreport message.")]
		public string SelfReportBroadcast { get; set; } = "Why are you trying to report yourself?";

		[Description("Selfreport broadcast duration")]
		public ushort SelfReportBroadcastDuration { get; set; } = 5;

		[Description("Duration for hint message sent to all RA access players")]
		public ushort ReportHintDuration { get; set; } = 5;


		//Normal selfreport custom text
		[Description("Normal selfreport hint first line")]
		public string NormalSelfReportStringOne { get; set; } = @"\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n<size=20><color=red>[</color><color=yellow>ShowReportsInGame</color><color=red>]</color></size>\n<size=20><color=red>/|\</color>[<color=red>NOTE: THIS IS A SELF-REPORT</color>]<color=red>/|\</color></size>\n<size=20>[<color=yellow>Player Report, Check Console (`) For Info</color>]</size>";

        //Normal selfreport custom console string
		[Description("Normal selfreport console message")]
        public string LocalSelfReportConsoleMsg { get; set; } = @"[ShowReportsInGame Plugin]" + @"\n<size=23>[<color=yellow>Normal Self-Report</color>]</size>\n<size=23><color=orange>Reporter</color>: <color=red>%IssuerNickname%</color></size>\n<size=18>  - GameID: %IssuerGameId%</size>\n<size=18>  - UserID: %IssuerUserId%</size>\n<size=23><color=orange>Reported</color>: <color=red>%TargetNickname%</color></size>\n<size=18>  - GameID: %TargetGameId%</size>\n<size=18>  - UserID: %TargetUserId%</size>\n<size=23><color=orange>Reason</color>: <color=red>%ReportReason% </color></size>";

        //Normal report custom text
        [Description("Normal report hint first line")]
		public string NormalReportStringOne { get; set; } = @"\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n<size=20><color=red>[</color><color=yellow>ShowReportsInGame</color><color=red>]</color></size>\n<size=20><color=red>/|\</color>[<color=green>NOTE: This is a normal report.</color>]<color=red>/|\</color></size>\n<size=20>[<color=yellow>Player Report, Check Console (`) For Info</color>]</size>";

        //Normal report custom console string
        [Description("Normal selfreport console message")]
        public string LocalReportConsoleMsg { get; set; } = @"[ShowReportsInGame Plugin]" + @"\n<size=23>[<color=yellow>Normal Report</color>]</size>\n<size=23><color=orange>Reporter</color>: <color=red>%IssuerNickname%</color></size>\n<size=18>  - GameID: %IssuerGameId%</size>\n<size=18>  - UserID: %IssuerUserId%</size>\n<size=23><color=orange>Reported</color>: <color=red>%TargetNickname%</color></size>\n<size=18>  - GameID: %TargetGameId%</size>\n<size=18>  - UserID: %TargetUserId%</size>\n<size=23><color=orange>Reason</color>: <color=red>%ReportReason% </color></size>";

        //Cheater selfreport custom text
        [Description("Cheater selfreport hint first line")]
		public string CheaterSelfReportStringOne { get; set; } = @"\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n<size=20><color=red>[</color><color=yellow>ShowReportsInGame</color><color=red>]</color></size>\n<size=20><color=red>/|\</color>[<color=red>WARNING: THIS IS A CHEATER SELFREPORT</color>]<color=red>/|\</color></size>\n<size=20>[<color=yellow>Cheater Report, Check Console (`) For Info</color>]</size>";

        //Cheater selfreport custom console string
        [Description("Normal selfreport console message")]
        public string CheaterSelfReportConsoleMsg { get; set; } = @"[ShowReportsInGame Plugin]" + @"\n<size=23>[<color=red>CHEATER SELF-REPORT</color>]</size>\n<size=23><color=orange>Reporter</color>: <color=red>%IssuerNickname%</color></size>\n<size=18>  - GameID: %IssuerGameId%</size>\n<size=18>  - UserID: %IssuerUserId%</size>\n<size=23><color=orange>Reported</color>: <color=red>%TargetNickname%</color></size>\n<size=18>  - GameID: %TargetGameId%</size>\n<size=18>  - UserID: %TargetUserId%</size>\n<size=23><color=orange>Reason</color>: <color=red>%ReportReason% </color></size>";

        //Cheater report custom text
        [Description("Cheater report hint first line")]
		public string CheaterReportStringOne { get; set; } = @"\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n<size=20><color=red>[</color><color=yellow>ShowReportsInGame</color><color=red>]</color></size>\n<size=20><color=red>/|\</color>[<color=red>WARNING: THIS IS A CHEATER REPORT</color>]<color=red>/|\</color></size>\n<size=20>[<color=yellow>Cheater Report, Check Console (`) For Info</color>]</size>";

        //Cheater report custom console string
        [Description("Normal selfreport console message")]
        public string CheaterReportConsoleMsg { get; set; } = @"[ShowReportsInGame Plugin]" + @"\n<size=23>[<color=red>CHEATER REPORT</color>]</size>\n<size=23><color=orange>Reporter</color>: <color=red>%IssuerNickname%</color></size>\n<size=18>  - GameID: %IssuerGameId%</size>\n<size=18>  - UserID: %IssuerUserId%</size>\n<size=23><color=orange>Reported</color>: <color=red>%TargetNickname%</color></size>\n<size=18>  - GameID: %TargetGameId%</size>\n<size=18>  - UserID: %TargetUserId%</size>\n<size=23><color=orange>Reason</color>: <color=red>%ReportReason% </color></size>";
    }
}