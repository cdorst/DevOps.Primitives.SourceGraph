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
            string accountName,
            string appveyorAzureStorageSecret,
            string authorEmail,
            string authorFullName,
            string copyright,
            string packageCacheUri,
            string packageIconUri,
            string namespacePrefix)
            => new GitHubAccount(
                new AccountSettings(
                    new GitHubAccountSettings(
                        accountName,
                        new GitCommitSettings(
                            authorEmail,
                            authorFullName)),
                    new NuGetPackageSettings(
                        new NuGetPackageCacheCopyrightSettings(
                            copyright,
                            appveyorAzureStorageSecret,
                            packageCacheUri),
                        new NuGetPackageIconNamespaceSettings(
                            packageIconUri,
                            namespacePrefix))));
    }
}
