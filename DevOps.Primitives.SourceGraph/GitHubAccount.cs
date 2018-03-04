using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DevOps.Primitives.SourceGraph
{
    [ProtoContract]
    [Table("GitHubAccounts", Schema = nameof(SourceGraph))]
    public class GitHubAccount
    {
        public GitHubAccount() { }
        public GitHubAccount(GitHubAccountSettings gitHubAccountSettings, RepositoryList repositoryList)
        {
            GitHubAccountSettings = gitHubAccountSettings;
            RepositoryList = repositoryList;
        }
        public GitHubAccount(string accountName, string email, string committerName, RepositoryList repositoryList)
            : this(new GitHubAccountSettings(accountName, email, committerName), repositoryList)
        {
        }
        public GitHubAccount(string accountName, string email, string committerName, params Repository[] repositories)
            : this(accountName, email, committerName,
                  new RepositoryList(repositories.Select(r
                      => new RepositoryListAssociation(r)).ToList()))
        {
        }

        [Key]
        [ProtoMember(1)]
        public int GitHubAccountId { get; set; }

        [ProtoMember(2)]
        public GitHubAccountSettings GitHubAccountSettings { get; set; }
        [ProtoMember(3)]
        public int GitHubAccountSettingsId { get; set; }

        [ProtoMember(4)]
        public RepositoryList RepositoryList { get; set; }
        [ProtoMember(5)]
        public int RepositoryListId { get; set; }
    }
}
