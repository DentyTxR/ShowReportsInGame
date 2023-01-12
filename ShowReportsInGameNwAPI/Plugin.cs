using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ShowReportsInGameNwAPI
{
    public class ShowReportsInGame
    {
        public const string PluginName = "ShowReportsInGame";
        public const string PluginVersion = "2.2.4";
        public const string PluginDesc = "Simple plugin that lets all RA players be notified about reports in-game";

        public static ShowReportsInGame Singleton;
        public EventHandler EventHandler;

        [PluginConfig] public Config Config;

        [PluginEntryPoint(PluginName, PluginVersion, PluginDesc, "DentyTxR#0524")]
        public void LoadPlugin()
        {
            Log.Debug("loaded");
            Singleton = this;
            EventManager.RegisterEvents<EventHandler>(this);
        }


        [PluginUnload()]
        public void UnloadPlugin()
        {
            Log.Debug("unload");
            Config = null;
            EventHandler = null;
        }
    }
}
