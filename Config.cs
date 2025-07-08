using Exiled.API.Interfaces;

namespace ServerHint;

public class Config : IConfig {
    public bool IsEnabled { get; set; } = true;
    public bool Debug { get; set; }

    public string hint { get; set; } = "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n<size=16><color=yellow>My Awesome Server</color></size>";
    public float refreshRate { get; set; } = 24f;
}
