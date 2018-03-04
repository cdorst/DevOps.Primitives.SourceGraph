using DevOps.Primitives.Strings;
using ProtoBuf;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.SourceGraph
{
    [ProtoContract]
    [Table("GitHubAccountSettings", Schema = nameof(SourceGraph))]
    public class GitHubAccountSettings
    {
        public GitHubAccountSettings() { }
        public GitHubAccountSettings(AsciiStringReference accountName, GitCommitSettings gitCommitSettings)
        {
            AccountName = accountName;
            GitCommitSettings = gitCommitSettings;
        }
        public GitHubAccountSettings(string accountName, GitCommitSettings gitCommitSettings)
            : this(new AsciiStringReference(accountName), gitCommitSettings)
        {
        }
        public GitHubAccountSettings(string accountName, string email, string name)
            : this(accountName, new GitCommitSettings(email, name))
        {
        }

        [ProtoMember(1)]
        public int GitHubAccountSettingsId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference AccountName { get; set; }
        [ProtoMember(3)]
        public int AccountNameId { get; set; }

        [ProtoMember(4)]
        public GitCommitSettings GitCommitSettings { get; set; }
        [ProtoMember(5)]
        public int GitCommitSettingsId { get; set; }
    }
}
