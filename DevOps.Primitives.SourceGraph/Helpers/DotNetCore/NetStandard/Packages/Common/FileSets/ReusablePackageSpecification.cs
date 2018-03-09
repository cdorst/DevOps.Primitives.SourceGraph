namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.FileSets
{
    public class ReusablePackageSpecification
    {
        public ReusablePackageSpecification() { }
        public ReusablePackageSpecification(string account, string copyright, string email, string namespacePrefix, string packageCacheUrl, string packageIconUrl, string appveyorAzureStorageSecret)
        {
            AppveyorAzureStorageSecret = appveyorAzureStorageSecret;
            AuthorEmail = email;
            Copyright = copyright;
            GitHubAndNuGetAccount = account;
            NamespacePrefix = namespacePrefix;
            PackageCacheUrl = packageCacheUrl;
            PackageIconUrl = packageIconUrl;
        }
        public ReusablePackageSpecification(string account, GitCommitSettings gitCommitSettings, NuGetPackageCacheCopyrightSettings nuGetPackageCacheCopyrightSettings, NuGetPackageIconNamespaceSettings nuGetPackageIconNamespaceSettings)
            : this(account, nuGetPackageCacheCopyrightSettings.Copyright.Value, gitCommitSettings.Email.Value, nuGetPackageIconNamespaceSettings.NamespacePrefix.Value, nuGetPackageCacheCopyrightSettings.NuGetPackageCacheSettings.PackageCacheUrl.Value, nuGetPackageIconNamespaceSettings.PackageIconUrl.Value, nuGetPackageCacheCopyrightSettings.NuGetPackageCacheSettings.AppveyorAzureStorageSecret.Value)
        {
        }
        public ReusablePackageSpecification(GitHubAccountSettings gitHubAccountSettings, NuGetPackageSettings nuGetPackageSettings)
            : this(gitHubAccountSettings.AccountName.Value, gitHubAccountSettings.GitCommitSettings, nuGetPackageSettings.NuGetPackageCacheCopyrightSettings, nuGetPackageSettings.NuGetPackageIconNamespaceSettings)
        {
        }
        public ReusablePackageSpecification(AccountSettings account)
            : this(account.GitHubAccountSettings, account.NuGetPackageSettings)
        {
        }

        public string AppveyorAzureStorageSecret { get; set; }
        public string AuthorEmail { get; set; }
        public string Copyright { get; set; }
        public string GitHubAndNuGetAccount { get; set; }
        public string NamespacePrefix { get; set; }
        public string PackageCacheUrl { get; set; }
        public string PackageIconUrl { get; set; }
    }
}
