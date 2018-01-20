using ProtoBuf;

namespace DevOps.Primitives.SourceGraph.Files
{
    [ProtoContract]
    public class CsprojFile : RepositoryFile
    {
        public CsprojFile() : base() { }
        public CsprojFile(ProjectType projectType, string fileName, string content, string relativePath)
            : base(fileName, content, relativePath)
        {
            ProjectType = projectType;
        }

        [ProtoMember(8)]
        public ProjectType ProjectType { get; set; }
    }
}
