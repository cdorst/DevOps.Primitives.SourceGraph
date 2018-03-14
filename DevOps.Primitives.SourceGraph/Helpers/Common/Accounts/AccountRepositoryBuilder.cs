using System;
using System.Linq;
using static Common.Functions.CheckNullableEnumerationForAnyElements.NullableEnumerationAny;

namespace DevOps.Primitives.SourceGraph.Helpers.Common.Accounts
{
    public static class AccountRepositoryBuilder
    {
        public static GitHubAccount WithRepositories(this GitHubAccount account,
            params Func<GitHubAccount, Repository>[] repositories)
        {
            if (!Any(repositories)) return account;
            foreach (var repository in repositories.Select(r => r(account))) account = account.AddRepository(repository);
            return account;
        }
    }
}
