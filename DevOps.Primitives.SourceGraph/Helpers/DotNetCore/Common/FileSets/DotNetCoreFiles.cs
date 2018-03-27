using DevOps.Primitives.CSharp;
using DevOps.Primitives.NuGet;
using DevOps.Primitives.VisualStudio.Projects;
using DevOps.Primitives.VisualStudio.Projects.Helpers.DotNetCore;
using DevOps.Primitives.VisualStudio.Solutions;
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
            string name,
            string targetFramework,
            string emailAddress,
            string accountName,
            IEnumerable<NuGetReference> nuGetReferences = null,
            NuGetPackageInfo nuGetPackageInfo = null,
            IDictionary<string, string> environmentVariables = null,
            params TypeDeclaration[] types)
            => StandardGitRepo(accountName, emailAddress).Concat(
                Files(name, targetFramework, nuGetReferences, nuGetPackageInfo, types, environmentVariables));

        public static IEnumerable<RepositoryFile> DotNetCoreRepo(
            string name,
            string targetFramework,
            string emailAddress,
            string accountName,
            IEnumerable<NuGetReference> nuGetReferences = null,
            NuGetPackageInfo nuGetPackageInfo = null,
            IDictionary<string, string> environmentVariables = null,
            params RepositoryFile[] files)
            => StandardGitRepo(accountName, emailAddress)
                .Concat(Files(name, targetFramework, nuGetReferences, nuGetPackageInfo, null, environmentVariables))
                .Concat(files ?? new RepositoryFile[] { });

        private static IEnumerable<RepositoryFile> Files(
            string name,
            string targetFramework,
            IEnumerable<NuGetReference> nuGetReferences,
            NuGetPackageInfo nuGetPackageInfo,
            IEnumerable<TypeDeclaration> types = null,
            IDictionary<string, string> environmentVariables = null)
        {
            yield return Readme(name, nuGetReferences, nuGetPackageInfo,
                (environmentVariables ?? _emptyDictionary)
                    .Merge(LOCAL_NUGET_SOURCE_PATH));
            yield return Solution(name);
            yield return Csproj(name, targetFramework, nuGetReferences, nuGetPackageInfo: nuGetPackageInfo);
            foreach (var type in types ?? new TypeDeclaration[] { })
                yield return Code(type, nuGetPackageInfo.Copyright);
        }
    }
}
