using static DevOps.Primitives.SourceGraph.Helpers.Common.Files.ReadmeFileBadgeStyles;
using static System.String;

namespace DevOps.Primitives.SourceGraph.Helpers.Common.Files
{
    public static class ReadmeFileHelper
    {
        public const string ReadmeFileName = "README.md";

        public static string GetAppVeyorBadge(in string prefix, in string name, in string style = BadgeStyleLarge)
        {
            var dashName = name.Replace('.', '-').ToLower();
            if (dashName.Length > 50) dashName = dashName.Substring(0, 50);
            var prefixLower = prefix.ToLower();
            return Concat("[![AppVeyor build status](https://img.shields.io/appveyor/ci/", prefixLower, "/", dashName, ".svg?label=AppVeyor&style=", style, ")](https://ci.appveyor.com/project/", prefixLower, "/", dashName, ")");
        }

        public static string GetBadges(in string prefix, in string repoName, in string style = BadgeStyleSmall)
            => Concat(GetAppVeyorBadge(in prefix, in repoName, in style), " ", GetNuGetBadge(in prefix, in repoName, in style));

        public static string GetFullName(in string prefix, in string name) => Concat(prefix, ".", name);

        public static string GetNuGetBadge(in string prefix, in string name, in string style = BadgeStyleLarge)
        {
            var fullName = GetFullName(in prefix, in name);
            return Concat("[![NuGet package status](https://img.shields.io/nuget/v/", fullName, ".svg?label=NuGet&style=", style, ")](", GetNuGetLinkUrl(in fullName), ")");
        }

        public static string GetNuGetLinkUrl(in string name)
            => Concat("https://www.nuget.org/packages/", name);
    }
}
