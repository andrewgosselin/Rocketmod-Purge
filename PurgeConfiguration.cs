using Rocket.API;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Azurexx.Purge
{
    public class PurgeConfiguration : IRocketPluginConfiguration
    {
        public string purgeStartMessage = "";
        public string purgeEndMessage = "";

        public void LoadDefaults()
        {
            purgeStartMessage = "The purge has begun!";
            purgeEndMessage = "The purge has ended!";
        }
    }
}
