using Rocket.API;
using Rocket.Core;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Enumerations;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace Azurexx.Purge
{
    public class Purge : RocketPlugin<PurgeConfiguration>
    {
        public bool purgeHappening = false;

        protected override void Load()
        {
            Logger.Log("[Azurexx] Purge :: plugin initializing...");

            LightingManager.onMoonUpdated += onMoonUpdate;
            LightingManager.onMoonUpdated_ModHook += onMoonUpdate;

            Logger.Log("[Azurexx] Purge :: plugin started!");
        }

        protected override void Unload()
        {
            Logger.Log("[Azurexx] Purge :: plugin unloaded!"); 
        }

        private void onMoonUpdate(bool fullMoon) {

            if (LightingManager.isFullMoon)
            {
                purgeHappening = true;
                UnturnedChat.Say(Configuration.Instance.purgeStartMessage);
            }
            else
            {
                if (purgeHappening)
                {
                    purgeHappening = false;
                    UnturnedChat.Say(Configuration.Instance.purgeEndMessage);
                }
            }
        }
    }
}