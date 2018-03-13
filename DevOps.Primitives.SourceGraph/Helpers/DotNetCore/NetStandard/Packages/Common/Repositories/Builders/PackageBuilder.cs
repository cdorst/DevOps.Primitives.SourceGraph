using DevOps.Primitives.NuGet;
using System;
using System.Collections.Generic;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.Repositories.Builders
{
    public static class PackageBuilder
    {
        public static Func<GitHubAccount, Repository> Code(
            CodeTypeSpecification codeTypeSpecification,
            List<NuGetReference> dependencies,
            IDictionary<string, string> environmentVariables = null)
            => account
                => PackageRepositories.Code(codeTypeSpecification, dependencies, account, environmentVariables);

        public static Func<GitHubAccount, Repository> Metapackage(
            string projectName,
            string description,
            string version,
            List<NuGetReference> dependencies,
            IDictionary<string, string> environmentVariables = null)
            => account
                => PackageRepositories.Metapackage(projectName, description, version, dependencies, account, environmentVariables);
    }
}
