using System;
using Exiled.Events.EventArgs;
using Exiled.API.Features;
using Player = Exiled.API.Features.Player;
using UnityEngine;
using Exiled.Events.Handlers;

namespace ShowReportsInGame
{
    public class EventHandler
    {
        public void LocalReport(LocalReportingEventArgs ev)
        {
            var ReportTimeStamp = DateTime.Now.ToString("HH:mm:sstt MM/dd/yyyy");

            //If the reporter reports themself
            if (ev.Target.UserId == ev.Issuer.UserId)
            {
                ev.Issuer.Broadcast(ShowReportsInGame.Singleton.Config.NormalSelfReportMessageDuration, ShowReportsInGame.Singleton.Config.NormalSelfReportMessage);

                //Sends a hint message to all players in the server with RA access
                foreach (var player in Player.List)
                {
                    if (player.RemoteAdminAccess)
                    {
                        StaffMember.ShowHint(string.Concat(
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            @"<size=20><color=red>/|\</color>[<color=red>NOTE: THIS IS A SELF-REPORT</color>]<color=red>/|\</color></size>",
                            Environment.NewLine,
                            "<size=20>[<color=yellow>Player Report, Check Console (`) For Info</color>]</size>",
                            Environment.NewLine,
                            "<size=20><color=orange>Timestamp (24H)</color>: <color=red>", ReportTimeStamp, "</color></size>"), duration: ShowReportsInGame.Singleton.Config.NormalSelfReportHintDuration);

                        //Sends console message to all RA access players
                        player.SendConsoleMessage(
                           message: normalSelfReportConsole, color: "yellow");
                    }
                }
            }


            if (ev.Target.UserId != ev.Issuer.UserId)
            {
                //Sends a hint message to all players in the server with RA access
                foreach (var player in Player.List)
                {
                    if (player.RemoteAdminAccess)
                    {
                        StaffMember.ShowHint(string.Concat(
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            @"<size=20><color=red>/|\</color>[<color=green>NOTE: This is a normal report.</color>]<color=red>/|\</color></size>",
                            Environment.NewLine,
                            "<size=20>[<color=yellow>Player Report, Check Console (`) For Info</color>]</size>",
                            Environment.NewLine,
                            "<size=20><color=orange>Timestamp (24H)</color>: <color=red>", ReportTimeStamp, "</color></size>"), duration: ShowReportsInGame.Singleton.Config.NormalReportHintDuration);

                        //Sends console message to all RA access players
                        player.SendConsoleMessage(
                           message: normalReportConsole, color: "yellow");
                    }
                }
            }
        }

        public void CheaterReport(ReportingCheaterEventArgs ev)
        {
            var ReportTimeStamp = DateTime.Now.ToString("HH:mm:sstt MM/dd/yyyy");

            //If someone reports themself
            if (ev.Target.UserId == ev.Issuer.UserId)
            {
                //If someone reports themself
                ev.Issuer.Broadcast(ShowReportsInGame.Singleton.Config.CheaterSelfReportMessageDuration, ShowReportsInGame.Singleton.Config.CheaterSelfReportMessage);

                //Sends hint and console message to all players with RA access about cheater selfreport moment
                foreach (var player in Player.List)
                {
                    if (player.RemoteAdminAccess)
                    {
                        StaffMember.ShowHint(string.Concat(
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            @"<size=20><color=red>/|\</color>[<color=red>WARNING: THIS IS A CHEATER REPORT</color>]<color=red>/|\</color></size>",
                            Environment.NewLine,
                            @"<size=20><color=red>/|\</color>[<color=red>NOTE: THIS IS A SELF-REPORT</color>]<color=red>/|\</color></size>",
                            Environment.NewLine,
                            "<size=20>[<color=yellow>Cheater Report, Check Console (`) For Info</color>]</size>",
                            Environment.NewLine,
                            "<size=20><color=orange>Timestamp (24H)</color>: <color=red>", ReportTimeStamp, "</color></size>"), duration: ShowReportsInGame.Singleton.Config.CheaterSelfReportHintDuration);

                        //Sends console message about report
                        player.SendConsoleMessage(
                           message: cheaterSelfReportConsole, color: "yellow");
                    }
                }
            }

            else if (ev.Target.UserId != ev.Issuer.UserId)
            {
                //Sends hint and console message to all players with RA access about cheater report
                foreach (var player in Player.List)
                {
                    if (player.RemoteAdminAccess)
                    {
                        StaffMember.ShowHint(string.Concat(
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            @"<size=20><color=red>/|\</color>[<color=red>WARNING: THIS IS A CHEATER REPORT</color>]<color=red>/|\</color></size>",
                            Environment.NewLine,
                            "<size=20>[<color=yellow>Cheater Report, Check Console (`) For Info</color>]</size>",
                            Environment.NewLine,
                            "<size=20><color=orange>Timestamp (24H)</color>: <color=red>", ReportTimeStamp, "</color></size>"), duration: ShowReportsInGame.Singleton.Config.CheaterReportHintDuration);

                        //Sends console message about report
                        player.SendConsoleMessage(
                           message: cheaterReportConsole, color: "yellow");
                    }
                }
            }
        }


