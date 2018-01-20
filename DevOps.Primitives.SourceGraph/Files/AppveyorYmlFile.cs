using ProtoBuf;

namespace DevOps.Primitives.SourceGraph.Files
{
    [ProtoContract]
    public class AppveyorYmlFile : RepositoryFile
    {
        private const string Name = "appveyor.yml";

        public AppveyorYmlFile() { }
        public AppveyorYmlFile(string content)
            : base(Name, content, $"/{Name}")
        {
        }
    }
}
