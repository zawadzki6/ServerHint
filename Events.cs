using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;

namespace ServerHint;

public class Events {

    private static Config config => Plugin.Instance!.Config; 

    public static void SingleDisplay(Player player) {
	Log.Debug($"SingleDisplay for {player.Nickname}");
	player.ShowHint("");

	string deadhint = Parser.Parse(config.spectatorHint);
	string lobbyhint = Parser.Parse(config.lobbyHint);
	string normalhint = Parser.Parse(config.hint);

	string hint;
	float time;

	if (!Round.IsStarted && config.lobby) {
	    hint = lobbyhint;
	    time = config.lobbyRefreshRate;
	}
	else if (!Round.IsStarted && !config.lobby) {
	    hint = "";
	    time = 1;
	}
	else {
	    hint = normalhint;
	    time = config.refreshRate;
	}
	if (hint == "")
	    return;

	if (config.spectator) {
	    if (player.IsDead && Round.IsStarted) {
		hint = deadhint;
		time = config.spectatorRefreshRate;
	    }
	    player.ShowHint(hint, time);
	}
	else
	    player.ShowHint(hint, time);
    }

    public static void Spawned(SpawnedEventArgs ev) => SingleDisplay(ev.Player);
    public static void Verified(VerifiedEventArgs ev) => SingleDisplay(ev.Player);
}
