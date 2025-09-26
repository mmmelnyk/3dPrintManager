Desktop app to aggregate 3d printer enclosure modules control interface.

To run on Mac:
dotnet run --project 3dPrintManager.csproj -f net9.0-maccatalyst -c Debug -r maccatalyst-arm64
To build for mac:
dotnet build 3dPrintManager.csproj -f net9.0-maccatalyst -c Release -r maccatalyst-arm64