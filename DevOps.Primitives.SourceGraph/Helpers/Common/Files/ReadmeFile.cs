using DevOps.Primitives.NuGet;
using DevOps.Primitives.VisualStudio.Projects.Helpers.DotNetCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Common.Functions.CheckNullableEnumerationForAnyElements.NullableEnumerationAny;
using static DevOps.Primitives.SourceGraph.Helpers.Common.Files.ReadmeFileBadgeStyles;
using static DevOps.Primitives.SourceGraph.Helpers.Common.Files.ReadmeFileHelper;
using static System.String;

namespace DevOps.Primitives.SourceGraph.Helpers.Common.Files
{
    public static class ReadmeFile
    {
        private const string NuGet = nameof(NuGet);

        public static RepositoryFile Readme(
            in string name,
            in IEnumerable<NuGetReference> nuGetReferences,
            in NuGetPackageInfo nuGetPackageInfo,
            in IDictionary<string, string> environmentVariables = null)
        {
            var content = new StringBuilder(Concat("# ", name)).AppendLine();
            var prefix = Empty;
            var hasPackageInfo = nuGetPackageInfo != null;
            if (hasPackageInfo)
            {
                prefix = nuGetPackageInfo.PackageId.Split('.').First();
                content.AppendLine()
                    .AppendLine(GetAppVeyorBadge(in prefix, in name))
                    .AppendLine(GetNuGetBadge(in prefix, in name))
                    .AppendLine();
                content.AppendLine("## Description")
                    .AppendLine().AppendLine(nuGetPackageInfo.Description).AppendLine();
            }
            if (Any(environmentVariables))
            {
                var many = environmentVariables.Count > 1;
                var plural = many ? "s" : Empty;
                var thisThese = many ? "these" : "this";
                content.AppendLine("## Environment Variables")
                    .AppendLine().AppendLine(Concat("This project depends on ", thisThese, " environment variable", plural, ":")).AppendLine();
                content
                    .AppendLine("Name | Description")
                    .AppendLine("---- | -----------");
                foreach (var variable in environmentVariables)
                    content.AppendLine(Concat("`", variable.Key, "` | ", variable.Value));
                content.AppendLine();
            }
            if (nuGetPackageInfo != null)
            {
                if (Any(nuGetReferences))
                {
                    content.AppendLine("## Dependencies").AppendLine()
                        .AppendLine("Name | Status")
                        .AppendLine("---- | ------");
                    foreach (var dependency in nuGetReferences.OrderBy(r => r.Include.Value)) content
                        .AppendLine(Concat(GetDependencyLink(in dependency, in prefix), " | ", GetStatus(in dependency, in prefix)));
                    content.AppendLine();
                }
                content.AppendLine("## NuGet")
                    .AppendLine().AppendLine(Concat("This project is published as a NuGet package at ", GetNuGetLink(in prefix, in name, true))).AppendLine();
                content.AppendLine("## Version")
                    .AppendLine().AppendLine(nuGetPackageInfo.Version).AppendLine();
                content.AppendLine("## Metaproject")
                    .AppendLine().AppendLine(Concat(name, " is maintained by robots and exists because of a declarative template metaproject. View the metaproject's component directory at [https://github.com/", prefix, "/Project.Index](https://github.com/", prefix, "/Project.Index)")).AppendLine();
            }
            return new RepositoryFile(ReadmeFileName, content.ToString());
        }

        private static string GetDependencyLink(in NuGetReference dependency, in string prefix)
        {
            var name = dependency.Include.Value;
            var external = !name.StartsWith(Concat(prefix, "."));
            return external ? name : Concat("[", name, "](https://github.com/", prefix, "/", name.Substring(prefix.Length + 1), ")");
        }

        private static string GetStatus(in NuGetReference dependency, in string prefix)
        {
            var name = dependency.Include.Value;
            var external = !name.StartsWith(Concat(prefix, "."));
            return !external
                ? GetBadges(in prefix, name.Substring(prefix.Length + 1))
                : Concat("[![NuGet package status](https://img.shields.io/nuget/v/", name, ".svg?label=NuGet&style=", BadgeStyleSmall, ")](", GetNuGetLinkUrl(in name), ")");
        }

        private static string GetNuGetLink(in string prefix, in string name, in bool useUrlAsName = false)
            => GetNuGetLinkComposed(GetNuGetLinkUrl(GetFullName(in prefix, in name)), in useUrlAsName);

        private static string GetNuGetLinkComposed(in string url, in bool useUrlAsName)
            => Concat("[", GetNuGetLinkName(in url, in useUrlAsName), "](", url, ")");

        private static string GetNuGetLinkName(in string url, in bool useUrlAsName)
            => useUrlAsName ? url : NuGet;
    }
}
