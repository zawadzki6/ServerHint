using Exiled.API.Features;
using MEC;

namespace ServerHint;

public class EventHandler {
    private const string tag = "server_hint";
    private Config config => Plugin.Instance!.Config; 

    public EventHandler() {
	Exiled.Events.Handlers.Server.WaitingForPlayers += Event;
    }
    ~EventHandler() {
        Exiled.Events.Handlers.Server.WaitingForPlayers -= Event;
        Timing.KillCoroutines(tag);
    }
    
    private void Event() => Timing.RunCoroutine(Display().CancelWith(Server.Host.GameObject), tag);

    private IEnumerator<float> Display() {
	string hint;
	float time;

        while (true) {
	    string deadhint = Parser.Parse(config.spectatorHint);
	    string lobbyhint = Parser.Parse(config.lobbyHint);
	    string normalhint = Parser.Parse(config.hint);

	    if (!Round.IsStarted && config.lobby) {
		hint = Parser.Parse(config.lobbyHint);
		time = config.lobbyRefreshRate;
	    }
	    else if (!Round.IsStarted && !config.lobby) {
		hint = "";
		time = 1;
	    }
	    else {
		hint = Parser.Parse(config.hint);;
		time = config.refreshRate;
	    }
	    if (hint == "")
		yield return Timing.WaitForSeconds(time);

	    if (config.spectator) {
		foreach (Player player in Player.List) {
		    if (player.IsDead && Round.IsStarted) {
			hint = Parser.Parse(config.spectatorHint);;
			time = config.spectatorRefreshRate;
		    }
		    player.ShowHint(hint, time);
		}
	    }
	    else {
		foreach (Player player in Player.List)
		    player.ShowHint(hint, time);
	    }
            yield return Timing.WaitForSeconds(time);
        }
    }
}
