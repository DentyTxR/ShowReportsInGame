using System;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace ShowReportsInGameNwAPI
{
    public class EventHandler
    {
        [PluginEvent(ServerEventType.PlayerReport)]
        public void LocalReport(Player reporter, Player target, string reason)
        {
            string localReportHint = ShowReportsInGame.Singleton.Config.LocalReportHintMsg.Replace("%IssuerUserId%", reporter.UserId).Replace("%IssuerGameId%", reporter.PlayerId.ToString()).Replace("%IssuerNickname%", reporter.Nickname).Replace("%IssuerRole%", reporter.Role.ToString()).Replace("%TargetUserId%", target.UserId).Replace("%TargetGameId%", target.PlayerId.ToString()).Replace("%TargetNickname%", target.Nickname).Replace("%TargetRole%", target.Role.ToString()).Replace("%ReportReason%", reason).Replace(@"\n", Environment.NewLine);
            string localReportConsole = ShowReportsInGame.Singleton.Config.LocalReportConsoleMsg.Replace("%IssuerUserId%", reporter.UserId).Replace("%IssuerGameId%", reporter.PlayerId.ToString()).Replace("%IssuerNickname%", reporter.Nickname).Replace("%IssuerRole%", reporter.Role.ToString()).Replace("%TargetUserId%", target.UserId).Replace("%TargetGameId%", target.PlayerId.ToString()).Replace("%TargetNickname%", target.Nickname).Replace("%TargetRole%", target.Role.ToString()).Replace("%ReportReason%", reason).Replace(@"\n", Environment.NewLine);
            string localReportAdminChat = ShowReportsInGame.Singleton.Config.LocalReportAdminChatMsg.Replace("%IssuerUserId%", reporter.UserId).Replace("%IssuerGameId%", reporter.PlayerId.ToString()).Replace("%IssuerNickname%", reporter.Nickname).Replace("%IssuerRole%", reporter.Role.ToString()).Replace("%TargetUserId%", target.UserId).Replace("%TargetGameId%", target.PlayerId.ToString()).Replace("%TargetNickname%", target.Nickname).Replace("%TargetRole%", target.Role.ToString()).Replace("%ReportReason%", reason).Replace(@"\n", Environment.NewLine);

            if (reporter.UserId != target.UserId)
            {
                if (ShowReportsInGame.Singleton.Config.EnableHints)
                    foreach (Player player in Player.GetPlayers())
                        if (player.RemoteAdminAccess)
                        {
                            player.ReceiveHint(string.Concat(localReportHint), duration: ShowReportsInGame.Singleton.Config.ReportHintDuration);
                            player.SendConsoleMessage(message: "[ShowReportsInGame Plugin]\n" + localReportConsole, color: "yellow");
                        }

                if (ShowReportsInGame.Singleton.Config.EnableAdminChat)
                    foreach (Player player in Player.GetPlayers())
                        if(player.RemoteAdminAccess)
                            player.SendBroadcast(localReportAdminChat, ShowReportsInGame.Singleton.Config.AdminChatReportDuration, Broadcast.BroadcastFlags.AdminChat);
            }
        }


        [PluginEvent(ServerEventType.PlayerCheaterReport)]
        public void CheaterReport(Player reporter, Player target, string reason)
        {
            string cheatReportHint = ShowReportsInGame.Singleton.Config.CheatReportHintMsg.Replace("%IssuerUserId%", reporter.UserId).Replace("%IssuerGameId%", reporter.PlayerId.ToString()).Replace("%IssuerNickname%", reporter.Nickname).Replace("%IssuerRole%", reporter.Role.ToString()).Replace("%TargetUserId%", target.UserId).Replace("%TargetGameId%", target.PlayerId.ToString()).Replace("%TargetNickname%", target.Nickname).Replace("%TargetRole%", target.Role.ToString()).Replace("%ReportReason%", reason).Replace(@"\n", Environment.NewLine);
            string cheatReportConsole = ShowReportsInGame.Singleton.Config.CheatReportConsoleMsg.Replace("%IssuerUserId%", reporter.UserId).Replace("%IssuerGameId%", reporter.PlayerId.ToString()).Replace("%IssuerNickname%", reporter.Nickname).Replace("%IssuerRole%", reporter.Role.ToString()).Replace("%TargetUserId%", target.UserId).Replace("%TargetGameId%", target.PlayerId.ToString()).Replace("%TargetNickname%", target.Nickname).Replace("%TargetRole%", target.Role.ToString()).Replace("%ReportReason%", reason).Replace(@"\n", Environment.NewLine);
            string cheatReportAdminChat = ShowReportsInGame.Singleton.Config.CheatReportAdminChatMsg.Replace("%IssuerUserId%", reporter.UserId).Replace("%IssuerGameId%", reporter.PlayerId.ToString()).Replace("%IssuerNickname%", reporter.Nickname).Replace("%IssuerRole%", reporter.Role.ToString()).Replace("%TargetUserId%", target.UserId).Replace("%TargetGameId%", target.PlayerId.ToString()).Replace("%TargetNickname%", target.Nickname).Replace("%TargetRole%", target.Role.ToString()).Replace("%ReportReason%", reason).Replace(@"\n", Environment.NewLine);

            if (reporter.UserId != target.UserId)
            {
                if (ShowReportsInGame.Singleton.Config.EnableHints)
                    foreach (Player player in Player.GetPlayers())
                        if (player.RemoteAdminAccess)
                        {
                            player.ReceiveHint(string.Concat(cheatReportHint), duration: ShowReportsInGame.Singleton.Config.ReportHintDuration);
                            player.SendConsoleMessage(message: "[ShowReportsInGame Plugin]\n" + cheatReportConsole, color: "yellow");
                        }

                if (ShowReportsInGame.Singleton.Config.EnableAdminChat)
                    foreach (Player player in Player.GetPlayers())
                        if (player.RemoteAdminAccess)
                            player.SendBroadcast(cheatReportAdminChat, ShowReportsInGame.Singleton.Config.AdminChatReportDuration, Broadcast.BroadcastFlags.AdminChat);
            }
        }
    }
}