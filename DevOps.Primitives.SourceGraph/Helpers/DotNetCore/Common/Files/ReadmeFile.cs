using DevOps.Primitives.NuGet;
using DevOps.Primitives.VisualStudio.Projects.Helpers.DotNetCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Common.Functions.CheckNullableEnumerationForAnyElements.NullableEnumerationAny;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.Common.Files
{
    public static class ReadmeFile
    {
        private const string BadgeStyle = "for-the-badge"; // https://shields.io
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
            }
            else if (name == "Project.Index" && Any(nuGetReferences))
            {
                // This is a special case for a "Project.Index" repository where each NuGetReference is another project under the same GitHub account
                var prefix = nuGetReferences.First().Include.Value.Split('.').First(); // MyProject.MyDomain.MyConcern => MyProject
                var prefixSubStrIdx = prefix.Length + 1;
                content.AppendLine("## Repositories").AppendLine()
                    .AppendLine("Name | Version | Links | Badges")
                    .AppendLine("---- | ------- | ----- | ------");
                foreach (var dependency in nuGetReferences.OrderBy(pkg => pkg.Include.Value))
                {
                    var repoName = dependency.Include.Value.Substring(prefixSubStrIdx);
                    content.AppendLine($"{repoName} | {dependency.Version.Value} | {GetLinks(dependency, prefix)} | {GetBadges(prefix, repoName)}");
                }
                content.AppendLine();
            }
            return new RepositoryFile("README.md", content.ToString());
        }

        private static string GetAppVeyorBadge(string prefix, string name)
        {
            var dashName = name.Replace('.', '-').ToLower();
            var prefixLower = prefix.ToLower();
            return $"[![AppVeyor build status](https://img.shields.io/appveyor/ci/{prefixLower}/{dashName}/master.svg?label=AppVeyor&style={BadgeStyle})](https://ci.appveyor.com/project/{prefixLower}/{dashName})";
        }

        private static string GetBadges(string prefix, string repoName)
            => $"{GetAppVeyorBadge(prefix, repoName)} {GetNuGetBadge(prefix, repoName)}";

        private static string GetFullName(string prefix, string name) => $"{prefix}.{name}";

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

        private static string GetNuGetBadge(string prefix, string name, string fullName = null)
        {
            if (string.IsNullOrEmpty(fullName)) fullName = GetFullName(prefix, name);
            return $"[![NuGet package status](https://img.shields.io/nuget/v/{prefix}.{name}.svg?label=NuGet&style={BadgeStyle})]({GetNuGetLinkUrl(fullName)})";
        }

        private static string GetNuGetLink(string name, bool useUrlAsName = false)
            => GetNuGetLinkComposed(GetNuGetLinkUrl(name), useUrlAsName);

        private static string GetNuGetLinkComposed(string url, bool useUrlAsName)
            => $"[{GetNuGetLinkName(url, useUrlAsName)}]({url})";

        private static string GetNuGetLinkName(string url, bool useUrlAsName)
            => useUrlAsName ? url : NuGet;

        private static string GetNuGetLinkUrl(string name)
            => $"https://www.nuget.org/packages/{name}";
    }
}
