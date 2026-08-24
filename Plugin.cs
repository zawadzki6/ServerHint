using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;

namespace ServerHint;

public class Plugin : Plugin<Config> {
    public override string Name => "ServerHint";
    public override string Author => "Zawadzki Wielki";
    public override string Prefix { get; } = "server_hint";
    public override Version Version => new Version(2, 0, 0);

    public static Plugin? Instance { get; private set; }

    private EventHandler? _handler;
    
    public override void OnEnabled() {
        Instance = this;
        _handler = new EventHandler();
	Player.Spawned += Events.Spawned;
	Player.Verified += Events.Verified;
        base.OnEnabled();
    }
    public override void OnDisabled() {
        Instance = null;
        _handler = null;
	Player.Spawned -= Events.Spawned;
	Player.Verified -= Events.Verified;
        base.OnDisabled();
    }
}
