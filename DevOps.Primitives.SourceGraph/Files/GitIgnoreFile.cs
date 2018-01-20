using ProtoBuf;

namespace DevOps.Primitives.SourceGraph.Files
{
    [ProtoContract]
    public class GitIgnoreFile : RepositoryFile
    {
        private const string Name = ".gitignore";

        public GitIgnoreFile() { }
        public GitIgnoreFile(string content)
            : base(Name, content, $"/{Name}")
        {
        }
    }
}
