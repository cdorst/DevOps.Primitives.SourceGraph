using DevOps.Primitives.Strings;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.SourceGraph
{
    [ProtoContract]
    [Table("GitHubAccounts", Schema = nameof(SourceGraph))]
    public class GitHubAccount
    {
        [Key]
        [ProtoMember(1)]
        public int GitHubAccountId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference AccountName { get; set; }
        [ProtoMember(3)]
        public int AccountNameId { get; set; }

        [ProtoMember(4)]
        public RepositoryList RepositoryList { get; set; }
    }
}
