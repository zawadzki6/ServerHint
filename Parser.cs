using Exiled.API.Features;

namespace ServerHint;

class Parser {
    public static string Parse(string str) {
	str = str.Replace("%tps%", Server.SmoothTps.ToString());
	str = str.Replace("%players%", Server.PlayerConnectedCount.ToString());
	str = str.Replace("%maxplayers%", Server.MaxPlayerCount.ToString());
	str = str.Replace("%friendlyfire%", (Server.FriendlyFire ? Plugin.Instance!.Config.FriendlyFireOn : Plugin.Instance!.Config.FriendlyFireOff));
	str = str.Replace("%version%", Server.Version);

	// this will show wrong if the round is longer than an hour but idc it wont happen
	string min, sec, total;
	min = Round.ElapsedTime.Minutes.ToString();
	sec = Round.ElapsedTime.Seconds.ToString();
	total = min + ':' + sec;
	str = str.Replace("%roundtime%", total);

	string tip = "";
	Plugin.Instance!.Config.Tips.TryGetRandomItem(out tip);
	str = str.Replace("%tip%", tip);

	return str;
    }
}
