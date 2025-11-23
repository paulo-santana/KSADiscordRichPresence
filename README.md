# KSA Discord Rich Presence

A mod for Kitten Space Agency (KSA) that adds Discord Rich Presence support,
allowing your friends to see what you're doing in the game!

## Features

- 🚀 **Real-time Vehicle Tracking**: Shows the vehicle you're currently controlling
- 🌍 **Location Display**: Displays the celestial body you're orbiting or landed on
- 📊 **Situation Awareness**: Shows whether you're landed, orbiting or splashed down
- 🖼️ **Dynamic Assets**: Different images based on the celestial body you're at

## Installation

### Manual Installation
1. Download the latest release from [SpaceDock](https://spacedock.info/mod/4050/KSA%20Discord%20Rich%20Presence)
2. Extract the contents to your KSA mods folder
3. Make sure the following DLLs are in the mod folder:
   - `KSADiscordRichPresence.dll`
   - `DiscordRPC.dll`
   - `Newtonsoft.Json.dll`
   - `mod.toml`

## Building from Source

### Prerequisites
- .NET 10.0 SDK
- KSA game files (specifically `KSA.dll`)

### Build Instructions

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/KSADiscordRichPresence.git
   cd KSADiscordRichPresence
   ```

2. Update the KSA.dll reference path in `KSADiscordRichPresence.csproj`:
   ```xml
   <Reference Include="KSA">
     <HintPath>YOUR_PATH_TO_KSA\KSA.dll</HintPath>
     <Private>false</Private>
   </Reference>
   ```

3. Build the project:
   ```bash
   dotnet build -c Release
   ```

4. The compiled mod will be in `bin/Release/net10.0/`

### Dependencies
The project uses the following NuGet packages:
- **DiscordRichPresence** (v1.6.1.70) - Discord RPC client
- **Lib.Harmony** (v2.4.2) - Runtime patching library
- **StarMap.API** (v0.2.4) - KSA modding API

Note: `DiscordRPC.dll` and `Newtonsoft.Json.dll` need to be distributed with the mod, but Harmony and StarMap.API are provided by the mod loader.

## License

This project is licensed under the GNU General Public License v3.0 - see the [LICENSE](LICENSE) file for details.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## Support

If you encounter any issues or have suggestions:
- Open an issue on GitHub
- Visit the mod page on [SpaceDock](https://spacedock.info/mod/4050/KSA%20Discord%20Rich%20Presence)

## Acknowledgments

- Built with [DiscordRichPresence](https://github.com/Lachee/discord-rpc-csharp) by Lachee
- Image assets were ripped from [KSA website](https://ksa.ahwoo.com)
