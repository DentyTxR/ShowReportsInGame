using System;
using Exiled.API.Features;
using System.Text;
using Player = Exiled.API.Features.Player;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;

namespace ShowReportsInGameExiled
{
    public class EventHandler
    {
        public void LocalReport(LocalReportingEventArgs ev)
        {
            if (ev.Player.UserId == ev.Target.UserId)
                ev.IsAllowed = false;

            string localReportHint = LocalReportHintString(ev);
            string localReportConsole = LocalReportConsoleString(ev);
            string localReportAdminChat = LocalReportAdminChatString(ev);

            if (ShowReportsInGame.Singleton.Config.ReportCharacterLimit != 0 && ev.Reason.Length > ShowReportsInGame.Singleton.Config.ReportCharacterLimit)
            {
                ev.IsAllowed = false;
                ev.Player.Broadcast(10, ShowReportsInGame.Singleton.Config.ReportCharacterLimitResponse);
            }

            if (ShowReportsInGame.Singleton.Config.EnableHints || ShowReportsInGame.Singleton.Config.EnableAdminChat)
            {
                foreach (var player in Player.List)
                {
                    if (!player.RemoteAdminAccess)
                        continue;

                    if (ShowReportsInGame.Singleton.Config.EnableHints)
                    {
                        player.ShowHint(string.Concat(localReportHint), duration: ShowReportsInGame.Singleton.Config.ReportHintDuration);
                        player.SendConsoleMessage(message: "[ShowReportsInGame Plugin]\n" + localReportConsole, color: "yellow");
                    }

                    if (ShowReportsInGame.Singleton.Config.EnableAdminChat)
                    {
                        player.Broadcast(ShowReportsInGame.Singleton.Config.AdminChatReportDuration, localReportAdminChat, Broadcast.BroadcastFlags.AdminChat);
                    }
                }
            }
        }

        public void CheaterReport(ReportingCheaterEventArgs ev)
        {
            if (ev.Player.UserId == ev.Target.UserId)
                ev.IsAllowed = false;

            string cheatReportHint = CheatReportHintString(ev);
            string cheatReportConsole = CheatReportConsoleString(ev);
            string cheatReportAdminChat = CheatReportAdminChatString(ev);

            if (ShowReportsInGame.Singleton.Config.ReportCharacterLimit != 0 && ev.Reason.Length > ShowReportsInGame.Singleton.Config.ReportCharacterLimit)
            {
                ev.IsAllowed = false;
                ev.Player.Broadcast(10, ShowReportsInGame.Singleton.Config.ReportCharacterLimitResponse);
            }

            if (ShowReportsInGame.Singleton.Config.EnableHints || ShowReportsInGame.Singleton.Config.EnableAdminChat)
            {
                foreach (var player in Player.List)
                {
                    if (!player.RemoteAdminAccess)
                        continue;

                    if (ShowReportsInGame.Singleton.Config.EnableHints)
                    {
                        player.ShowHint(string.Concat(cheatReportHint), duration: ShowReportsInGame.Singleton.Config.ReportHintDuration);
                        player.SendConsoleMessage(message: "[ShowReportsInGame Plugin]\n" + cheatReportConsole, color: "yellow");
                    }

                    if (ShowReportsInGame.Singleton.Config.EnableAdminChat)
                    {
                        player.Broadcast(ShowReportsInGame.Singleton.Config.AdminChatReportDuration, cheatReportAdminChat, Broadcast.BroadcastFlags.AdminChat);
                    }
                }
            }
        }

        //Hint string builders
        private string LocalReportHintString(LocalReportingEventArgs LocalReporting)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(ShowReportsInGame.Singleton.Config.LocalReportHintMsg)
              .Replace("%IssuerUserId%", LocalReporting.Player.UserId)
              .Replace("%IssuerGameId%", LocalReporting.Player.Id.ToString())
              .Replace("%IssuerNickname%", LocalReporting.Player.Nickname)
              .Replace("%IssuerRole%", LocalReporting.Player.Role.Type.ToString())
              .Replace("%TargetUserId%", LocalReporting.Target.UserId)
              .Replace("%TargetGameId%", LocalReporting.Target.Id.ToString())
              .Replace("%TargetNickname%", LocalReporting.Target.Nickname)
              .Replace("%TargetRole%", LocalReporting.Target.Role.Type.ToString())
              .Replace("%ReportReason%", LocalReporting.Reason)
              .Replace(@"\n", Environment.NewLine);
            return sb.ToString();
        }

