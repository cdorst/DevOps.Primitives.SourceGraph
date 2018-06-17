using static System.String;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.FileSets
{
    internal static class GitHubRepoNameHelper
    {
        public static string RepoUrl(in string account, in string name)
            => Concat("https://github.com/", account, "/", name);
    }
}
