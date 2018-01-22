using DevOps.Primitives.VisualStudio.Projects;
using static DevOps.Primitives.SourceGraph.Files.Helpers.ProjectNameHelper;

namespace DevOps.Primitives.SourceGraph.Files.Helpers
{
    internal static class ProjectFileNameHelper
    {
        public static string FileName(Project project)
            => $"{ProjectName(project)}.csproj";
    }
}
