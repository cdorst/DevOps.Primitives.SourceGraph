using DevOps.Primitives.VisualStudio.Projects.Helpers.DotNetCore;
using static DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.FileSets.GitHubRepoNameHelper;
using static System.String;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.FileSets
{
    public class NuGetPackageSpecification
    {
        public NuGetPackageSpecification(
            in string gitHubAndNuGetAccount,
            in string name,
            in string version,
            in string copyright,
            in string description,
            in string packageIconUrl,
            in string namespacePrefix)
            : this(
                  RepoUrl(in gitHubAndNuGetAccount, in name),
                  in name,
                  in version,
                  in gitHubAndNuGetAccount,
                  in copyright,
                  in description,
                  in packageIconUrl,
                  in namespacePrefix)
        {
        }

        public NuGetPackageSpecification(
            in string gitHubUrl,
            in string name,
            in string version,
            in string authors,
            in string copyright,
            in string description,
            in string packageIconUrl,
            in string namespacePrefix)
            : this(
                  in name,
                  in version,
                  in authors,
                  in copyright,
                  in description,
                  in packageIconUrl,
                  Concat(gitHubUrl, "/blob/master/LICENSE"),
                  in gitHubUrl,
                  in gitHubUrl,
                  in namespacePrefix)
        {
        }

        public NuGetPackageSpecification(
            in string name,
            in string version,
            in string authors,
            in string copyright,
            in string description,
            in string packageIconUrl,
            in string packageLicenseUrl,
            in string packageProjectUrl,
            in string repositoryUrl,
            in string namespacePrefix = default)
        {
            Authors = authors;
            Copyright = copyright;
            Description = description;
            Name = name;
            NamespacePrefix = namespacePrefix;
            PackageIconUrl = packageIconUrl;
            PackageLicenseUrl = packageLicenseUrl;
            PackageProjectUrl = packageProjectUrl;
            RepositoryUrl = repositoryUrl;
            Version = version;
        }

        public string Authors { get; set; }
        public string Copyright { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string NamespacePrefix { get; set; }
        public string PackageIconUrl { get; set; }
        public string PackageLicenseUrl { get; set; }
        public string PackageProjectUrl { get; set; }
        public string RepositoryUrl { get; set; }
        public string Version { get; set; }

        public NuGetPackageInfo GetPackageInfo()
            => new NuGetPackageInfo(Version, Authors, Copyright, Description, PackageIconUrl, PackageLicenseUrl, PackageProjectUrl, RepositoryUrl, true, GetPackageId());

        private string GetPackageId()
            => IsNullOrWhiteSpace(NamespacePrefix) ? null : Concat(NamespacePrefix, ".", Name);
    }
}
