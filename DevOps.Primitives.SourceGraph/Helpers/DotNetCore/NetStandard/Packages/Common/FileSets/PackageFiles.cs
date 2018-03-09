using DevOps.Primitives.CSharp;
using DevOps.Primitives.NuGet;
using System.Collections.Generic;
using System.Linq;
using static DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Common.FileSets.NetStandardFiles;
using static DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.Files.AppveyorNuGetPipeline;
using static DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.Files.LocalNuGetConfig;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.FileSets
{
    public static class PackageFiles
    {
        public static IEnumerable<RepositoryFile> Package(
            NuGetPackageSpecification packageSpecification,
            string authorEmail,
            string packageCacheUri,
            string appveyorAzureStorageSecret,
            IEnumerable<NuGetReference> nuGetReferences = null)
            => NetStandardRepo(
                packageSpecification.Name,
                nuGetReferences,
                packageSpecification.GetPackageInfo())
                .Concat(
                    NuGetFiles(packageCacheUri, packageSpecification.NamespacePrefix, authorEmail, appveyorAzureStorageSecret));


        public static IEnumerable<RepositoryFile> Package(
            NuGetPackageSpecification packageSpecification,
            string authorEmail,
            string packageCacheUri,
            string appveyorAzureStorageSecret,
            IEnumerable<NuGetReference> nuGetReferences = null,
            params TypeDeclaration[] types)
            => NetStandardRepo(
                packageSpecification.Name,
                nuGetReferences,
                packageSpecification.GetPackageInfo(),
                types)
                .Concat(
                    NuGetFiles(packageCacheUri, packageSpecification.NamespacePrefix, authorEmail, appveyorAzureStorageSecret));

        public static IEnumerable<RepositoryFile> Package(
            NuGetPackageSpecification packageSpecification,
            string authorEmail,
            string packageCacheUri,
            string appveyorAzureStorageSecret,
            IEnumerable<NuGetReference> nuGetReferences = null,
            params RepositoryFile[] types)
            => NetStandardRepo(
                packageSpecification.Name,
                nuGetReferences,
                packageSpecification.GetPackageInfo(),
                types)
                .Concat(
                    NuGetFiles(packageCacheUri, packageSpecification.NamespacePrefix, authorEmail, appveyorAzureStorageSecret));

        private static IEnumerable<RepositoryFile> NuGetFiles(string packageCacheUri, string namespacePrefix, string authorEmail, string appveyorAzureStorageSecret)
        {
            yield return AppveyorYml(packageCacheUri, namespacePrefix, authorEmail, appveyorAzureStorageSecret);
            yield return NuGetConfig();
        }
    }
}
