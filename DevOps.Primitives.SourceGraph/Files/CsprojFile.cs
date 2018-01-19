using ProtoBuf;

namespace DevOps.Primitives.SourceGraph.Files
{
    [ProtoContract]
    public class CsprojFile : RepositoryFile
    {
        [ProtoMember(8)]
        public ProjectType ProjectType { get; set; }
    }
}
