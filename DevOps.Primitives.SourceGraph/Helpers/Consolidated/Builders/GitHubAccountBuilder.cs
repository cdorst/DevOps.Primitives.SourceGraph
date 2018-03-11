using DevOps.Primitives.SourceGraph.Helpers.Common.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using static DevOps.Primitives.SourceGraph.Helpers.Common.Accounts.AccountRepositoryBuilder;

namespace DevOps.Primitives.SourceGraph.Helpers.Consolidated.Builders
{
    public static class GitHubAccountBuilder
    {
        private static Func<GitHubAccount, Repository>[] Empty = new Func<GitHubAccount, Repository>[] { };

        public static GitHubAccount GitHub(
            GitHubAccountSpecification account,
            IEnumerable<Func<GitHubAccount, Repository>> repositories)
            => GitHubAccounts.GitHubAccount(account)
                .WithRepositories(repositories?.ToArray() ?? Empty);

        public static GitHubAccount GitHub(
            GitHubAccountSpecification account,
            IEnumerable<Code> code)
            => GitHub(account,
                code.Select(each => each.GetBuilder()));

        public static GitHubAccount GitHub(
            GitHubAccountSpecification account,
            IEnumerable<Entity> entities)
            => GitHub(account,
                entities?.Select(entity => entity.GetBuilder()));

        public static GitHubAccount GitHub(
            GitHubAccountSpecification account,
            IEnumerable<Code> code,
            IEnumerable<Entity> entities)
            => GitHub(account, code)
                .WithRepositories(
                    entities?.Select(entity => entity.GetBuilder()).ToArray() ?? Empty);

        public static GitHubAccount GitHub(
            GitHubAccountSpecification account,
            IEnumerable<Code> code,
            IEnumerable<Entity> entities,
            IEnumerable<Metapackage> metapackages)
            => GitHub(account, code, entities)
                .WithRepositories(
                    metapackages?.Select(package => package.GetBuilder()).ToArray() ?? Empty);
    }
}
