using Common.EntityFrameworkServices;
using System;
using System.Linq;
using static DevOps.Primitives.SourceGraph.RepositoryNameEqualityComparer;

namespace DevOps.Primitives.SourceGraph.Helpers.Common.Accounts
{
    public static class AccountRepositoryBuilder
    {
        public static GitHubAccount WithRepositories(this GitHubAccount account,
            params Func<GitHubAccount, Repository>[] repositories)
            => new GitHubAccount(account.AccountSettings,
                new RepositoryList(repositories
                    .Select(repo => repo(account))
                    .Concat(
                        account.RepositoryList?.GetRecords() ?? new Repository[] { })
                    .Distinct(RepositoryName)
                    .Order()
                    .Select(repo => new RepositoryListAssociation(repo)).ToList()));
    }
}
