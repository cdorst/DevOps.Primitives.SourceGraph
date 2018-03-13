using static DevOps.Primitives.SourceGraph.Helpers.Common.Files.ReadmeFileBadgeStyles;

namespace DevOps.Primitives.SourceGraph.Helpers.Common.Files
{
    public static class ReamdmeFileHelper
    {
        public const string ReadmeFileName = "README.md";

        public static string GetAppVeyorBadge(string prefix, string name, string style = BadgeStyleLarge)
        {
            var dashName = name.Replace('.', '-').ToLower();
            if (dashName.Length > 50) dashName = dashName.Substring(0, 50);
            var prefixLower = prefix.ToLower();
            return $"[![AppVeyor build status](https://img.shields.io/appveyor/ci/{prefixLower}/{dashName}.svg?label=AppVeyor&style={style})](https://ci.appveyor.com/project/{prefixLower}/{dashName})";
        }

        public static string GetBadges(string prefix, string repoName, string style = BadgeStyleSmall)
            => $"{GetAppVeyorBadge(prefix, repoName, style)} {GetNuGetBadge(prefix, repoName, style)}";

        public static string GetFullName(string prefix, string name) => $"{prefix}.{name}";

        public static string GetNuGetBadge(string prefix, string name, string style = BadgeStyleLarge)
        {
            var fullName = GetFullName(prefix, name);
            return $"[![NuGet package status](https://img.shields.io/nuget/v/{fullName}.svg?label=NuGet&style={style})]({GetNuGetLinkUrl(fullName)})";
        }

        public static string GetNuGetLinkUrl(string name)
            => $"https://www.nuget.org/packages/{name}";
    }
}
