using DevOps.Primitives.NuGet;
using System;
using System.Collections.Generic;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.EntityFramework.Repositories.Builders
{
    public static class EntityBuilder
    {
        public static Func<GitHubAccount, Repository> Entity(
            EntityTypeSpecification entityTypeSpecification,
            List<NuGetReference> dependencies)
            => account
                => EntityRepositories.Entity(
                    entityTypeSpecification, dependencies, account);
    }
}
