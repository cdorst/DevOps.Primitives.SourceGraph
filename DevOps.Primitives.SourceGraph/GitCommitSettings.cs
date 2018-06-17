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
        public GitCommitSettings(in AsciiStringReference email, in AsciiStringReference name)
        {
            Email = email;
            Name = name;
        }
        public GitCommitSettings(in string email, in string name)
            : this(new AsciiStringReference(in email), new AsciiStringReference(in name))
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
