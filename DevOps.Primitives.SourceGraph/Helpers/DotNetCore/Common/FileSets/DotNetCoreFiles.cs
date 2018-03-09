using DevOps.Primitives.CSharp;
using DevOps.Primitives.NuGet;
using DevOps.Primitives.VisualStudio.Projects;
using DevOps.Primitives.VisualStudio.Projects.Helpers.DotNetCore;
using DevOps.Primitives.VisualStudio.Solutions;
using System.Collections.Generic;
using System.Linq;
using static DevOps.Primitives.SourceGraph.Helpers.Common.FileSets.CommonGitRepoFiles;
using static DevOps.Primitives.SourceGraph.Helpers.DotNetCore.Common.Files.CSharpCode;
using static DevOps.Primitives.SourceGraph.Helpers.DotNetCore.Common.Files.CsprojFile;
using static DevOps.Primitives.SourceGraph.Helpers.DotNetCore.Common.Files.SlnFile;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.Common.FileSets
{
    public static class DotNetCoreFiles
    {
        public static IEnumerable<RepositoryFile> DotNetCoreRepo(
            Solution solution,
            Project project,
            IEnumerable<TypeDeclaration> types)
            => StandardGitRepo().Concat(Files(solution, project, types));

        public static IEnumerable<RepositoryFile> DotNetCoreRepo(
            Solution solution,
            Project project,
            IEnumerable<RepositoryFile> types)
            => StandardGitRepo()
                .Concat(Files(solution, project))
                .Concat(types);

        public static IEnumerable<RepositoryFile> DotNetCoreRepo(
            string name,
            string targetFramework,
            IEnumerable<NuGetReference> nuGetReferences = null,
            NuGetPackageInfo nuGetPackageInfo = null,
            params TypeDeclaration[] types)
            => StandardGitRepo().Concat(
                Files(name, targetFramework, nuGetReferences, nuGetPackageInfo, types));

        public static IEnumerable<RepositoryFile> DotNetCoreRepo(
            string name,
            string targetFramework,
            IEnumerable<NuGetReference> nuGetReferences = null,
            NuGetPackageInfo nuGetPackageInfo = null,
            params RepositoryFile[] files)
            => StandardGitRepo()
                .Concat(Files(name, targetFramework, nuGetReferences, nuGetPackageInfo))
                .Concat(files);

        private static IEnumerable<RepositoryFile> Files(
            Solution solution,
            Project project,
            IEnumerable<TypeDeclaration> types = null)
        {
            yield return Solution(solution);
            yield return Csproj(project);
            foreach (var type in types ?? new TypeDeclaration[] { })
                yield return Code(type);
        }

        private static IEnumerable<RepositoryFile> Files(
            string name,
            string targetFramework,
            IEnumerable<NuGetReference> nuGetReferences,
            NuGetPackageInfo nuGetPackageInfo,
            IEnumerable<TypeDeclaration> types = null)
        {
            yield return Solution(name);
            yield return Csproj(name, targetFramework, nuGetReferences, nuGetPackageInfo: nuGetPackageInfo);
            foreach (var type in types ?? new TypeDeclaration[] { })
                yield return Code(type);
        }
    }
}
