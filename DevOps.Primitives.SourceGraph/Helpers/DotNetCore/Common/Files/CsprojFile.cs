using DevOps.Primitives.NuGet;
using DevOps.Primitives.VisualStudio.Projects;
using DevOps.Primitives.VisualStudio.Projects.Helpers.DotNetCore;
using System.Collections.Generic;
using static DevOps.Primitives.VisualStudio.Projects.Helpers.DotNetCore.DotNetCoreProjects;
using static DevOps.Primitives.VisualStudio.Solutions.Helpers.VisualStudio15.Vs15Solutions;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.Common.Files
{
    public static class CsprojFile
    {
        public static RepositoryFile Csproj(Project project)
            => csproj(
                project.MsBuildProjectFile.GetProjectFile(),
                project.Name.Value);

        public static RepositoryFile Csproj(
            string name,
            string targetFramework,
            IEnumerable<NuGetReference> nuGetReferences = null,
            IEnumerable<ProjectReference> projectReferences = null,
            NuGetPackageInfo nuGetPackageInfo = null)
            => Csproj(
                Create(name, targetFramework, nuGetReferences, projectReferences, nuGetPackageInfo));

        private static RepositoryFile csproj(string project, string name)
            => new RepositoryFile($"{name}.csproj", project, name);
    }
}
