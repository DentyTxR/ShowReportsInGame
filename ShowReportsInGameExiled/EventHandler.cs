using System;
using Exiled.API.Features;
using Player = Exiled.API.Features.Player;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;

namespace ShowReportsInGameExiled
{
    public class EventHandler
    {
        public void LocalReport(LocalReportingEventArgs ev)
        {
            string localReportHint = LocalReportHintString(ev);
            string localReportConsole = LocalReportConsoleString(ev);
            string localReportAdminChat = LocalReportAdminChatString(ev);

            if (ev.Player.UserId != ev.Target.UserId)
            {
                if (ShowReportsInGame.Singleton.Config.EnableHints)
                {
                    foreach (var player in Player.List)
                        if (player.RemoteAdminAccess)
                        {
                            player.ShowHint(string.Concat(localReportHint), duration: ShowReportsInGame.Singleton.Config.ReportHintDuration);
                            player.SendConsoleMessage(message: "[ShowReportsInGame Plugin]\n" + localReportConsole, color: "yellow");
                        }
                }
                if (ShowReportsInGame.Singleton.Config.EnableAdminChat)
                {
                    foreach (var player in Player.List)
                        if (player.RemoteAdminAccess)
                        {
                            player.Broadcast(ShowReportsInGame.Singleton.Config.AdminChatReportDuration, localReportAdminChat, Broadcast.BroadcastFlags.AdminChat);
                        }
                }
            }
        }
        public void CheaterReport(ReportingCheaterEventArgs ev)
        {
            string cheatReportHint = CheatReportHintString(ev);
            string cheatReportConsole = CheatReportConsoleString(ev);
            string cheatReportAdminChat = CheatReportAdminChatString(ev);

            if (ev.Target.UserId != ev.Player.UserId)
            {
                if (ShowReportsInGame.Singleton.Config.EnableHints)
                {
                    foreach (var player in Player.List)
                        if (player.RemoteAdminAccess)
                        {
                            player.ShowHint(string.Concat(cheatReportHint), duration: ShowReportsInGame.Singleton.Config.ReportHintDuration);
                            player.SendConsoleMessage(message: "[ShowReportsInGame Plugin]\n" + cheatReportConsole, color: "yellow");
                        }
                }
                if (ShowReportsInGame.Singleton.Config.EnableAdminChat)
                {
                    foreach (var player in Player.List)
                        if (player.RemoteAdminAccess)
                        {
                            player.Broadcast(ShowReportsInGame.Singleton.Config.AdminChatReportDuration, cheatReportAdminChat, Broadcast.BroadcastFlags.AdminChat);
                        }
                }
            }
        }

        //Hint string builders
        private string LocalReportHintString(LocalReportingEventArgs LocalReporting) { return ShowReportsInGame.Singleton.Config.LocalReportHintMsg.Replace("%IssuerUserId%", LocalReporting.Player.UserId).Replace("%IssuerGameId%", LocalReporting.Player.Id.ToString()).Replace("%IssuerNickname%", LocalReporting.Player.Nickname).Replace("%IssuerRole%", LocalReporting.Player.Role.Type.ToString()).Replace("%TargetUserId%", LocalReporting.Target.UserId).Replace("%TargetGameId%", LocalReporting.Target.Id.ToString()).Replace("%TargetNickname%", LocalReporting.Target.Nickname).Replace("%TargetRole%", LocalReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", LocalReporting.Reason).Replace(@"\n", Environment.NewLine); }
        private string CheatReportHintString(ReportingCheaterEventArgs CheaterReporting) { return ShowReportsInGame.Singleton.Config.CheatReportHintMsg.Replace("%IssuerUserId%", CheaterReporting.Player.UserId).Replace("%IssuerGameId%", CheaterReporting.Player.Id.ToString()).Replace("%IssuerNickname%", CheaterReporting.Player.Nickname).Replace("%IssuerRole%", CheaterReporting.Player.Role.Type.ToString()).Replace("%TargetUserId%", CheaterReporting.Target.UserId).Replace("%TargetGameId%", CheaterReporting.Target.Id.ToString()).Replace("%TargetNickname%", CheaterReporting.Target.Nickname).Replace("%TargetRole%", CheaterReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", CheaterReporting.Reason).Replace(@"\n", Environment.NewLine); }

        //Console string builders
        private string LocalReportConsoleString(LocalReportingEventArgs LocalReporting) { return ShowReportsInGame.Singleton.Config.LocalReportConsoleMsg.Replace("%IssuerUserId%", LocalReporting.Player.UserId).Replace("%IssuerGameId%", LocalReporting.Player.Id.ToString()).Replace("%IssuerNickname%", LocalReporting.Player.Nickname).Replace("%IssuerRole%", LocalReporting.Player.Role.Type.ToString()).Replace("%TargetUserId%", LocalReporting.Target.UserId).Replace("%TargetGameId%", LocalReporting.Target.Id.ToString()).Replace("%TargetNickname%", LocalReporting.Target.Nickname).Replace("%TargetRole%", LocalReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", LocalReporting.Reason).Replace(@"\n", Environment.NewLine); }
        private string CheatReportConsoleString(ReportingCheaterEventArgs CheaterReporting) { return ShowReportsInGame.Singleton.Config.CheatReportConsoleMsg.Replace("%IssuerUserId%", CheaterReporting.Player.UserId).Replace("%IssuerGameId%", CheaterReporting.Player.Id.ToString()).Replace("%IssuerNickname%", CheaterReporting.Player.Nickname).Replace("%IssuerRole%", CheaterReporting.Player.Role.Type.ToString()).Replace("%TargetUserId%", CheaterReporting.Target.UserId).Replace("%TargetGameId%", CheaterReporting.Target.Id.ToString()).Replace("%TargetNickname%", CheaterReporting.Target.Nickname).Replace("%TargetRole%", CheaterReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", CheaterReporting.Reason).Replace(@"\n", Environment.NewLine); }

        //AdminChat string builders
        private string LocalReportAdminChatString(LocalReportingEventArgs LocalReporting) { return ShowReportsInGame.Singleton.Config.LocalReportAdminChatMsg.Replace("%IssuerUserId%", LocalReporting.Player.UserId).Replace("%IssuerGameId%", LocalReporting.Player.Id.ToString()).Replace("%IssuerNickname%", LocalReporting.Player.Nickname).Replace("%IssuerRole%", LocalReporting.Player.Role.Type.ToString()).Replace("%TargetUserId%", LocalReporting.Target.UserId).Replace("%TargetGameId%", LocalReporting.Target.Id.ToString()).Replace("%TargetNickname%", LocalReporting.Target.Nickname).Replace("%TargetRole%", LocalReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", LocalReporting.Reason).Replace(@"\n", Environment.NewLine); }
        private string CheatReportAdminChatString(ReportingCheaterEventArgs CheaterReporting) { return ShowReportsInGame.Singleton.Config.CheatReportAdminChatMsg.Replace("%IssuerUserId%", CheaterReporting.Player.UserId).Replace("%IssuerGameId%", CheaterReporting.Player.Id.ToString()).Replace("%IssuerNickname%", CheaterReporting.Player.Nickname).Replace("%IssuerRole%", CheaterReporting.Player.Role.Type.ToString()).Replace("%TargetUserId%", CheaterReporting.Target.UserId).Replace("%TargetGameId%", CheaterReporting.Target.Id.ToString()).Replace("%TargetNickname%", CheaterReporting.Target.Nickname).Replace("%TargetRole%", CheaterReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", CheaterReporting.Reason).Replace(@"\n", Environment.NewLine); }

    }
}