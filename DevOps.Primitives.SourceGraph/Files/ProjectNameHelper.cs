using DevOps.Primitives.VisualStudio.Projects;

namespace DevOps.Primitives.SourceGraph.Files
{
    internal static class ProjectNameHelper
    {
        public static string ProjectName(Project project)
            => project.Name.Value;
    }
}
