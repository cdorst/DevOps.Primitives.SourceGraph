namespace DevOps.Primitives.SourceGraph.Helpers.Common.Accounts
{
    public static class GitHubAccounts
    {
        public static GitHubAccount GitHubAccount(GitHubAccountSpecification specification)
            => GitHubAccount(
                specification.AccountName,
                specification.AppveyorAzureStorageSecret,
                specification.AuthorEmail,
                specification.AuthorFullName,
                specification.Copyright,
                specification.PackageCacheUrl,
                specification.PackageIconUrl,
                specification.NamespacePrefix);

        public static GitHubAccount GitHubAccount(
            in string accountName,
            in string appveyorAzureStorageSecret,
            in string authorEmail,
            in string authorFullName,
            in string copyright,
            in string packageCacheUri,
            in string packageIconUri,
            in string namespacePrefix)
            => new GitHubAccount(
                new AccountSettings(
                    new GitHubAccountSettings(
                        in accountName,
                        new GitCommitSettings(
                            in authorEmail,
                            in authorFullName)),
                    new NuGetPackageSettings(
                        new NuGetPackageCacheCopyrightSettings(
                            in copyright,
                            in appveyorAzureStorageSecret,
                            in packageCacheUri),
                        new NuGetPackageIconNamespaceSettings(
                            in packageIconUri,
                            in namespacePrefix))));
    }
}
