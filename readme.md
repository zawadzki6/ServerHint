# ServerHint
ServerHint is a plugin for displaying a constant hint, usually a watermark on EXILED servers.

Available flags that get replaced during runtime:
- %tps%
- %players%
- %maxplayers%
- %friendlyfire%
- %version%
- %roundtime%
- %tip%

### Build dependencies
- dotnet
- UnityEngine.CoreModule
- Assembly-CSharp-firstpass
- EXILED 9.14.2

### Default config
```yaml
is_enabled: true
debug: false
# whether to use a different hint for spectators
spectator: true
# whether to show a lobby hint
lobby: false
# available tags that will be replaced during runtime: %tps%, %players%, %maxplayers%, %friendlyfire%, %version%, %roundtime%, %tip%
hint: "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n<size=14><color=yellow>My Awesome Server</color></size>\n<size=10>TPS: %tps% | FF: %friendlyfire% | ELAPSED: %roundtime% | PLAYERS: %players%/%maxplayers%</size>"
spectator_hint: "\n\n\n\n\n\n\n\n\n\n\n\n\n<size=14>%tip%</size>\n<size=12><color=yellow>My Awesome Server</color>"
lobby_hint: "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n<b>welcome outlander</b>"
# how often should the hints refresh
refresh_rate: 24
spectator_refresh_rate: 12
lobby_refresh_rate: 6
# tips for the %tip% tag
tips:
- "an elevator nade is a good idea, if it's your idea"
- "welcome to the server. now get out!"
- "you should really replace this"
# %friendlyfire% tag translation
friendly_fire_on: "ON"
friendly_fire_off: "OFF"
```

