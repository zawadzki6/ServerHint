using Exiled.API.Interfaces;
using System.ComponentModel;

namespace ServerHint;

public class Config : IConfig {
    public bool IsEnabled { get; set; } = true;
    public bool Debug { get; set; }

    [Description("whether to use a different hint for spectators")]
    public bool spectator { get; set; } = false;
    [Description("whether to show a lobby hint")]
    public bool lobby { get; set; } = false;

    public string hint { get; set; } = "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n<size=16><color=yellow>My Awesome Server</color></size>";
    public string spectatorHint { get; set; } = "";
    public string lobbyHint { get; set; } = "";
    public float refreshRate { get; set; } = 24f;
    public float spectatorRefreshRate { get; set; } = 6;
    public float lobbyRefreshRate { get; set; } = 24;
}
