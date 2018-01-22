using DevOps.Primitives.VisualStudio.Projects;
using static DevOps.Primitives.SourceGraph.Files.ProjectNameHelper;
using static DevOps.Primitives.SourceGraph.Files.ProjectFileNameHelper;
using static DevOps.Primitives.SourceGraph.Files.ProjectFolderHelper;

namespace DevOps.Primitives.SourceGraph.Files
{
    internal static class ProjectPathHelper
    {
        public static string ProjectPath(Project project, ProjectType projectType)
            => $"/{ProjectFolder(projectType)}/{ProjectName(project)}/{FileName(project)}";
    }
}