        private string CheatReportHintString(ReportingCheaterEventArgs CheaterReporting)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(ShowReportsInGame.Singleton.Config.CheatReportHintMsg)
              .Replace("%IssuerUserId%", CheaterReporting.Player.UserId)
              .Replace("%IssuerGameId%", CheaterReporting.Player.Id.ToString())
              .Replace("%IssuerNickname%", CheaterReporting.Player.Nickname)
              .Replace("%IssuerRole%", CheaterReporting.Player.Role.Type.ToString())
              .Replace("%TargetUserId%", CheaterReporting.Target.UserId)
              .Replace("%TargetGameId%", CheaterReporting.Target.Id.ToString())
              .Replace("%TargetNickname%", CheaterReporting.Target.Nickname)
              .Replace("%TargetRole%", CheaterReporting.Target.Role.Type.ToString())
              .Replace("%ReportReason%", CheaterReporting.Reason)
              .Replace(@"\n", Environment.NewLine);
            return sb.ToString();
        }

        //Console string builders
        private string LocalReportConsoleString(LocalReportingEventArgs LocalReporting)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(ShowReportsInGame.Singleton.Config.LocalReportConsoleMsg)
            .Replace("%IssuerUserId%", LocalReporting.Player.UserId)
              .Replace("%IssuerGameId%", LocalReporting.Player.Id.ToString())
              .Replace("%IssuerNickname%", LocalReporting.Player.Nickname)
              .Replace("%IssuerRole%", LocalReporting.Player.Role.Type.ToString())
              .Replace("%TargetUserId%", LocalReporting.Target.UserId)
              .Replace("%TargetGameId%", LocalReporting.Target.Id.ToString())
              .Replace("%TargetNickname%", LocalReporting.Target.Nickname)
              .Replace("%TargetRole%", LocalReporting.Target.Role.Type.ToString())
              .Replace("%ReportReason%", LocalReporting.Reason)
              .Replace(@"\n", Environment.NewLine);
            return sb.ToString();
        }

        private string CheatReportConsoleString(ReportingCheaterEventArgs CheaterReporting)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(ShowReportsInGame.Singleton.Config.CheatReportConsoleMsg)
              .Replace("%IssuerUserId%", CheaterReporting.Player.UserId)
              .Replace("%IssuerGameId%", CheaterReporting.Player.Id.ToString())
              .Replace("%IssuerNickname%", CheaterReporting.Player.Nickname)
              .Replace("%IssuerRole%", CheaterReporting.Player.Role.Type.ToString())
              .Replace("%TargetUserId%", CheaterReporting.Target.UserId)
              .Replace("%TargetGameId%", CheaterReporting.Target.Id.ToString())
              .Replace("%TargetNickname%", CheaterReporting.Target.Nickname)
              .Replace("%TargetRole%", CheaterReporting.Target.Role.Type.ToString())
              .Replace("%ReportReason%", CheaterReporting.Reason)
              .Replace(@"\n", Environment.NewLine);
            return sb.ToString();
        }

        //AdminChat string builders
        private string LocalReportAdminChatString(LocalReportingEventArgs LocalReporting)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(ShowReportsInGame.Singleton.Config.LocalReportAdminChatMsg)
              .Replace("%IssuerUserId%", LocalReporting.Player.UserId)
              .Replace("%IssuerGameId%", LocalReporting.Player.Id.ToString())
              .Replace("%IssuerNickname%", LocalReporting.Player.Nickname)
              .Replace("%IssuerRole%", LocalReporting.Player.Role.Type.ToString())
              .Replace("%TargetUserId%", LocalReporting.Target.UserId)
              .Replace("%TargetGameId%", LocalReporting.Target.Id.ToString())
              .Replace("%TargetNickname%", LocalReporting.Target.Nickname)
              .Replace("%TargetRole%", LocalReporting.Target.Role.Type.ToString())
              .Replace("%ReportReason%", LocalReporting.Reason)
              .Replace(@"\n", Environment.NewLine);
            return sb.ToString();
        }

        private string CheatReportAdminChatString(ReportingCheaterEventArgs CheaterReporting)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(ShowReportsInGame.Singleton.Config.CheatReportAdminChatMsg)
              .Replace("%IssuerUserId%", CheaterReporting.Player.UserId)
              .Replace("%IssuerGameId%", CheaterReporting.Player.Id.ToString())
              .Replace("%IssuerNickname%", CheaterReporting.Player.Nickname)
              .Replace("%IssuerRole%", CheaterReporting.Player.Role.Type.ToString())
              .Replace("%TargetUserId%", CheaterReporting.Target.UserId)
              .Replace("%TargetGameId%", CheaterReporting.Target.Id.ToString())
              .Replace("%TargetNickname%", CheaterReporting.Target.Nickname)
              .Replace("%TargetRole%", CheaterReporting.Target.Role.Type.ToString())
              .Replace("%ReportReason%", CheaterReporting.Reason)
              .Replace(@"\n", Environment.NewLine);
            return sb.ToString();
        }
    }
}