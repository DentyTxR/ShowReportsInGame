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
		[Description("Broadcast message sent to player reporting themself in a normal report")]
		public string NormalSelfReportMessage { get; set; } = "Why are you trying to report yourself?";

		[Description("Broadcast message duration sent to player reporting themself in a normal report")]
		public ushort NormalSelfReportMessageDuration { get; set; } = 5;

		[Description("Duration for hint message sent to all RA access players about self report in a normal report")]
		public ushort NormalSelfReportHintDuration { get; set; } = 5;

		//Normal report stuffz
		[Description("Duration for hint message sent to all RA access players about normal report")]
		public ushort NormalReportHintDuration { get; set; } = 5;


		//Cheater self report stuffz
		[Description("Broadcast message sent to player reporting themself in a normal report")]
		public string CheaterSelfReportMessage { get; set; } = "Why are you trying to report yourself?";

		[Description("Broadcast message duration sent to player reporting themself in a normal report")]
		public ushort CheaterSelfReportMessageDuration { get; set; } = 5;

		[Description("Duration for hint message sent to all RA access players about self report in a normal report")]
		public ushort CheaterSelfReportHintDuration { get; set; } = 5;

		//Cheater report stuffz
		[Description("Duration for hint message sent to all RA access players about normal report")]
		public ushort CheaterReportHintDuration { get; set; } = 5;
	}
}