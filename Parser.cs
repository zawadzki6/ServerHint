using Exiled.API.Features;

namespace ServerHint;

class Parser {
    public static string Parse(string str) {
	str = str.Replace("%tps%", Server.SmoothTps.ToString());
	str = str.Replace("%players%", Server.PlayerConnectedCount.ToString());
	str = str.Replace("%maxplayers%", Server.MaxPlayerCount.ToString());
	str = str.Replace("%friendlyfire%", (Server.FriendlyFire ? "on" : "off"));
	str = str.Replace("%roundtime%", Round.ElapsedTime.ToString());
	str = str.Replace("%version%", Server.Version);

	Log.Debug($"Parsed: {str}");
	return str;
    }
}
