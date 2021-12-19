using System;
using Exiled.Events.EventArgs;
using Exiled.API.Features;
using Player = Exiled.API.Features.Player;

namespace ShowReportsInGame
{
    public class EventHandler
    {
        public void LocalReport(LocalReportingEventArgs ev)
        {
            string SelfreportHintOne = NormalSelfreportStringOne(ev);
            string SelfreportHintTwo = NormalSelfreportStringTwo(ev);
            string SelfreportHintThree = NormalSelfreportStringThree(ev);

            string ReportHintOne = NormalreportStringOne(ev);
            string ReportHintTwo = NormalreportStringTwo(ev);
            string ReportHintThree = NormalreportStringThree(ev);


            var ReportTimeStamp = DateTime.Now.ToString("HH:mm:sstt MM/dd/yyyy");

            //If someone reports themself
            if (ev.Target.UserId == ev.Issuer.UserId)
            {
                if (ShowReportsInGame.Singleton.Config.NormalSelfReportBroadcastEnabled == true)
                {
                    ev.Issuer.Broadcast(ShowReportsInGame.Singleton.Config.NormalSelfReportBroadcastDuration, ShowReportsInGame.Singleton.Config.NormalSelfReportBroadcast);
                    Log.Debug($"Sending normal selfreport broadcast to {ev.Target}", ShowReportsInGame.Singleton.Config.EnableDebug);
                }

                //Sends hint and console message to all players with RA access about selfreport moment
                foreach (var StaffMember in Player.List)
                {
                    if (StaffMember.ReferenceHub.serverRoles.RemoteAdmin)
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
                            SelfreportHintOne,
                            Environment.NewLine,
                            SelfreportHintTwo,
                            Environment.NewLine,
                            SelfreportHintThree), duration: ShowReportsInGame.Singleton.Config.NormalSelfReportHintDuration);

                        //Sends console message about report
                        StaffMember.SendConsoleMessage(
                           message: $"[ShowReportsInGame] Incoming Report...\n\n" +
                           $"<size=23><color=red>|||</color>[<color=red>NOTE: THIS IS A SELF-REPORT</color>]<color=red>|||</color></size>\n" +
                           $"<size=23>[<color=yellow>Player Report</color>]</size>\n" +
                           $"<size=23><color=orange>Reporter</color>: <color=red>{ev.Issuer.Nickname}</color></size>\n" +
                           $"<size=18>  - GameID: {ev.Issuer.Id}</size>\n" +
                           $"<size=18>  - UserID: {ev.Issuer.UserId}</size>\n" +
                           $"<size=23><color=orange>Reported</color>: <color=red>{ev.Target.Nickname}</color></size>\n" +
                           $"<size=18>  - GameID: {ev.Target.Id}</size>\n" +
                           $"<size=18>  - UserID: {ev.Target.UserId}</size>\n" +
                           $"<size=23><color=orange>Reason</color>: <color=red>{ev.Reason} </color></size>\n" +
                           $"<size=23><color=orange>Timestamp</color>: <color=red>{ReportTimeStamp} </color></size>", color: "yellow");
                    }
                }
            }

            if (ev.Target.UserId != ev.Issuer.UserId)
            {
                //Sends hint and console message to all RA members about report
                foreach (var StaffMember in Player.List)
                {
                    if (StaffMember.ReferenceHub.serverRoles.RemoteAdmin)
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
                            ReportHintOne,
                            Environment.NewLine,
                            ReportHintTwo,
                            Environment.NewLine,
                            ReportHintThree), duration: ShowReportsInGame.Singleton.Config.NormalReportHintDuration);

                        //Sends console message about report
                        StaffMember.SendConsoleMessage(
                           message: $"[ShowReportsInGame] Incoming Report...\n\n" +
                           $"<size=23>[<color=yellow>Normal Player Report</color>]</size>\n" +
                           $"<size=23><color=orange>Reporter</color>: <color=red>{ev.Issuer.Nickname}</color></size>\n" +
                           $"<size=18>  - GameID: {ev.Issuer.Id}</size>\n" +
                           $"<size=18>  - UserID: {ev.Issuer.UserId}</size>\n" +
                           $"<size=23><color=orange>Reported</color>: <color=red>{ev.Target.Nickname}</color></size>\n" +
                           $"<size=18>  - GameID: {ev.Target.Id}</size>\n" +
                           $"<size=18>  - UserID: {ev.Target.UserId}</size>\n" +
                           $"<size=23><color=orange>Reason</color>: <color=red>{ev.Reason} </color></size>\n" +
                           $"<size=23><color=orange>Timestamp</color>: <color=red>{ReportTimeStamp} </color></size>\n\n", color: "yellow");
                    }
                }
            }
        }

        public void CheaterReport(ReportingCheaterEventArgs ev)
        {
            string SelfreportHintOne = CheaterSelfreportStringOne(ev);
            string SelfreportHintTwo = CheaterSelfreportStringTwo(ev);
            string SelfreportHintThree = CheaterSelfreportStringThree(ev);

            string ReportHintOne = CheaterreportStringOne(ev);
            string ReportHintTwo = CheaterreportStringTwo(ev);
            string ReportHintThree = CheaterreportStringThree(ev);


            var ReportTimeStamp = DateTime.Now.ToString("HH:mm:sstt MM/dd/yyyy");

            //If someone reports themself
            if (ev.Target.UserId == ev.Issuer.UserId)
            {
                if (ShowReportsInGame.Singleton.Config.CheaterSelfReportBroadcastEnabled == true)
                {
                    ev.Issuer.Broadcast(ShowReportsInGame.Singleton.Config.CheaterSelfReportBroadcastDuration, ShowReportsInGame.Singleton.Config.CheaterSelfReportBroadcast);
                    Log.Debug($"Sending normal selfreport broadcast to {ev.Target}", ShowReportsInGame.Singleton.Config.EnableDebug);
                }

                //Sends hint and console message to all players with RA access about cheater selfreport moment
                foreach (var StaffMember in Player.List)
                {
                    if (StaffMember.ReferenceHub.serverRoles.RemoteAdmin)
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
                            SelfreportHintOne,
                            Environment.NewLine,
                            SelfreportHintTwo,
                            Environment.NewLine,
                            SelfreportHintThree), duration: ShowReportsInGame.Singleton.Config.CheaterSelfReportHintDuration);

                        //Sends console message about report
                        StaffMember.SendConsoleMessage(
                           message: $"[ShowReportsInGame] Incoming Report...\n\n" +
                           $"<size=23><color=red>|||</color>[<color=red>WARNING: THIS IS A CHEATER REPORT</color>]<color=red>|||</color></size>\n" +
                           $"<size=23><color=red>|||</color>[<color=red>NOTE: THIS IS A SELF-REPORT</color>]<color=red>|||</color></size>\n" +
                           $"<size=23>[<color=yellow>Cheater Report</color>]</size>\n" +
                           $"<size=23><color=orange>Reporter</color>: <color=red>{ev.Issuer.Nickname}</color></size>\n" +
                           $"<size=18>  - GameID: {ev.Issuer.Id}</size>\n" +
                           $"<size=18>  - UserID: {ev.Issuer.UserId}</size>\n" +
                           $"<size=23><color=orange>Reported</color>: <color=red>{ev.Target.Nickname}</color></size>\n" +
                           $"<size=18>  - GameID: {ev.Target.Id}</size>\n" +
                           $"<size=18>  - UserID: {ev.Target.UserId}</size>\n" +
                           $"<size=23><color=orange>Reason</color>: <color=red>{ev.Reason} </color></size>\n" +
                           $"<size=23><color=orange>Timestamp</color>: <color=red>{ReportTimeStamp} </color></size>", color: "yellow");
                    }
                }
            }

            if (ev.Target.UserId != ev.Issuer.UserId)
            {
                //Sends hint and console message to all players with RA access about cheater report
                foreach (var StaffMember in Player.List)
                {
                    if (StaffMember.ReferenceHub.serverRoles.RemoteAdmin)
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
                            ReportHintOne,
                            Environment.NewLine,
                            ReportHintTwo,
                            Environment.NewLine,
                            ReportHintThree), duration: ShowReportsInGame.Singleton.Config.CheaterReportHintDuration);

                        //Sends console message about report
                        StaffMember.SendConsoleMessage(
                           message: $"[ShowReportsInGame] Incoming Report...\n\n" +
                           $"<size=23><color=red>|||</color>[<color=red>WARNING: THIS IS A CHEATER REPORT</color>]<color=red>|||</color></size>\n" +
                           $"<size=23>[<color=yellow>Cheater Report</color>]</size>\n" +
                           $"<size=23><color=orange>Reporter</color>: <color=red>{ev.Issuer.Nickname}</color></size>\n" +
                           $"<size=18>  - GameID: {ev.Issuer.Id}</size>\n" +
                           $"<size=18>  - UserID: {ev.Issuer.UserId}</size>\n" +
                           $"<size=23><color=orange>Reported</color>: <color=red>{ev.Target.Nickname}</color></size>\n" +
                           $"<size=18>  - GameID: {ev.Target.Id}</size>\n" +
                           $"<size=18>  - UserID: {ev.Target.UserId}</size>\n" +
                           $"<size=23><color=orange>Reason</color>: <color=red>{ev.Reason} </color></size>\n" +
                           $"<size=23><color=orange>Timestamp</color>: <color=red>{ReportTimeStamp} </color></size>", color: "yellow");
                    }
                }
            }
        }


        //Code orginally from CommonUtils plugin since its really helpful method for me
        private string NormalSelfreportStringOne(LocalReportingEventArgs LocalReporting)
        {
            return ShowReportsInGame.Singleton.Config.NormalSelfreportStringOne.Replace("%IssuerUserId%", LocalReporting.Issuer.UserId).Replace("%IssuerGameId%", LocalReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", LocalReporting.Issuer.Nickname).Replace("%IssuerRole%", LocalReporting.Issuer.Role.ToString()).Replace("%TargetUserId%", LocalReporting.Target.UserId).Replace("%TargetGameId%", LocalReporting.Target.Id.ToString()).Replace("%TargetNickname%", LocalReporting.Target.Nickname).Replace("%TargetRole%", LocalReporting.Target.Role.ToString()).Replace("%ReportReason%", LocalReporting.Reason);
        }
        private string NormalSelfreportStringTwo(LocalReportingEventArgs LocalReporting)
        {
            return ShowReportsInGame.Singleton.Config.NormalSelfreportStringTwo.Replace("%IssuerUserId%", LocalReporting.Issuer.UserId).Replace("%IssuerGameId%", LocalReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", LocalReporting.Issuer.Nickname).Replace("%IssuerRole%", LocalReporting.Issuer.Role.ToString()).Replace("%TargetUserId%", LocalReporting.Target.UserId).Replace("%TargetGameId%", LocalReporting.Target.Id.ToString()).Replace("%TargetNickname%", LocalReporting.Target.Nickname).Replace("%TargetRole%", LocalReporting.Target.Role.ToString()).Replace("%ReportReason%", LocalReporting.Reason);
        }
        private string NormalSelfreportStringThree(LocalReportingEventArgs LocalReporting)
        {
            return ShowReportsInGame.Singleton.Config.NormalSelfreportStringThree.Replace("%IssuerUserId%", LocalReporting.Issuer.UserId).Replace("%IssuerGameId%", LocalReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", LocalReporting.Issuer.Nickname).Replace("%IssuerRole%", LocalReporting.Issuer.Role.ToString()).Replace("%TargetUserId%", LocalReporting.Target.UserId).Replace("%TargetGameId%", LocalReporting.Target.Id.ToString()).Replace("%TargetNickname%", LocalReporting.Target.Nickname).Replace("%TargetRole%", LocalReporting.Target.Role.ToString()).Replace("%ReportReason%", LocalReporting.Reason);
        }

        private string NormalreportStringOne(LocalReportingEventArgs LocalReporting)
        {
            return ShowReportsInGame.Singleton.Config.NormalreportStringOne.Replace("%IssuerUserId%", LocalReporting.Issuer.UserId).Replace("%IssuerGameId%", LocalReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", LocalReporting.Issuer.Nickname).Replace("%IssuerRole%", LocalReporting.Issuer.Role.ToString()).Replace("%TargetUserId%", LocalReporting.Target.UserId).Replace("%TargetGameId%", LocalReporting.Target.Id.ToString()).Replace("%TargetNickname%", LocalReporting.Target.Nickname).Replace("%TargetRole%", LocalReporting.Target.Role.ToString()).Replace("%ReportReason%", LocalReporting.Reason);
        }
        private string NormalreportStringTwo(LocalReportingEventArgs LocalReporting)
        {
            return ShowReportsInGame.Singleton.Config.NormalreportStringTwo.Replace("%IssuerUserId%", LocalReporting.Issuer.UserId).Replace("%IssuerGameId%", LocalReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", LocalReporting.Issuer.Nickname).Replace("%IssuerRole%", LocalReporting.Issuer.Role.ToString()).Replace("%TargetUserId%", LocalReporting.Target.UserId).Replace("%TargetGameId%", LocalReporting.Target.Id.ToString()).Replace("%TargetNickname%", LocalReporting.Target.Nickname).Replace("%TargetRole%", LocalReporting.Target.Role.ToString()).Replace("%ReportReason%", LocalReporting.Reason);
        }
        private string NormalreportStringThree(LocalReportingEventArgs LocalReporting)
        {
            return ShowReportsInGame.Singleton.Config.NormalreportStringThree.Replace("%IssuerUserId%", LocalReporting.Issuer.UserId).Replace("%IssuerGameId%", LocalReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", LocalReporting.Issuer.Nickname).Replace("%IssuerRole%", LocalReporting.Issuer.Role.ToString()).Replace("%TargetUserId%", LocalReporting.Target.UserId).Replace("%TargetGameId%", LocalReporting.Target.Id.ToString()).Replace("%TargetNickname%", LocalReporting.Target.Nickname).Replace("%TargetRole%", LocalReporting.Target.Role.ToString()).Replace("%ReportReason%", LocalReporting.Reason);
        }

        private string CheaterSelfreportStringOne(ReportingCheaterEventArgs CheaterReporting)
        {
            return ShowReportsInGame.Singleton.Config.CheaterSelfreportStringOne.Replace("%IssuerUserId%", CheaterReporting.Issuer.UserId).Replace("%IssuerGameId%", CheaterReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", CheaterReporting.Issuer.Nickname).Replace("%IssuerRole%", CheaterReporting.Issuer.Role.ToString()).Replace("%TargetUserId%", CheaterReporting.Target.UserId).Replace("%TargetGameId%", CheaterReporting.Target.Id.ToString()).Replace("%TargetNickname%", CheaterReporting.Target.Nickname).Replace("%TargetRole%", CheaterReporting.Target.Role.ToString()).Replace("%ReportReason%", CheaterReporting.Reason);
        }
        private string CheaterSelfreportStringTwo(ReportingCheaterEventArgs CheaterReporting)
        {
            return ShowReportsInGame.Singleton.Config.CheaterSelfreportStringTwo.Replace("%IssuerUserId%", CheaterReporting.Issuer.UserId).Replace("%IssuerGameId%", CheaterReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", CheaterReporting.Issuer.Nickname).Replace("%IssuerRole%", CheaterReporting.Issuer.Role.ToString()).Replace("%TargetUserId%", CheaterReporting.Target.UserId).Replace("%TargetGameId%", CheaterReporting.Target.Id.ToString()).Replace("%TargetNickname%", CheaterReporting.Target.Nickname).Replace("%TargetRole%", CheaterReporting.Target.Role.ToString()).Replace("%ReportReason%", CheaterReporting.Reason);
        }
        private string CheaterSelfreportStringThree(ReportingCheaterEventArgs CheaterReporting)
        {
            return ShowReportsInGame.Singleton.Config.CheaterSelfreportStringThree.Replace("%IssuerUserId%", CheaterReporting.Issuer.UserId).Replace("%IssuerGameId%", CheaterReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", CheaterReporting.Issuer.Nickname).Replace("%IssuerRole%", CheaterReporting.Issuer.Role.ToString()).Replace("%TargetUserId%", CheaterReporting.Target.UserId).Replace("%TargetGameId%", CheaterReporting.Target.Id.ToString()).Replace("%TargetNickname%", CheaterReporting.Target.Nickname).Replace("%TargetRole%", CheaterReporting.Target.Role.ToString()).Replace("%ReportReason%", CheaterReporting.Reason);
        }

        private string CheaterreportStringOne(ReportingCheaterEventArgs CheaterReporting)
        {
            return ShowReportsInGame.Singleton.Config.CheaterreportStringOne.Replace("%IssuerUserId%", CheaterReporting.Issuer.UserId).Replace("%IssuerGameId%", CheaterReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", CheaterReporting.Issuer.Nickname).Replace("%IssuerRole%", CheaterReporting.Issuer.Role.ToString()).Replace("%TargetUserId%", CheaterReporting.Target.UserId).Replace("%TargetGameId%", CheaterReporting.Target.Id.ToString()).Replace("%TargetNickname%", CheaterReporting.Target.Nickname).Replace("%TargetRole%", CheaterReporting.Target.Role.ToString()).Replace("%ReportReason%", CheaterReporting.Reason);
        }
        private string CheaterreportStringTwo(ReportingCheaterEventArgs CheaterReporting)
        {
            return ShowReportsInGame.Singleton.Config.CheaterreportStringTwo.Replace("%IssuerUserId%", CheaterReporting.Issuer.UserId).Replace("%IssuerGameId%", CheaterReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", CheaterReporting.Issuer.Nickname).Replace("%IssuerRole%", CheaterReporting.Issuer.Role.ToString()).Replace("%TargetUserId%", CheaterReporting.Target.UserId).Replace("%TargetGameId%", CheaterReporting.Target.Id.ToString()).Replace("%TargetNickname%", CheaterReporting.Target.Nickname).Replace("%TargetRole%", CheaterReporting.Target.Role.ToString()).Replace("%ReportReason%", CheaterReporting.Reason);
        }
        private string CheaterreportStringThree(ReportingCheaterEventArgs CheaterReporting)
        {
            return ShowReportsInGame.Singleton.Config.CheaterreportStringThree.Replace("%IssuerUserId%", CheaterReporting.Issuer.UserId).Replace("%IssuerGameId%", CheaterReporting.Issuer.Id.ToString()).Replace("%IssuerNickname%", CheaterReporting.Issuer.Nickname).Replace("%IssuerRole%", CheaterReporting.Issuer.Role.ToString()).Replace("%TargetUserId%", CheaterReporting.Target.UserId).Replace("%TargetGameId%", CheaterReporting.Target.Id.ToString()).Replace("%TargetNickname%", CheaterReporting.Target.Nickname).Replace("%TargetRole%", CheaterReporting.Target.Role.ToString()).Replace("%ReportReason%", CheaterReporting.Reason);
        }
    }
}