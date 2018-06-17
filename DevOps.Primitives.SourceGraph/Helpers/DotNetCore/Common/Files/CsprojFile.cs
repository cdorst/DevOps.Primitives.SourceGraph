using DevOps.Primitives.NuGet;
using DevOps.Primitives.VisualStudio.Projects;
using DevOps.Primitives.VisualStudio.Projects.Helpers.DotNetCore;
using System.Collections.Generic;
using static DevOps.Primitives.VisualStudio.Projects.Helpers.DotNetCore.DotNetCoreProjects;
using static DevOps.Primitives.VisualStudio.Solutions.Helpers.VisualStudio15.Vs15Solutions;
using static System.String;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.Common.Files
{
    public static class CsprojFile
    {
        public static RepositoryFile Csproj(in Project project)
            => csproj(
                project.MsBuildProjectFile.GetProjectFile(),
                project.Name.Value);

        public static RepositoryFile Csproj(
            in string name,
            in string targetFramework,
            in IEnumerable<NuGetReference> nuGetReferences = default,
            in IEnumerable<ProjectReference> projectReferences = default,
            in NuGetPackageInfo nuGetPackageInfo = default)
            => Csproj(
                Create(name, targetFramework, nuGetReferences, projectReferences, nuGetPackageInfo));

        private static RepositoryFile csproj(in string project, in string name)
            => new RepositoryFile(Concat(name, ".csproj"), in project, name);
    }
}
