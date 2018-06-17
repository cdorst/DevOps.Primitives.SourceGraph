using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.SourceGraph
{
    [ProtoContract]
    [Table("GitHubAccounts", Schema = nameof(SourceGraph))]
    public class GitHubAccount
    {
        public GitHubAccount() { }
        public GitHubAccount(in AccountSettings accountSettings, in RepositoryList repositoryList = default)
        {
            AccountSettings = accountSettings;
            RepositoryList = repositoryList;
        }

        [Key]
        [ProtoMember(1)]
        public int GitHubAccountId { get; set; }

        [ProtoMember(2)]
        public AccountSettings AccountSettings { get; set; }
        [ProtoMember(3)]
        public int AccountSettingsId { get; set; }

        [ProtoMember(4)]
        public RepositoryList RepositoryList { get; set; }
        [ProtoMember(5)]
        public int RepositoryListId { get; set; }
    }
}
