using System;
using Exiled.API.Features;
using ServerEvent = Exiled.Events.Handlers.Server;

namespace ShowReportsInGame
{

    public class ShowReportsInGame : Plugin<Config>
    {

        private EventHandler EventHandler;
        public static ShowReportsInGame Singleton;

        public override string Name { get; } = "ShowReportsInGame";
        public override string Author { get; } = "Denty";
        public override string Prefix { get; } = "ShowReportsInGame";
        public override Version Version { get; } = new Version(2, 0, 1);
        public override Version RequiredExiledVersion { get; } = new Version(6, 0, 0);


        public override void OnEnabled()
        {
            Singleton = this;
            EventHandler = new EventHandler();

            ServerEvent.LocalReporting += EventHandler.LocalReport;
            ServerEvent.ReportingCheater += EventHandler.CheaterReport;

            base.OnEnabled();
        }


        public override void OnDisabled()
        {
            EventHandler = null;
            base.OnDisabled();
        }
    }
}