using DevOps.Primitives.CSharp;
using DevOps.Primitives.NuGet;
using DevOps.Primitives.VisualStudio.Projects.Helpers.DotNetCore;
using System.Collections.Generic;
using static DevOps.Primitives.SourceGraph.Helpers.DotNetCore.Common.FileSets.DotNetCoreFiles;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Common.FileSets
{
    public static class NetStandardFiles
    {
        private static readonly string TargetFramework = "netstandard2.0";

        public static IEnumerable<RepositoryFile> NetStandardRepo(
            in string name,
            in string emailAddress,
            in string accountName,
            in IEnumerable<NuGetReference> nuGetReferences = default,
            in NuGetPackageInfo nuGetPackageInfo = default,
            in IDictionary<string, string> environmentVariables = default)
            => DotNetCoreRepo(in name, in TargetFramework, in emailAddress, in accountName, in nuGetReferences, in nuGetPackageInfo, in environmentVariables, types: default);

        public static IEnumerable<RepositoryFile> NetStandardRepo(
            in string name,
            in string emailAddress,
            in string accountName,
            in IEnumerable<NuGetReference> nuGetReferences = default,
            in NuGetPackageInfo nuGetPackageInfo = default,
            in IDictionary<string, string> environmentVariables = default,
            params TypeDeclaration[] types)
            => DotNetCoreRepo(in name, in TargetFramework, in emailAddress, in accountName, in nuGetReferences, in nuGetPackageInfo, in environmentVariables, types);

        public static IEnumerable<RepositoryFile> NetStandardRepo(
            in string name,
            in string emailAddress,
            in string accountName,
            in IEnumerable<NuGetReference> nuGetReferences = default,
            in NuGetPackageInfo nuGetPackageInfo = default,
            in IDictionary<string, string> environmentVariables = default,
            params RepositoryFile[] types)
            => DotNetCoreRepo(in name, in TargetFramework, in emailAddress, in accountName, in nuGetReferences, in nuGetPackageInfo, in environmentVariables, types);
    }
}
