using System;
using System.Linq;

namespace DevOps.Primitives.SourceGraph.Helpers.Common.Accounts
{
    public static class AccountRepositoryBuilder
    {
        public static GitHubAccount WithRepositories(this GitHubAccount account,
            params Func<GitHubAccount, Repository>[] repositories)
        {
            foreach (var repository in repositories.Select(r => r(account))) account = account.AddRepository(repository);
            return account;
        }
    }
}
