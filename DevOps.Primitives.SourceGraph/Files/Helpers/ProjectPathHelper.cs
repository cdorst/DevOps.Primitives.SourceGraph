using DevOps.Primitives.VisualStudio.Projects;
using static DevOps.Primitives.SourceGraph.Files.Helpers.ProjectNameHelper;
using static DevOps.Primitives.SourceGraph.Files.Helpers.ProjectFileNameHelper;
using static DevOps.Primitives.SourceGraph.Files.Helpers.ProjectFolderHelper;

namespace DevOps.Primitives.SourceGraph.Files.Helpers
{
    internal static class ProjectPathHelper
    {
        public static string ProjectPath(Project project, ProjectType projectType)
            => $"/{ProjectFolder(projectType)}/{ProjectName(project)}/{FileName(project)}";
    }
}