        //Code orginally from CommonUtils plugin since its really helpful method for me
        private string NormalSelfreportStringOne(LocalReportingEventArgs LocalReporting)
        {
            return ShowReportsInGame.Singleton.Config.NormalSelfreportStringOne.Replace("%IssuerUserId%", LocalReporting.Issuer.UserId).Replace("%IssuerGameId%", LocalReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", LocalReporting.Issuer.Nickname).Replace("%IssuerRole%", LocalReporting.Issuer.Role.Type.ToString()).Replace("%TargetUserId%", LocalReporting.Target.UserId).Replace("%TargetGameId%", LocalReporting.Target.Id.ToString()).Replace("%TargetNickname%", LocalReporting.Target.Nickname).Replace("%TargetRole%", LocalReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", LocalReporting.Reason);
        }
        private string NormalSelfreportStringTwo(LocalReportingEventArgs LocalReporting)
        {
            return ShowReportsInGame.Singleton.Config.NormalSelfreportStringTwo.Replace("%IssuerUserId%", LocalReporting.Issuer.UserId).Replace("%IssuerGameId%", LocalReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", LocalReporting.Issuer.Nickname).Replace("%IssuerRole%", LocalReporting.Issuer.Role.Type.ToString()).Replace("%TargetUserId%", LocalReporting.Target.UserId).Replace("%TargetGameId%", LocalReporting.Target.Id.ToString()).Replace("%TargetNickname%", LocalReporting.Target.Nickname).Replace("%TargetRole%", LocalReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", LocalReporting.Reason);
        }
        private string NormalSelfreportStringThree(LocalReportingEventArgs LocalReporting)
        {
            return ShowReportsInGame.Singleton.Config.NormalSelfreportStringThree.Replace("%IssuerUserId%", LocalReporting.Issuer.UserId).Replace("%IssuerGameId%", LocalReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", LocalReporting.Issuer.Nickname).Replace("%IssuerRole%", LocalReporting.Issuer.Role.Type.ToString()).Replace("%TargetUserId%", LocalReporting.Target.UserId).Replace("%TargetGameId%", LocalReporting.Target.Id.ToString()).Replace("%TargetNickname%", LocalReporting.Target.Nickname).Replace("%TargetRole%", LocalReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", LocalReporting.Reason);
        }

