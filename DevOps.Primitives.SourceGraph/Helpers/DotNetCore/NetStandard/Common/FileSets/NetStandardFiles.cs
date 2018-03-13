using DevOps.Primitives.CSharp;
using DevOps.Primitives.NuGet;
using DevOps.Primitives.VisualStudio.Projects.Helpers.DotNetCore;
using System.Collections.Generic;
using static DevOps.Primitives.SourceGraph.Helpers.DotNetCore.Common.FileSets.DotNetCoreFiles;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Common.FileSets
{
    public static class NetStandardFiles
    {
        private const string TFM = "netstandard2.0";

        public static IEnumerable<RepositoryFile> NetStandardRepo(
            string name,
            IEnumerable<NuGetReference> nuGetReferences = null,
            NuGetPackageInfo nuGetPackageInfo = null,
            IDictionary<string, string> environmentVariables = null)
            => DotNetCoreRepo(name, TFM, nuGetReferences, nuGetPackageInfo, environmentVariables, types: null);

        public static IEnumerable<RepositoryFile> NetStandardRepo(
            string name,
            IEnumerable<NuGetReference> nuGetReferences = null,
            NuGetPackageInfo nuGetPackageInfo = null,
            IDictionary<string, string> environmentVariables = null,
            params TypeDeclaration[] types)
            => DotNetCoreRepo(name, TFM, nuGetReferences, nuGetPackageInfo, environmentVariables, types);

        public static IEnumerable<RepositoryFile> NetStandardRepo(
            string name,
            IEnumerable<NuGetReference> nuGetReferences = null,
            NuGetPackageInfo nuGetPackageInfo = null,
            IDictionary<string, string> environmentVariables = null,
            params RepositoryFile[] types)
            => DotNetCoreRepo(name, TFM, nuGetReferences, nuGetPackageInfo, environmentVariables, types);
    }
}
