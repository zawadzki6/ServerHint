using Exiled.API.Features;

namespace ServerHint;

public class ServerHint : Plugin<Config> {
    public override string Name => "ServerHint";
    public override string Author => "Zawadzki Wielki";
    public override string Prefix { get; } = "server_hint";
    public override Version Version => new Version(1, 0, 0);

    public static ServerHint? Instance { get; private set; }

    private EventHandler? _handler;
    
    public override void OnEnabled() {
        Instance = this;
        _handler = new EventHandler();
        base.OnEnabled();
    }
    public override void OnDisabled() {
        Instance = null;
        _handler = null;
        base.OnDisabled();
    }
}
