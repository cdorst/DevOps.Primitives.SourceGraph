using ProtoBuf;

namespace DevOps.Primitives.SourceGraph.Files
{
    [ProtoContract]
    public class LicenseFile : RepositoryFile
    {
        private const string Name = "LICENSE";

        public LicenseFile() { }
        public LicenseFile(string content)
            : base(Name, content, $"/{Name}")
        {
        }
    }
}
