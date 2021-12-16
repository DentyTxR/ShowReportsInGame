using System;
using Exiled.Events.EventArgs;
using Player = Exiled.API.Features.Player;

namespace ShowReportsInGame
{
    public class EventHandler
    {
        public void LocalReport(LocalReportingEventArgs ev)
        {
            var ReportTimeStamp = DateTime.Now.ToString("HH:mm:sstt MM/dd/yyyy");

            //If someone reports themself
            if (ev.Target.UserId == ev.Issuer.UserId)
            {
                ev.Issuer.Broadcast(ShowReportsInGame.Singleton.Config.NormalSelfReportMessageDuration, ShowReportsInGame.Singleton.Config.NormalSelfReportMessage);

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
                            @"<size=20><color=red>/|\</color>[<color=red>NOTE: THIS IS A SELF-REPORT</color>]<color=red>/|\</color></size>",
                            Environment.NewLine,
                            "<size=20>[<color=yellow>Player Report, Check Console (`) For Info</color>]</size>",
                            Environment.NewLine,
                            "<size=20><color=orange>Timestamp (24H)</color>: <color=red>", ReportTimeStamp, "</color></size>"), duration: ShowReportsInGame.Singleton.Config.NormalSelfReportHintDuration);

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
                            @"<size=20><color=red>/|\</color>[<color=green>NOTE: This is a normal report.</color>]<color=red>/|\</color></size>",
                            Environment.NewLine,
                            "<size=20>[<color=yellow>Player Report, Check Console (`) For Info</color>]</size>",
                            Environment.NewLine,
                            "<size=20><color=orange>Timestamp (24H)</color>: <color=red>", ReportTimeStamp, "</color></size>"), duration: ShowReportsInGame.Singleton.Config.NormalReportHintDuration);

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
            var ReportTimeStamp = DateTime.Now.ToString("HH:mm:sstt MM/dd/yyyy");

            //If someone reports themself
            if (ev.Target.UserId == ev.Issuer.UserId)
            {
                //If someone reports themself
                ev.Issuer.Broadcast(ShowReportsInGame.Singleton.Config.CheaterSelfReportMessageDuration, ShowReportsInGame.Singleton.Config.CheaterSelfReportMessage);

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
                            @"<size=20><color=red>/|\</color>[<color=red>WARNING: THIS IS A CHEATER REPORT</color>]<color=red>/|\</color></size>",
                            Environment.NewLine,
                            @"<size=20><color=red>/|\</color>[<color=red>NOTE: THIS IS A SELF-REPORT</color>]<color=red>/|\</color></size>",
                            Environment.NewLine,
                            "<size=20>[<color=yellow>Cheater Report, Check Console (`) For Info</color>]</size>",
                            Environment.NewLine,
                            "<size=20><color=orange>Timestamp (24H)</color>: <color=red>", ReportTimeStamp, "</color></size>"), duration: ShowReportsInGame.Singleton.Config.CheaterSelfReportHintDuration);

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
                            @"<size=20><color=red>/|\</color>[<color=red>WARNING: THIS IS A CHEATER REPORT</color>]<color=red>/|\</color></size>",
                            Environment.NewLine,
                            "<size=20>[<color=yellow>Cheater Report, Check Console (`) For Info</color>]</size>",
                            Environment.NewLine,
                            "<size=20><color=orange>Timestamp (24H)</color>: <color=red>", ReportTimeStamp, "</color></size>"), duration: ShowReportsInGame.Singleton.Config.CheaterReportHintDuration);

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
    }
}