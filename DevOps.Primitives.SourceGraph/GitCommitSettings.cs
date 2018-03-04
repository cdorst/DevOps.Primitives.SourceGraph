using DevOps.Primitives.Strings;
using ProtoBuf;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.SourceGraph
{
    [ProtoContract]
    [Table("GitCommitSettings", Schema = nameof(SourceGraph))]
    public class GitCommitSettings
    {
        public GitCommitSettings() { }
        public GitCommitSettings(AsciiStringReference email, AsciiStringReference name)
        {
            Email = email;
            Name = name;
        }
        public GitCommitSettings(string email, string name)
            : this(new AsciiStringReference(email), new AsciiStringReference(name))
        {
        }

        [ProtoMember(1)]
        public int GitCommitSettingsId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference Email { get; set; }
        [ProtoMember(3)]
        public int EmailId { get; set; }

        [ProtoMember(4)]
        public AsciiStringReference Name { get; set; }
        [ProtoMember(5)]
        public int NameId { get; set; }
    }
}
