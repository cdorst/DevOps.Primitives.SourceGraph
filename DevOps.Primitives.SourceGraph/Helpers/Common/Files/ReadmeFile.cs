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
            NuGetPackageInfo nuGetPackageInfo)
        {
            var content = new StringBuilder($"# {name}").AppendLine();
            if (nuGetPackageInfo != null)
            {
                var prefix = nuGetPackageInfo.PackageId.Split('.').First();
                var fullName = GetFullName(prefix, name);
                content.AppendLine()
                    .AppendLine(GetAppVeyorBadge(prefix, name))
                    .AppendLine(GetNuGetBadge(name, prefix, fullName))
                    .AppendLine();
                content.AppendLine("## Description")
                    .AppendLine().AppendLine(nuGetPackageInfo.Description).AppendLine();
                if (Any(nuGetReferences))
                {
                    content.AppendLine("## Dependencies").AppendLine()
                        .AppendLine("Name | Version | Links")
                        .AppendLine("---- | ------- | -----");
                    foreach (var dependency in nuGetReferences) content
                        .AppendLine($"{dependency.Include.Value} | {dependency.Version.Value} | {GetLinks(dependency, prefix)}");
                    content.AppendLine();
                }
                content.AppendLine("## NuGet")
                    .AppendLine().AppendLine($"This project is published as a NuGet package at {GetNuGetLink(fullName, true)}").AppendLine();
                content.AppendLine("## Version")
                    .AppendLine().AppendLine(nuGetPackageInfo.Version).AppendLine();
                content.AppendLine("## Metaproject")
                    .AppendLine().AppendLine($"{name} is a component of a larger project distributed across multiple repositories on this GitHub account. Some of these component-projects (including this one) are created and maintained by robots. View the metaproject's component directory at [https://github.com/{prefix}/Project.Index](https://github.com/{prefix}/Project.Index)").AppendLine();
            }
            return new RepositoryFile(ReadmeFileName, content.ToString());
        }

        private static string GetLinks(NuGetReference dependency, string prefix)
        {
            var name = dependency.Include.Value;
            var links = new StringBuilder(GetNuGetLink(name));
            if (name.StartsWith($"{prefix}."))
            {
                var repo = string.Join(".", name.Split('.').Skip(1));
                links.Append($", [GitHub](https://github.com/{prefix}/{repo})");
            }
            return links.ToString();
        }

        private static string GetNuGetLink(string name, bool useUrlAsName = false)
            => GetNuGetLinkComposed(GetNuGetLinkUrl(name), useUrlAsName);

        private static string GetNuGetLinkComposed(string url, bool useUrlAsName)
            => $"[{GetNuGetLinkName(url, useUrlAsName)}]({url})";

        private static string GetNuGetLinkName(string url, bool useUrlAsName)
            => useUrlAsName ? url : NuGet;
    }
}
