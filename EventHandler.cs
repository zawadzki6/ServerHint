using Exiled.API.Features;
using MEC;

namespace ServerHint;

public class EventHandler {
    private const string tag = "server_hint";
    private Config _config => ServerHint.Instance!.Config; 

    public EventHandler() { Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted; }
    ~EventHandler() {
        Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStarted;
        Timing.KillCoroutines(tag);
    }
    
    private void OnRoundStarted() { Timing.RunCoroutine(Display().CancelWith(Server.Host.GameObject), tag); }

    private IEnumerator<float> Display() {
        while (true) {
            foreach (Player player in Player.List)
                player.ShowHint(_config.hint, _config.refreshRate);
            yield return Timing.WaitForSeconds(_config.refreshRate);
        }
    }

}
