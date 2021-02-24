# Announcer
![Discord](https://img.shields.io/discord/742861338233274418?label=Discord&logo=Discord) ![NugetDownloads](https://img.shields.io/nuget/dt/F.Announcer?label=Nuget%20Downloads) [![Github All Releases](https://img.shields.io/github/downloads/01-Feli/F.Announcer/total?label=Github%20Downloads)]()

This is a message announcer plugin for unturned

FPlugins Discord: https://discord.gg/4FF2548

# How to install 

Execute the command ``openmod install F.Announcer``

# Configuration
```
Timer: 5
Announces:
  - Url: https://images-ext-1.discordapp.net/external/1Vg3rH_5wKUid81LpNF3YTOgl-x1Vvix0sNvfrhbtpE/https/unturneditems.com/media/253.png
    Message: "Announce by FPlugins"
    IsRich: true
  - Url: https://images-ext-1.discordapp.net/external/1Vg3rH_5wKUid81LpNF3YTOgl-x1Vvix0sNvfrhbtpE/https/unturneditems.com/media/253.png
    Message: "{color=red}Just another announce{/color}"
    IsRich: true
```

To add more announces just do it like this:

```
Timer: 5
Announces:
  - Url: https://images-ext-1.discordapp.net/external/1Vg3rH_5wKUid81LpNF3YTOgl-x1Vvix0sNvfrhbtpE/https/unturneditems.com/media/253.png
    Message: "Announce by FPlugins"
    IsRich: true
  - Url: https://images-ext-1.discordapp.net/external/1Vg3rH_5wKUid81LpNF3YTOgl-x1Vvix0sNvfrhbtpE/https/unturneditems.com/media/253.png
    Message: "{color=red}Just another announce{/color}"
    IsRich: true
  - Url: https://images-ext-1.discordapp.net/external/1Vg3rH_5wKUid81LpNF3YTOgl-x1Vvix0sNvfrhbtpE/https/unturneditems.com/media/253.png
    Message: "{color=yellow}Just another announce{/color}"
    IsRich: true
```

# HelpFile
```
# Announcer
Id: F.Announcer
Version: 1.0.3
```
