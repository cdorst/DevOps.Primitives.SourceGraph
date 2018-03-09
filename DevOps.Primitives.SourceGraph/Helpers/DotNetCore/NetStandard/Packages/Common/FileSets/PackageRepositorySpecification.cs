using DevOps.Primitives.NuGet;
using DevOps.Primitives.SourceGraph.Helpers.Common.Accounts;
using System.Collections.Generic;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.FileSets
{
    public class PackageRepositorySpecification
    {
        public PackageRepositorySpecification() { }

        public PackageRepositorySpecification(
            NuGetPackageSpecification packageSpecification,
            string appveyorAzureStorageSecret,
            string authorEmail,
            string packageCacheUri,
            List<NuGetReference> dependencies)
        {
            AppveyorAzureStorageSecret = appveyorAzureStorageSecret;
            AuthorEmail = authorEmail;
            Dependencies = dependencies;
            PackageCacheUri = packageCacheUri;
            PackageSpecification = packageSpecification;
        }

        public PackageRepositorySpecification(
            string gitHubAndNuGetAccount, string name, string version, string copyright, string description, string packageIconUrl, string namespacePrefix, string authorEmail, string packageCacheUri, string appveyorAzureStorageSecret, List<NuGetReference> dependencies)
            : this(
                  new NuGetPackageSpecification(gitHubAndNuGetAccount, name, version, copyright, description, packageIconUrl, namespacePrefix),
                  appveyorAzureStorageSecret, authorEmail, packageCacheUri, dependencies)
        {
        }

        public PackageRepositorySpecification(string name, string version, string description, List<NuGetReference> dependencies, ReusablePackageSpecification packageSpecification)
            : this(packageSpecification.GitHubAndNuGetAccount, name, version, packageSpecification.Copyright, description, packageSpecification.PackageIconUrl, packageSpecification.NamespacePrefix, packageSpecification.AuthorEmail, packageSpecification.PackageCacheUrl, packageSpecification.AppveyorAzureStorageSecret, dependencies)
        {
        }

        public PackageRepositorySpecification(GitHubAccount account, string name, string version, string description, List<NuGetReference> dependencies)
            : this(name, version, description, dependencies, account.AccountSettings.GetPackageSpecification())
        {
        }

        public string AppveyorAzureStorageSecret { get; set; }
        public string AuthorEmail { get; set; }
        public List<NuGetReference> Dependencies { get; set; }
        public string PackageCacheUri { get; set; }
        public NuGetPackageSpecification PackageSpecification { get; set; }
    }
}
