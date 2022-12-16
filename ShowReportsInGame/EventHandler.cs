using System;
using Exiled.API.Features;
using Player = Exiled.API.Features.Player;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;

namespace ShowReportsInGame
{
    public class EventHandler
    {
        public void LocalReport(LocalReportingEventArgs ev)
        {
            string normalSelfReportHint = NormalSelfReportHintString(ev);
            string normalReportHint = NormalReportHintString(ev);
            string normalSelfReportConsole = NormalSelfReportConsoleString(ev);
            string normalReportConsole = NormalReportConsoleString(ev);

            //If the reporter reports themself
            if (ev.Target.UserId == ev.Target.UserId)
            {
                if (ShowReportsInGame.Singleton.Config.SelfReportBroadcastEnabled)
                {
                    ev.Target.Broadcast(ShowReportsInGame.Singleton.Config.SelfReportBroadcastDuration, ShowReportsInGame.Singleton.Config.SelfReportBroadcast);
                    Log.Debug($"Sending selfreport msg to {ev.Target.Nickname}");
                }

                //Sends a hint message to all players in the server with RA access
                foreach (var player in Player.List)
                {
                    if (player.RemoteAdminAccess)
                    {
                        player.ShowHint(string.Concat(normalSelfReportHint), duration: ShowReportsInGame.Singleton.Config.ReportHintDuration);

                        //Sends console message to all RA access players
                        player.SendConsoleMessage(
                           message: "[ShowReportsInGame Plugin]" + normalSelfReportConsole, color: "yellow");
                    }
                }
            }


            if (ev.Player.UserId != ev.Target.UserId)
            {
                //Sends a hint message to all players in the server with RA access
                foreach (var player in Player.List)
                {
                    if (player.RemoteAdminAccess)
                    {
                        player.ShowHint(string.Concat(normalReportHint), duration: ShowReportsInGame.Singleton.Config.ReportHintDuration);

                        //Sends console message to all RA access players
                        player.SendConsoleMessage(
                           message: "[ShowReportsInGame Plugin]" + normalReportConsole, color: "yellow");
                    }
                }
            }
        }

        public void CheaterReport(ReportingCheaterEventArgs ev)
        {
            string cheaterSelfReportHint = CheaterSelfReportHintString(ev);
            string cheaterNormalReportHint = CheaterReportHintString(ev);
            string cheaterSelfReportConsole = CheaterSelfReportConsoleString(ev);
            string cheaterReportConsole = CheaterReportConsoleString(ev);

            //If someone reports themself
            if (ev.Target.UserId == ev.Player.UserId)
            {
                if (ShowReportsInGame.Singleton.Config.SelfReportBroadcastEnabled)
                {
                    ev.Player.Broadcast(ShowReportsInGame.Singleton.Config.SelfReportBroadcastDuration, ShowReportsInGame.Singleton.Config.SelfReportBroadcast);
                }

                //Sends hint and console message to all players with RA access about cheater selfreport moment
                foreach (var player in Player.List)
                {
                    if (player.RemoteAdminAccess)
                    {
                        player.ShowHint(string.Concat(cheaterSelfReportHint), duration: ShowReportsInGame.Singleton.Config.ReportHintDuration);

                        //Sends console message about report
                        player.SendConsoleMessage(
                           message: "[ShowReportsInGame Plugin]" + cheaterSelfReportConsole, color: "yellow");
                    }
                }
            }

            else if (ev.Target.UserId != ev.Player.UserId)
            {
                //Sends hint and console message to all players with RA access about cheater report
                foreach (var player in Player.List)
                {
                    if (player.RemoteAdminAccess)
                    {
                        player.ShowHint(string.Concat(cheaterNormalReportHint), duration: ShowReportsInGame.Singleton.Config.ReportHintDuration);

                        //Sends console message about report
                        player.SendConsoleMessage(
                           message: "[ShowReportsInGame Plugin]" + cheaterReportConsole, color: "yellow");
                    }
                }
            }
        }

