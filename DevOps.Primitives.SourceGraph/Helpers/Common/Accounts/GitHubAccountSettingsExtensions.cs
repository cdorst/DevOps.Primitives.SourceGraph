using DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.FileSets;

namespace DevOps.Primitives.SourceGraph.Helpers.Common.Accounts
{
    public static class GitHubAccountSettingsExtensions
    {
        public static ReusablePackageSpecification GetPackageSpecification(this AccountSettings settings)
            => new ReusablePackageSpecification(settings);
    }
}
