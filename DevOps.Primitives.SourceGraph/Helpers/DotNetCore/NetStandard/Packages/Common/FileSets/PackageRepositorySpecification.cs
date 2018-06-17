using DevOps.Primitives.NuGet;
using DevOps.Primitives.SourceGraph.Helpers.Common.Accounts;
using System.Collections.Generic;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.FileSets
{
    public class PackageRepositorySpecification
    {
        public PackageRepositorySpecification() { }

        public PackageRepositorySpecification(
            in NuGetPackageSpecification packageSpecification,
            in string appveyorAzureStorageSecret,
            in string authorEmail,
            in string packageCacheUri,
            in List<NuGetReference> dependencies)
        {
            AppveyorAzureStorageSecret = appveyorAzureStorageSecret;
            AuthorEmail = authorEmail;
            Dependencies = dependencies;
            PackageCacheUri = packageCacheUri;
            PackageSpecification = packageSpecification;
        }

        public PackageRepositorySpecification(
            in string gitHubAndNuGetAccount,
            in string name,
            in string version,
            in string copyright,
            in string description,
            in string packageIconUrl,
            in string namespacePrefix,
            in string authorEmail,
            in string packageCacheUri,
            in string appveyorAzureStorageSecret,
            in List<NuGetReference> dependencies)
            : this(
                  new NuGetPackageSpecification(
                      in gitHubAndNuGetAccount,
                      in name,
                      in version,
                      in copyright,
                      in description,
                      in packageIconUrl,
                      in namespacePrefix),
                  in appveyorAzureStorageSecret,
                  in authorEmail,
                  in packageCacheUri,
                  in dependencies)
        {
        }

        public PackageRepositorySpecification(
            in string name,
            in string version,
            in string description,
            in List<NuGetReference> dependencies,
            in ReusablePackageSpecification packageSpecification)
            : this(
                  packageSpecification.GitHubAndNuGetAccount,
                  in name,
                  in version,
                  packageSpecification.Copyright,
                  in description,
                  packageSpecification.PackageIconUrl,
                  packageSpecification.NamespacePrefix,
                  packageSpecification.AuthorEmail,
                  packageSpecification.PackageCacheUrl,
                  packageSpecification.AppveyorAzureStorageSecret,
                  in dependencies)
        {
        }

        public PackageRepositorySpecification(
            in GitHubAccount account,
            in string name,
            in string version,
            in string description,
            in List<NuGetReference> dependencies)
            : this(
                  in name,
                  in version,
                  in description,
                  in dependencies,
                  account.AccountSettings.GetPackageSpecification())
        {
        }

        public string AppveyorAzureStorageSecret { get; set; }
        public string AuthorEmail { get; set; }
        public List<NuGetReference> Dependencies { get; set; }
        public string PackageCacheUri { get; set; }
        public NuGetPackageSpecification PackageSpecification { get; set; }
    }
}