        private string NormalreportStringOne(LocalReportingEventArgs LocalReporting)
        {
            return ShowReportsInGame.Singleton.Config.NormalreportStringOne.Replace("%IssuerUserId%", LocalReporting.Issuer.UserId).Replace("%IssuerGameId%", LocalReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", LocalReporting.Issuer.Nickname).Replace("%IssuerRole%", LocalReporting.Issuer.Role.Type.ToString()).Replace("%TargetUserId%", LocalReporting.Target.UserId).Replace("%TargetGameId%", LocalReporting.Target.Id.ToString()).Replace("%TargetNickname%", LocalReporting.Target.Nickname).Replace("%TargetRole%", LocalReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", LocalReporting.Reason);
        }
        private string NormalreportStringTwo(LocalReportingEventArgs LocalReporting)
        {
            return ShowReportsInGame.Singleton.Config.NormalreportStringTwo.Replace("%IssuerUserId%", LocalReporting.Issuer.UserId).Replace("%IssuerGameId%", LocalReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", LocalReporting.Issuer.Nickname).Replace("%IssuerRole%", LocalReporting.Issuer.Role.Type.ToString()).Replace("%TargetUserId%", LocalReporting.Target.UserId).Replace("%TargetGameId%", LocalReporting.Target.Id.ToString()).Replace("%TargetNickname%", LocalReporting.Target.Nickname).Replace("%TargetRole%", LocalReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", LocalReporting.Reason);
        }
        private string NormalreportStringThree(LocalReportingEventArgs LocalReporting)
        {
            return ShowReportsInGame.Singleton.Config.NormalreportStringThree.Replace("%IssuerUserId%", LocalReporting.Issuer.UserId).Replace("%IssuerGameId%", LocalReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", LocalReporting.Issuer.Nickname).Replace("%IssuerRole%", LocalReporting.Issuer.Role.Type.ToString()).Replace("%TargetUserId%", LocalReporting.Target.UserId).Replace("%TargetGameId%", LocalReporting.Target.Id.ToString()).Replace("%TargetNickname%", LocalReporting.Target.Nickname).Replace("%TargetRole%", LocalReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", LocalReporting.Reason);
        }

        private string CheaterSelfreportStringOne(ReportingCheaterEventArgs CheaterReporting)
        {
            return ShowReportsInGame.Singleton.Config.CheaterSelfreportStringOne.Replace("%IssuerUserId%", CheaterReporting.Issuer.UserId).Replace("%IssuerGameId%", CheaterReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", CheaterReporting.Issuer.Nickname).Replace("%IssuerRole%", CheaterReporting.Issuer.Role.Type.ToString()).Replace("%TargetUserId%", CheaterReporting.Target.UserId).Replace("%TargetGameId%", CheaterReporting.Target.Id.ToString()).Replace("%TargetNickname%", CheaterReporting.Target.Nickname).Replace("%TargetRole%", CheaterReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", CheaterReporting.Reason);
        }
        private string CheaterSelfreportStringTwo(ReportingCheaterEventArgs CheaterReporting)
        {
            return ShowReportsInGame.Singleton.Config.CheaterSelfreportStringTwo.Replace("%IssuerUserId%", CheaterReporting.Issuer.UserId).Replace("%IssuerGameId%", CheaterReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", CheaterReporting.Issuer.Nickname).Replace("%IssuerRole%", CheaterReporting.Issuer.Role.Type.ToString()).Replace("%TargetUserId%", CheaterReporting.Target.UserId).Replace("%TargetGameId%", CheaterReporting.Target.Id.ToString()).Replace("%TargetNickname%", CheaterReporting.Target.Nickname).Replace("%TargetRole%", CheaterReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", CheaterReporting.Reason);
        }
        private string CheaterSelfreportStringThree(ReportingCheaterEventArgs CheaterReporting)
        {
            return ShowReportsInGame.Singleton.Config.CheaterSelfreportStringThree.Replace("%IssuerUserId%", CheaterReporting.Issuer.UserId).Replace("%IssuerGameId%", CheaterReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", CheaterReporting.Issuer.Nickname).Replace("%IssuerRole%", CheaterReporting.Issuer.Role.Type.ToString()).Replace("%TargetUserId%", CheaterReporting.Target.UserId).Replace("%TargetGameId%", CheaterReporting.Target.Id.ToString()).Replace("%TargetNickname%", CheaterReporting.Target.Nickname).Replace("%TargetRole%", CheaterReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", CheaterReporting.Reason);
        }

