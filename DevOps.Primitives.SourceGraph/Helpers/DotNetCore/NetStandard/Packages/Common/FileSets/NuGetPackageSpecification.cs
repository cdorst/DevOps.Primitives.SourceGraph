using DevOps.Primitives.VisualStudio.Projects.Helpers.DotNetCore;
using static DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.FileSets.GitHubRepoNameHelper;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.FileSets
{
    public class NuGetPackageSpecification
    {
        public NuGetPackageSpecification(string gitHubAndNuGetAccount, string name, string version, string copyright, string description, string packageIconUrl, string namespacePrefix)
            : this(RepoUrl(gitHubAndNuGetAccount, name), name, version, gitHubAndNuGetAccount, copyright, description, packageIconUrl, namespacePrefix)
        {
        }

        public NuGetPackageSpecification(string gitHubUrl, string name, string version, string authors, string copyright, string description, string packageIconUrl, string namespacePrefix)
            : this(name, version, authors, copyright, description, packageIconUrl, $"{gitHubUrl}/blob/master/LICENSE", gitHubUrl, gitHubUrl, namespacePrefix)
        {
        }

        public NuGetPackageSpecification(string name, string version, string authors, string copyright, string description, string packageIconUrl, string packageLicenseUrl, string packageProjectUrl, string repositoryUrl, string namespacePrefix = null)
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

        public string Version { get; set; }
        public string Authors { get; set; }
        public string Copyright { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string NamespacePrefix { get; set; }
        public string PackageIconUrl { get; set; }
        public string PackageLicenseUrl { get; set; }
        public string PackageProjectUrl { get; set; }
        public string RepositoryUrl { get; set; }

        public NuGetPackageInfo GetPackageInfo()
            => new NuGetPackageInfo(Version, Authors, Copyright, Description, PackageIconUrl, PackageLicenseUrl, PackageProjectUrl, RepositoryUrl, true, GetPackageId());

        private string GetPackageId()
            => string.IsNullOrWhiteSpace(NamespacePrefix) ? null : $"{NamespacePrefix}.{Name}";
    }
}
