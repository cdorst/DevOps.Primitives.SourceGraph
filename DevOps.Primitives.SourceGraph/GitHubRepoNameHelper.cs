namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.FileSets
{
    internal static class GitHubRepoNameHelper
    {
        public static string RepoUrl(string account, string name)
            => $"https://github.com/{account}/{name}";
    }
}
