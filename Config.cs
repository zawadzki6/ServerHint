using Exiled.API.Interfaces;
using System.ComponentModel;

namespace ServerHint;

public class Config : IConfig {
    public bool IsEnabled { get; set; } = true;
    public bool Debug { get; set; }

    [Description("whether to use a different hint for spectators")]
    public bool spectator { get; set; } = true;
    [Description("whether to show a lobby hint")]
    public bool lobby { get; set; } = false;

    [Description("available tags that will be replaced during runtime: %tps%, %players%, %maxplayers%, %friendlyfire%, %version%, %roundtime%, %tip%")]
    public string hint { get; set; } = "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n<size=14><color=yellow>My Awesome Server</color></size>\n<size=10>TPS: %tps% | FF: %friendlyfire% | ELAPSED: %roundtime% | PLAYERS: %players%/%maxplayers%</size>";
    public string spectatorHint { get; set; } = "\n\n\n\n\n\n\n\n\n\n\n\n\n<size=14>%tip%</size>\n<size=12><color=yellow>My Awesome Server</color>";
    public string lobbyHint { get; set; } = "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n<b>welcome outlander</b>";

    [Description("how often should the hints refresh")]
    public float refreshRate { get; set; } = 24;
    public float spectatorRefreshRate { get; set; } = 12;
    public float lobbyRefreshRate { get; set; } = 6;

    [Description("placeholder tip if any from the list failed for some reason")]
    public string placeholderTip { get; set; } = "tips will appear here...";
    [Description("tips for the %tip% tag")]
    public List<string> tips { get; set; } = new List<string> {
	"an elevator nade is a good idea, if it's your idea",
	"welcome to the server. now get out!",
	"you should really replace this"
    };
    [Description("%friendlyfire% tag translation")]
    public string FriendlyFireOn { get; set; } = "ON";
    public string FriendlyFireOff { get; set; } = "OFF";

    [Description("should the %tps% tag use direct or average tps")]
    public bool averageTps { get; set; } = true;
}
