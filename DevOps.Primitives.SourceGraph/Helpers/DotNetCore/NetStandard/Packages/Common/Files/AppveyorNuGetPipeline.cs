﻿namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.Files
{
    public class AppveyorNuGetPipeline
    {
        private const string CacheDirectory = @"c:\projects\nuget\cache";
        private const string Name = "appveyor.yml";
        private const string ParentDirectory = @"c:\projects\nuget";
        private const string ToolsVersion = "15";
        private static readonly string ToolsDirectory = $@"c:\projects\nuget\tools_{ToolsVersion}";

        public static RepositoryFile AppveyorYml(
            in string nugetSource,
            in string namespacePrefix,
            in string notificationEmail,
            in string appveyorAzureStorageSecret,
            in string version)
            => new RepositoryFile(Name, $@"version: {version}-{{branch}}-{{build}}
image: Visual Studio 2017
environment:
  AZURE_STORAGE_CONNECTION_STRING:
    secure: {appveyorAzureStorageSecret}
  LOCAL_NUGET_SOURCE_PATH: {CacheDirectory}
install:
- ps: >-
    $source = ""https://cdorst-dev.azureedge.net/build/nuget-tools_{ToolsVersion}.zip""

    $toolsZip = ""{ToolsDirectory}.zip""

    $toolsPath = ""{ToolsDirectory}""

    New-Item -ItemType Directory -Force -Path {CacheDirectory}

    $toolsExist = Test-Path $toolsPath

    if (-NOT ($toolsExist)) {{

        New-Item -ItemType Directory -Force -Path $toolsPath

        Invoke-WebRequest $source -OutFile $toolsZip

        Expand-Archive -Path $toolsZip -DestinationPath $toolsPath -Force

    }}

    & cd ""$env:APPVEYOR_BUILD_FOLDER""

    & dotnet {ToolsDirectory}\before.dll {namespacePrefix} {CacheDirectory} {nugetSource}
cache:
- {CacheDirectory}
- {ToolsDirectory}
before_build:
- cmd: dotnet restore
build:
  verbosity: minimal
configuration: Release
after_build:
- ps: >-
    & dotnet {ToolsDirectory}\after.dll {namespacePrefix} nuget {ParentDirectory}\tmp
artifacts:
- path: '**\*.nupkg'
deploy:
- provider: Environment
  name: {namespacePrefix}NuGet
  on:
    branch: master
notifications:
- provider: Email
  to:
  - {notificationEmail}
  on_build_success: true
  on_build_failure: true
  on_build_status_changed: false
");
    }
}
