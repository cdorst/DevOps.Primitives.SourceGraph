using DevOps.Primitives.NuGet;
using DevOps.Primitives.VisualStudio.Projects.Helpers.DotNetCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Common.Functions.CheckNullableEnumerationForAnyElements.NullableEnumerationAny;

using static DevOps.Primitives.SourceGraph.Helpers.Common.Files.ReamdmeFileHelper;

namespace DevOps.Primitives.SourceGraph.Helpers.Common.Files
{
    public static class ReadmeFile
    {
        private const string NuGet = nameof(NuGet);

        public static RepositoryFile Readme(
            string name,
            IEnumerable<NuGetReference> nuGetReferences,
            NuGetPackageInfo nuGetPackageInfo,
            IDictionary<string, string> environmentVariables = null)
        {
            var content = new StringBuilder($"# {name}").AppendLine();
            var prefix = string.Empty;
            var hasPackageInfo = nuGetPackageInfo != null;
            if (hasPackageInfo)
            {
                prefix = nuGetPackageInfo.PackageId.Split('.').First();
                content.AppendLine()
                    .AppendLine(GetAppVeyorBadge(prefix, name))
                    .AppendLine(GetNuGetBadge(prefix, name))
                    .AppendLine();
                content.AppendLine("## Description")
                    .AppendLine().AppendLine(nuGetPackageInfo.Description).AppendLine();
            }
            if (Any(environmentVariables))
            {
                var many = environmentVariables.Count > 1;
                var plural = many ? "s" : string.Empty;
                var thisThese = many ? "these" : "this";
                content.AppendLine("## Environment Variables")
                    .AppendLine().AppendLine($"This project depends on {thisThese} environment variable{plural}:").AppendLine();
                content
                    .AppendLine("Name | Description")
                    .AppendLine("---- | -----------");
                foreach (var variable in environmentVariables) content
                    .AppendLine($"`{variable.Key}` | {variable.Value}");
                content.AppendLine();
            }
            if (nuGetPackageInfo != null)
            {
                if (Any(nuGetReferences))
                {
                    content.AppendLine("## Dependencies").AppendLine()
                        .AppendLine("Name | Status")
                        .AppendLine("---- | ------");
                    foreach (var dependency in nuGetReferences) content
                        .AppendLine($"{GetDependencyLink(dependency, prefix)} | {GetStatus(dependency, prefix)}");
                    content.AppendLine();
                }
                content.AppendLine("## NuGet")
                    .AppendLine().AppendLine($"This project is published as a NuGet package at {GetNuGetLink(prefix, name, true)}").AppendLine();
                content.AppendLine("## Version")
                    .AppendLine().AppendLine(nuGetPackageInfo.Version).AppendLine();
                content.AppendLine("## Metaproject")
                    .AppendLine().AppendLine($"{name} is maintained by robots and exists because of a declarative template metaproject. View the metaproject's component directory at [https://github.com/{prefix}/Project.Index](https://github.com/{prefix}/Project.Index)").AppendLine();
            }
            return new RepositoryFile(ReadmeFileName, content.ToString());
        }

        private static string GetDependencyLink(NuGetReference dependency, string prefix)
        {
            var name = dependency.Include.Value;
            var external = !name.StartsWith($"{prefix}.");
            return external ? name : $"[{name}](https://github.com/{prefix}/{name.Substring(prefix.Length + 2)})";
        }

        private static string GetStatus(NuGetReference dependency, string prefix)
        {
            var name = dependency.Include.Value;
            var external = !name.StartsWith($"{prefix}.");
            return !external
                ? GetBadges(prefix, name.Substring(prefix.Length + 2))
                : $"[![NuGet package status](https://img.shields.io/nuget/v/{name}.svg?label=NuGet&style={ReadmeFileBadgeStyles.BadgeStyleSmall})]({GetNuGetLinkUrl(name)})";
        }

        private static string GetNuGetLink(string prefix, string name, bool useUrlAsName = false)
            => GetNuGetLinkComposed(GetNuGetLinkUrl(GetFullName(prefix, name)), useUrlAsName);

        private static string GetNuGetLinkComposed(string url, bool useUrlAsName)
            => $"[{GetNuGetLinkName(url, useUrlAsName)}]({url})";

        private static string GetNuGetLinkName(string url, bool useUrlAsName)
            => useUrlAsName ? url : NuGet;
    }
}