        //Hint string builders
        private string NormalSelfReportHintString(LocalReportingEventArgs LocalReporting) { return ShowReportsInGame.Singleton.Config.NormalSelfreportStringOne.Replace("%IssuerUserId%", LocalReporting.Player.UserId).Replace("%IssuerGameId%", LocalReporting.Player.Id.ToString()).Replace("%IssuerNickname%", LocalReporting.Player.Nickname).Replace("%IssuerRole%", LocalReporting.Player.Role.Type.ToString()).Replace("%TargetUserId%", LocalReporting.Target.UserId).Replace("%TargetGameId%", LocalReporting.Target.Id.ToString()).Replace("%TargetNickname%", LocalReporting.Target.Nickname).Replace("%TargetRole%", LocalReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", LocalReporting.Reason).Replace(@"\n", Environment.NewLine); }
        private string NormalReportHintString(LocalReportingEventArgs LocalReporting) { return ShowReportsInGame.Singleton.Config.NormalreportStringOne.Replace("%IssuerUserId%", LocalReporting.Player.UserId).Replace("%IssuerGameId%", LocalReporting.Player.Id.ToString()).Replace("%IssuerNickname%", LocalReporting.Player.Nickname).Replace("%IssuerRole%", LocalReporting.Player.Role.Type.ToString()).Replace("%TargetUserId%", LocalReporting.Target.UserId).Replace("%TargetGameId%", LocalReporting.Target.Id.ToString()).Replace("%TargetNickname%", LocalReporting.Target.Nickname).Replace("%TargetRole%", LocalReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", LocalReporting.Reason).Replace(@"\n", Environment.NewLine); }
        private string CheaterSelfReportHintString(ReportingCheaterEventArgs CheaterReporting) { return ShowReportsInGame.Singleton.Config.CheaterSelfreportStringOne.Replace("%IssuerUserId%", CheaterReporting.Player.UserId).Replace("%IssuerGameId%", CheaterReporting.Player.Id.ToString()).Replace("%IssuerNickname%", CheaterReporting.Player.Nickname).Replace("%IssuerRole%", CheaterReporting.Player.Role.Type.ToString()).Replace("%TargetUserId%", CheaterReporting.Target.UserId).Replace("%TargetGameId%", CheaterReporting.Target.Id.ToString()).Replace("%TargetNickname%", CheaterReporting.Target.Nickname).Replace("%TargetRole%", CheaterReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", CheaterReporting.Reason).Replace(@"\n", Environment.NewLine); }
        private string CheaterReportHintString(ReportingCheaterEventArgs CheaterReporting) { return ShowReportsInGame.Singleton.Config.CheaterreportStringOne.Replace("%IssuerUserId%", CheaterReporting.Player.UserId).Replace("%IssuerGameId%", CheaterReporting.Player.Id.ToString()).Replace("%IssuerNickname%", CheaterReporting.Player.Nickname).Replace("%IssuerRole%", CheaterReporting.Player.Role.Type.ToString()).Replace("%TargetUserId%", CheaterReporting.Target.UserId).Replace("%TargetGameId%", CheaterReporting.Target.Id.ToString()).Replace("%TargetNickname%", CheaterReporting.Target.Nickname).Replace("%TargetRole%", CheaterReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", CheaterReporting.Reason).Replace(@"\n", Environment.NewLine); }

        //Console string builders
        private string NormalSelfReportConsoleString(LocalReportingEventArgs LocalReporting) { return ShowReportsInGame.Singleton.Config.LocalSelfreportConsoleMsg.Replace("%IssuerUserId%", LocalReporting.Player.UserId).Replace("%IssuerGameId%", LocalReporting.Player.Id.ToString()).Replace("%IssuerNickname%", LocalReporting.Player.Nickname).Replace("%IssuerRole%", LocalReporting.Player.Role.Type.ToString()).Replace("%TargetUserId%", LocalReporting.Target.UserId).Replace("%TargetGameId%", LocalReporting.Target.Id.ToString()).Replace("%TargetNickname%", LocalReporting.Target.Nickname).Replace("%TargetRole%", LocalReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", LocalReporting.Reason).Replace(@"\n", Environment.NewLine); }
        private string NormalReportConsoleString(LocalReportingEventArgs LocalReporting) { return ShowReportsInGame.Singleton.Config.LocalReportConsoleMsg.Replace("%IssuerUserId%", LocalReporting.Player.UserId).Replace("%IssuerGameId%", LocalReporting.Player.Id.ToString()).Replace("%IssuerNickname%", LocalReporting.Player.Nickname).Replace("%IssuerRole%", LocalReporting.Player.Role.Type.ToString()).Replace("%TargetUserId%", LocalReporting.Target.UserId).Replace("%TargetGameId%", LocalReporting.Target.Id.ToString()).Replace("%TargetNickname%", LocalReporting.Target.Nickname).Replace("%TargetRole%", LocalReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", LocalReporting.Reason).Replace(@"\n", Environment.NewLine); }
        private string CheaterSelfReportConsoleString(ReportingCheaterEventArgs CheaterReporting) { return ShowReportsInGame.Singleton.Config.CheaterSelfreportConsoleMsg.Replace("%IssuerUserId%", CheaterReporting.Player.UserId).Replace("%IssuerGameId%", CheaterReporting.Player.Id.ToString()).Replace("%IssuerNickname%", CheaterReporting.Player.Nickname).Replace("%IssuerRole%", CheaterReporting.Player.Role.Type.ToString()).Replace("%TargetUserId%", CheaterReporting.Target.UserId).Replace("%TargetGameId%", CheaterReporting.Target.Id.ToString()).Replace("%TargetNickname%", CheaterReporting.Target.Nickname).Replace("%TargetRole%", CheaterReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", CheaterReporting.Reason).Replace(@"\n", Environment.NewLine); }
        private string CheaterReportConsoleString(ReportingCheaterEventArgs CheaterReporting) { return ShowReportsInGame.Singleton.Config.CheaterReportConsoleMsg.Replace("%IssuerUserId%", CheaterReporting.Player.UserId).Replace("%IssuerGameId%", CheaterReporting.Player.Id.ToString()).Replace("%IssuerNickname%", CheaterReporting.Player.Nickname).Replace("%IssuerRole%", CheaterReporting.Player.Role.Type.ToString()).Replace("%TargetUserId%", CheaterReporting.Target.UserId).Replace("%TargetGameId%", CheaterReporting.Target.Id.ToString()).Replace("%TargetNickname%", CheaterReporting.Target.Nickname).Replace("%TargetRole%", CheaterReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", CheaterReporting.Reason).Replace(@"\n", Environment.NewLine); }
    }
}