namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.Files
{
    public static class LocalNuGetConfig
    {
        private const string Content = @"<?xml version=""1.0"" encoding=""utf-8""?>
<configuration>
    <packageSources>
        <add key=""Local package cache"" value=""%LOCAL_NUGET_SOURCE_PATH%"" />
        <add key=""NuGet official package source"" value=""https://api.nuget.org/v3/index.json"" />
    </packageSources>
</configuration>
";
        private const string Name = "nuget.config";

        public static RepositoryFile NuGetConfig()
            => new RepositoryFile(Name, Content);
    }
}
