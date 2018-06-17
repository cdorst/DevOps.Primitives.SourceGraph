using DevOps.Primitives.CSharp;
using DevOps.Primitives.NuGet;
using DevOps.Primitives.VisualStudio.Projects.Helpers.DotNetCore;
using System.Collections.Generic;
using System.Linq;
using static DevOps.Primitives.SourceGraph.Helpers.Common.Files.ReadmeFile;
using static DevOps.Primitives.SourceGraph.Helpers.Common.FileSets.CommonGitRepoFiles;
using static DevOps.Primitives.SourceGraph.Helpers.DotNetCore.Common.EnvironmentVariables.SolutionEnvironmentVariables;
using static DevOps.Primitives.SourceGraph.Helpers.DotNetCore.Common.Files.CSharpCode;
using static DevOps.Primitives.SourceGraph.Helpers.DotNetCore.Common.Files.CsprojFile;
using static DevOps.Primitives.SourceGraph.Helpers.DotNetCore.Common.Files.SlnFile;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.Common.FileSets
{
    public static class DotNetCoreFiles
    {
        private static readonly IDictionary<string, string> _emptyDictionary = new Dictionary<string, string>();

        public static IEnumerable<RepositoryFile> DotNetCoreRepo(
            in string name,
            in string targetFramework,
            in string emailAddress,
            in string accountName,
            in IEnumerable<NuGetReference> nuGetReferences = default,
            in NuGetPackageInfo nuGetPackageInfo = default,
            in IDictionary<string, string> environmentVariables = default,
            params TypeDeclaration[] types)
            => StandardGitRepo(accountName, emailAddress).Concat(
                Files(name, targetFramework, nuGetReferences, nuGetPackageInfo, types, environmentVariables));

        public static IEnumerable<RepositoryFile> DotNetCoreRepo(
            in string name,
            in string targetFramework,
            in string emailAddress,
            in string accountName,
            in IEnumerable<NuGetReference> nuGetReferences = default,
            in NuGetPackageInfo nuGetPackageInfo = default,
            in IDictionary<string, string> environmentVariables = default,
            params RepositoryFile[] files)
            => StandardGitRepo(accountName, emailAddress)
                .Concat(Files(name, targetFramework, nuGetReferences, nuGetPackageInfo, null, environmentVariables))
                .Concat(files ?? new RepositoryFile[] { });

        private static IEnumerable<RepositoryFile> Files(
            string name,
            string targetFramework,
            IEnumerable<NuGetReference> nuGetReferences,
            NuGetPackageInfo nuGetPackageInfo,
            IEnumerable<TypeDeclaration> types = default,
            IDictionary<string, string> environmentVariables = default)
        {
            yield return Readme(in name, in nuGetReferences, in nuGetPackageInfo,
                (environmentVariables ?? _emptyDictionary)
                    .Merge(LOCAL_NUGET_SOURCE_PATH));
            yield return Solution(in name);
            yield return Csproj(in name, in targetFramework, in nuGetReferences, nuGetPackageInfo: in nuGetPackageInfo);
            foreach (var type in types ?? new TypeDeclaration[] { })
                yield return Code(in type, nuGetPackageInfo.Copyright);
        }
    }
}
