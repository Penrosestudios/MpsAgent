Please see start up script for Linux and Windows for setting up firewalls and installing additional dependencies.

## Build For Windows:

In a VS2017 developer cmd prompt:
dotnet publish VMAgent.csproj -c release -o outputFolder --runtime win10-x64

The "outputFolder" in the directory containing the csproj file will have the dlls and exe.

## Build For Ubuntu - 18.04

In a VS2017 developer cmd prompt:
dotnet publish VMAgent.csproj -c release -o outputFolder --runtime ubuntu.18.04-x64

The "outputFolder" in the directory containing the csproj file will have the dlls and exe.
Once the files are copied over, the LocalMultiplayerAgent file will need to be converted to executable - chmod +X LocalMultiplayerAgent
