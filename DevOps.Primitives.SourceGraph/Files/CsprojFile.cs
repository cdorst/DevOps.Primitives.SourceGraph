using DevOps.Primitives.VisualStudio.Projects;
using ProtoBuf;
using static DevOps.Primitives.SourceGraph.Files.ProjectFileNameHelper;
using static DevOps.Primitives.SourceGraph.Files.ProjectPathHelper;

namespace DevOps.Primitives.SourceGraph.Files
{
    [ProtoContract]
    public class CsprojFile : RepositoryFile
    {
        public CsprojFile() : base() { }
        public CsprojFile(ProjectType projectType, Project project)
            : base(
                  fileName: FileName(project),
                  content: project.ToString(),
                  relativePath: ProjectPath(project, projectType))
        {
            ProjectType = projectType;
        }

        [ProtoMember(8)]
        public Project Project { get; set; }
        [ProtoMember(9)]
        public int ProjectId { get; set; }

        [ProtoMember(10)]
        public ProjectType ProjectType { get; set; }
    }
}
