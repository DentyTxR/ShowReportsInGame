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

		//Normal self report stuffz
		[Description("Should a broadcast be sent to a player when they try reporting themself in a normal report?")]
		public bool NormalSelfReportBroadcastEnabled { get; set; } = true;

		[Description("Broadcast message sent to player reporting themself in a normal report")]
		public string NormalSelfReportBroadcast { get; set; } = "Why are you trying to report yourself?";

		[Description("Broadcast message duration sent to player reporting themself in a normal report")]
		public ushort NormalSelfReportBroadcastDuration { get; set; } = 5;

		[Description("Duration for hint message sent to all RA access players about self report in a normal report")]
		public ushort NormalSelfReportHintDuration { get; set; } = 5;

		//Normal report stuffz
		[Description("Duration for hint message sent to all RA access players about normal report")]
		public ushort NormalReportHintDuration { get; set; } = 5;


		//Cheater self report stuffz
		[Description("Should a broadcast be sent to a player when they try reporting themself in a cheater report?")]
		public bool CheaterSelfReportBroadcastEnabled { get; set; } = true;

		[Description("Broadcast message sent to player reporting themself in a normal report")]
		public string CheaterSelfReportBroadcast { get; set; } = "Why are you trying to report yourself?";

		[Description("Broadcast message duration sent to player reporting themself in a normal report")]
		public ushort CheaterSelfReportBroadcastDuration { get; set; } = 5;

		[Description("Duration for hint message sent to all RA access players about self report in a normal report")]
		public ushort CheaterSelfReportHintDuration { get; set; } = 5;

		//Cheater report stuffz
		[Description("Duration for hint message sent to all RA access players about normal report")]
		public ushort CheaterReportHintDuration { get; set; } = 5;


		//Custom hint strings
		//Normal selfreport custom text
		[Description("Normal selfreport hint first line")]
		public string NormalSelfreportStringOne { get; set; } = @"<size=20><color=red>[</color><color=yellow>ShowReportsInGame</color><color=red>]</color></size>";

		[Description("Normal selfreport hint second line")]
		public string NormalSelfreportStringTwo { get; set; } = @"<size=20><color=red>/|\</color>[<color=red>NOTE: THIS IS A SELF-REPORT</color>]<color=red>/|\</color></size>";

		[Description("Normal selfreport hint third line")]
		public string NormalSelfreportStringThree { get; set; } = @"<size=20>[<color=yellow>Player Report, Check Console (`) For Info</color>]</size>";

		//Normal report custom text
		[Description("Normal report hint first line")]
		public string NormalreportStringOne { get; set; } = @"<size=20><color=red>[</color><color=yellow>ShowReportsInGame</color><color=red>]</color></size>";

		[Description("Normal report hint second line")]
		public string NormalreportStringTwo { get; set; } = @"<size=20><color=red>/|\</color>[<color=green>NOTE: This is a normal report.</color>]<color=red>/|\</color></size>";

		[Description("Normal report hint third line")]
		public string NormalreportStringThree { get; set; } = @"<size=20>[<color=yellow>Player Report, Check Console (`) For Info</color>]</size>";

		//Cheater selfreport custom text
		[Description("Cheater selfreport hint first line")]
		public string CheaterSelfreportStringOne { get; set; } = @"<size=20><color=red>[</color><color=yellow>ShowReportsInGame</color><color=red>]</color></size>";

		[Description("Cheater selfreport hint second line")]
		public string CheaterSelfreportStringTwo { get; set; } = @"<size=20><color=red>/|\</color>[<color=red>WARNING: THIS IS A CHEATER SELFREPORT</color>]<color=red>/|\</color></size>";

		[Description("Cheater selfreport hint third line")]
		public string CheaterSelfreportStringThree { get; set; } = @"<size=20>[<color=yellow>Cheater Report, Check Console (`) For Info</color>]</size>";

		//Cheater report custom text
		[Description("Cheater report hint first line")]
		public string CheaterreportStringOne { get; set; } = @"<size=20><color=red>[</color><color=yellow>ShowReportsInGame</color><color=red>]</color></size>";

		[Description("Cheater report hint second line")]
		public string CheaterreportStringTwo { get; set; } = @"<size=20><color=red>/|\</color>[<color=red>WARNING: THIS IS A CHEATER REPORT</color>]<color=red>/|\</color></size>";

		[Description("Cheater report hint third line")]
		public string CheaterreportStringThree { get; set; } = @"<size=20>[<color=yellow>Cheater Report, Check Console (`) For Info</color>]</size>";
	}
}