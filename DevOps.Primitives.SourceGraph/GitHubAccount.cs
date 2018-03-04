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
        public GitHubAccount() { }
        public GitHubAccount(string accountName, RepositoryList repositoryList)
        {
            AccountName = new AsciiStringReference(accountName);
            RepositoryList = repositoryList;
        }

        [Key]
        [ProtoMember(1)]
        public int GitHubAccountId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference AccountName { get; set; }
        [ProtoMember(3)]
        public int AccountNameId { get; set; }

        [ProtoMember(4)]
        public RepositoryList RepositoryList { get; set; }
        [ProtoMember(5)]
        public int RepositoryListId { get; set; }
    }

    public class AppveyorBuild
    {
        [Key]
        [ProtoMember(1)]
        public int AppveyorBuildId { get; set; }
    }
}
