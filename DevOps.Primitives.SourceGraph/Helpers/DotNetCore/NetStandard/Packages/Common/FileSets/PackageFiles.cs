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
            in NuGetPackageSpecification packageSpecification,
            in string authorEmail,
            in string packageCacheUri,
            in string appveyorAzureStorageSecret,
            in IEnumerable<NuGetReference> nuGetReferences = default)
            => NetStandardRepo(
                packageSpecification.Name,
                in authorEmail,
                packageSpecification.Authors,
                in nuGetReferences,
                packageSpecification.GetPackageInfo())
                .Concat(
                    NuGetFiles(packageCacheUri, packageSpecification.NamespacePrefix, authorEmail, appveyorAzureStorageSecret, packageSpecification.Version));


        public static IEnumerable<RepositoryFile> Package(
            in NuGetPackageSpecification packageSpecification,
            in string authorEmail,
            in string packageCacheUri,
            in string appveyorAzureStorageSecret,
            in IEnumerable<NuGetReference> nuGetReferences = default,
            in IDictionary<string, string> environmentVariables = default,
            params TypeDeclaration[] types)
            => NetStandardRepo(
                packageSpecification.Name,
                in authorEmail,
                packageSpecification.Authors,
                in nuGetReferences,
                packageSpecification.GetPackageInfo(),
                in environmentVariables,
                types)
                .Concat(
                    NuGetFiles(packageCacheUri, packageSpecification.NamespacePrefix, authorEmail, appveyorAzureStorageSecret, packageSpecification.Version));

        public static IEnumerable<RepositoryFile> Package(
            in NuGetPackageSpecification packageSpecification,
            in string authorEmail,
            in string packageCacheUri,
            in string appveyorAzureStorageSecret,
            in IEnumerable<NuGetReference> nuGetReferences = default,
            in IDictionary<string, string> environmentVariables = default,
            params RepositoryFile[] files)
            => NetStandardRepo(
                packageSpecification.Name,
                in authorEmail,
                packageSpecification.Authors,
                in nuGetReferences,
                packageSpecification.GetPackageInfo(),
                in environmentVariables,
                files)
                .Concat(
                    NuGetFiles(packageCacheUri, packageSpecification.NamespacePrefix, authorEmail, appveyorAzureStorageSecret, packageSpecification.Version));

        private static IEnumerable<RepositoryFile> NuGetFiles(
            string packageCacheUri,
            string namespacePrefix,
            string authorEmail,
            string appveyorAzureStorageSecret,
            string version)
        {
            yield return AppveyorYml(in packageCacheUri, in namespacePrefix, in authorEmail, in appveyorAzureStorageSecret, in version);
            yield return NuGetConfig();
        }
    }
}
