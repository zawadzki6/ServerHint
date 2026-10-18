using Exiled.API.Features;

namespace ServerHint;

class Parser {
    public static string Parse(string str) {
	str = str.Replace("%tps%", Plugin.Instance!.Config.averageTps ? Server.SmoothTps.ToString() : Convert.ToInt32(Server.Tps).ToString());
	str = str.Replace("%players%", Server.PlayerConnectedCount.ToString());
	str = str.Replace("%maxplayers%", Server.MaxPlayerCount.ToString());
	str = str.Replace("%friendlyfire%", (Server.FriendlyFire ? Plugin.Instance!.Config.FriendlyFireOn : Plugin.Instance!.Config.FriendlyFireOff));
	str = str.Replace("%version%", Server.Version);

	// this will show wrong if the round is longer than an hour but idc it wont happen
	string min, sec, total;
	min = Round.ElapsedTime.Minutes.ToString();
	sec = Round.ElapsedTime.Seconds.ToString();
	if (min.Length == 1)
	    min = '0' + min;
	if (sec.Length == 1)
	    sec = '0' + sec;

	total = min + ':' + sec;
	str = str.Replace("%roundtime%", total);

	string tip = null!;
        byte retry = 0;
	Plugin.Instance!.Config.tips.TryGetRandomItem(out tip);

        while (retry < 3 && tip == null) {
            retry++;
            Plugin.Instance!.Config.tips.TryGetRandomItem(out tip);
        }
        Log.Debug($"got tip: \"{tip}\"");

        if (tip != null)
	    str = str.Replace("%tip%", tip);
        else
            str = str.Replace("%tip%", Plugin.Instance!.Config.placeholderTip);

	return str;
    }
}
