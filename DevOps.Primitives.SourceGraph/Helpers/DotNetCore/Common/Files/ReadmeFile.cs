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
        private const string NuGet = nameof(NuGet);

        public static RepositoryFile Readme(
            string name,
            IEnumerable<NuGetReference> nuGetReferences,
            NuGetPackageInfo nuGetPackageInfo)
        {
            var content = new StringBuilder($"# {name}");
            if (nuGetPackageInfo != null)
            {
                content.AppendLine("## Description")
                    .AppendLine().AppendLine(nuGetPackageInfo.Description).AppendLine();
                var prefix = name.Split('.').First();
                if (Any(nuGetReferences))
                {
                    content.AppendLine("## Dependencies").AppendLine()
                        .AppendLine("Name | Version | Links")
                        .AppendLine("---- | ------- | -----");
                    foreach (var dependency in nuGetReferences) content
                        .AppendLine($"{dependency.Include.Value} | {dependency.Version.Value} | {GetLinks(dependency, prefix)}");
                    content.AppendLine();
                }
                var fullName = $"{prefix}.{name}";
                content.AppendLine("## NuGet")
                    .AppendLine().AppendLine($"This project is published as a NuGet package at {GetNuGetLink(fullName, true)}").AppendLine();
                content.AppendLine("## Version")
                    .AppendLine().AppendLine(nuGetPackageInfo.Version).AppendLine();
            }
            return new RepositoryFile("README.md", content.ToString());
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
            => $"[{GetNuGetLinkName(name, useUrlAsName)}](https://www.nuget.org/packages/{name})";

        private static string GetNuGetLinkName(string name, bool useUrlAsName)
            => useUrlAsName ? name : NuGet;
    }
}