        private string CheaterreportStringOne(ReportingCheaterEventArgs CheaterReporting)
        {
            return ShowReportsInGame.Singleton.Config.CheaterreportStringOne.Replace("%IssuerUserId%", CheaterReporting.Issuer.UserId).Replace("%IssuerGameId%", CheaterReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", CheaterReporting.Issuer.Nickname).Replace("%IssuerRole%", CheaterReporting.Issuer.Role.Type.ToString()).Replace("%TargetUserId%", CheaterReporting.Target.UserId).Replace("%TargetGameId%", CheaterReporting.Target.Id.ToString()).Replace("%TargetNickname%", CheaterReporting.Target.Nickname).Replace("%TargetRole%", CheaterReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", CheaterReporting.Reason);
        }
        private string CheaterreportStringTwo(ReportingCheaterEventArgs CheaterReporting)
        {
            return ShowReportsInGame.Singleton.Config.CheaterreportStringTwo.Replace("%IssuerUserId%", CheaterReporting.Issuer.UserId).Replace("%IssuerGameId%", CheaterReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", CheaterReporting.Issuer.Nickname).Replace("%IssuerRole%", CheaterReporting.Issuer.Role.Type.ToString()).Replace("%TargetUserId%", CheaterReporting.Target.UserId).Replace("%TargetGameId%", CheaterReporting.Target.Id.ToString()).Replace("%TargetNickname%", CheaterReporting.Target.Nickname).Replace("%TargetRole%", CheaterReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", CheaterReporting.Reason);
        }
        private string CheaterreportStringThree(ReportingCheaterEventArgs CheaterReporting)
        {
            return ShowReportsInGame.Singleton.Config.CheaterreportStringThree.Replace("%IssuerUserId%", CheaterReporting.Issuer.UserId).Replace("%IssuerGameId%", CheaterReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", CheaterReporting.Issuer.Nickname).Replace("%IssuerRole%", CheaterReporting.Issuer.Role.Type.ToString()).Replace("%TargetUserId%", CheaterReporting.Target.UserId).Replace("%TargetGameId%", CheaterReporting.Target.Id.ToString()).Replace("%TargetNickname%", CheaterReporting.Target.Nickname).Replace("%TargetRole%", CheaterReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", CheaterReporting.Reason);
        }


        //Hint string builders
        private string NormalSelfReportHintString(LocalReportingEventArgs LocalReporting) { return ShowReportsInGame.Singleton.Config.NormalSelfreportStringOne.Replace("%IssuerUserId%", LocalReporting.Issuer.UserId).Replace("%IssuerGameId%", LocalReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", LocalReporting.Issuer.Nickname).Replace("%IssuerRole%", LocalReporting.Issuer.Role.Type.ToString()).Replace("%TargetUserId%", LocalReporting.Target.UserId).Replace("%TargetGameId%", LocalReporting.Target.Id.ToString()).Replace("%TargetNickname%", LocalReporting.Target.Nickname).Replace("%TargetRole%", LocalReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", LocalReporting.Reason).Replace(@"\n", Environment.NewLine); }
        private string NormalReportHintString(LocalReportingEventArgs LocalReporting) { return ShowReportsInGame.Singleton.Config.NormalreportStringOne.Replace("%IssuerUserId%", LocalReporting.Issuer.UserId).Replace("%IssuerGameId%", LocalReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", LocalReporting.Issuer.Nickname).Replace("%IssuerRole%", LocalReporting.Issuer.Role.Type.ToString()).Replace("%TargetUserId%", LocalReporting.Target.UserId).Replace("%TargetGameId%", LocalReporting.Target.Id.ToString()).Replace("%TargetNickname%", LocalReporting.Target.Nickname).Replace("%TargetRole%", LocalReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", LocalReporting.Reason).Replace(@"\n", Environment.NewLine); }
        private string CheaterSelfReportHintString(ReportingCheaterEventArgs CheaterReporting) { return ShowReportsInGame.Singleton.Config.CheaterSelfreportStringOne.Replace("%IssuerUserId%", CheaterReporting.Issuer.UserId).Replace("%IssuerGameId%", CheaterReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", CheaterReporting.Issuer.Nickname).Replace("%IssuerRole%", CheaterReporting.Issuer.Role.Type.ToString()).Replace("%TargetUserId%", CheaterReporting.Target.UserId).Replace("%TargetGameId%", CheaterReporting.Target.Id.ToString()).Replace("%TargetNickname%", CheaterReporting.Target.Nickname).Replace("%TargetRole%", CheaterReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", CheaterReporting.Reason).Replace(@"\n", Environment.NewLine); }
        private string CheaterReportHintString(ReportingCheaterEventArgs CheaterReporting) { return ShowReportsInGame.Singleton.Config.CheaterreportStringOne.Replace("%IssuerUserId%", CheaterReporting.Issuer.UserId).Replace("%IssuerGameId%", CheaterReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", CheaterReporting.Issuer.Nickname).Replace("%IssuerRole%", CheaterReporting.Issuer.Role.Type.ToString()).Replace("%TargetUserId%", CheaterReporting.Target.UserId).Replace("%TargetGameId%", CheaterReporting.Target.Id.ToString()).Replace("%TargetNickname%", CheaterReporting.Target.Nickname).Replace("%TargetRole%", CheaterReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", CheaterReporting.Reason).Replace(@"\n", Environment.NewLine); }

