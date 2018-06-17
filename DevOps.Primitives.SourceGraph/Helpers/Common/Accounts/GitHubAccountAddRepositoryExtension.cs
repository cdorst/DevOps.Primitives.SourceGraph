using Common.EntityFrameworkServices;

namespace DevOps.Primitives.SourceGraph.Helpers.Common.Accounts
{
    public static class GitHubAccountAddRepositoryExtension
    {
        public static GitHubAccount AddRepository(this GitHubAccount account, in Repository repository)
        {
            account.RepositoryList = account.RepositoryList
                .Merge<RepositoryList, Repository, RepositoryListAssociation>(
                    new RepositoryList(repository),
                    RepositoryNameEqualityComparer.Default);
            return account;
        }
    }
}
