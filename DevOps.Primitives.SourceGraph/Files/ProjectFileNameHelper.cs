using DevOps.Primitives.VisualStudio.Projects;
using static DevOps.Primitives.SourceGraph.Files.ProjectNameHelper;

namespace DevOps.Primitives.SourceGraph.Files
{
    internal static class ProjectFileNameHelper
    {
        public static string FileName(Project project)
            => $"{ProjectName(project)}.csproj";
    }
}