        //Console string builders
        private string NormalSelfReportConsoleString(LocalReportingEventArgs LocalReporting) { return ShowReportsInGame.Singleton.Config.LocalSelfreportConsoleMsg.Replace("%IssuerUserId%", LocalReporting.Issuer.UserId).Replace("%IssuerGameId%", LocalReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", LocalReporting.Issuer.Nickname).Replace("%IssuerRole%", LocalReporting.Issuer.Role.Type.ToString()).Replace("%TargetUserId%", LocalReporting.Target.UserId).Replace("%TargetGameId%", LocalReporting.Target.Id.ToString()).Replace("%TargetNickname%", LocalReporting.Target.Nickname).Replace("%TargetRole%", LocalReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", LocalReporting.Reason).Replace(@"\n", Environment.NewLine); }
        private string NormalReportConsoleString(LocalReportingEventArgs LocalReporting) { return ShowReportsInGame.Singleton.Config.LocalReportConsoleMsg.Replace("%IssuerUserId%", LocalReporting.Issuer.UserId).Replace("%IssuerGameId%", LocalReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", LocalReporting.Issuer.Nickname).Replace("%IssuerRole%", LocalReporting.Issuer.Role.Type.ToString()).Replace("%TargetUserId%", LocalReporting.Target.UserId).Replace("%TargetGameId%", LocalReporting.Target.Id.ToString()).Replace("%TargetNickname%", LocalReporting.Target.Nickname).Replace("%TargetRole%", LocalReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", LocalReporting.Reason).Replace(@"\n", Environment.NewLine); }
        private string CheaterSelfReportConsoleString(ReportingCheaterEventArgs CheaterReporting) { return ShowReportsInGame.Singleton.Config.CheaterSelfreportConsoleMsg.Replace("%IssuerUserId%", CheaterReporting.Issuer.UserId).Replace("%IssuerGameId%", CheaterReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", CheaterReporting.Issuer.Nickname).Replace("%IssuerRole%", CheaterReporting.Issuer.Role.Type.ToString()).Replace("%TargetUserId%", CheaterReporting.Target.UserId).Replace("%TargetGameId%", CheaterReporting.Target.Id.ToString()).Replace("%TargetNickname%", CheaterReporting.Target.Nickname).Replace("%TargetRole%", CheaterReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", CheaterReporting.Reason).Replace(@"\n", Environment.NewLine); }
        private string CheaterReportConsoleString(ReportingCheaterEventArgs CheaterReporting) { return ShowReportsInGame.Singleton.Config.CheaterReportConsoleMsg.Replace("%IssuerUserId%", CheaterReporting.Issuer.UserId).Replace("%IssuerGameId%", CheaterReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", CheaterReporting.Issuer.Nickname).Replace("%IssuerRole%", CheaterReporting.Issuer.Role.Type.ToString()).Replace("%TargetUserId%", CheaterReporting.Target.UserId).Replace("%TargetGameId%", CheaterReporting.Target.Id.ToString()).Replace("%TargetNickname%", CheaterReporting.Target.Nickname).Replace("%TargetRole%", CheaterReporting.Target.Role.Type.ToString()).Replace("%ReportReason%", CheaterReporting.Reason).Replace(@"\n", Environment.NewLine); }
    }
}