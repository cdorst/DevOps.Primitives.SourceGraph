using ProtoBuf;

namespace DevOps.Primitives.SourceGraph.Files
{
    [ProtoContract]
    public class GitAttributesFile : RepositoryFile
    {
        private const string Name = ".gitattributes";

        public GitAttributesFile() { }
        public GitAttributesFile(string content)
            : base(Name, content, $"/{Name}")
        {
        }
    }
}
