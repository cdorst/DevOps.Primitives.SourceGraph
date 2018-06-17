namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.FileSets
{
    public class ReusablePackageSpecification
    {
        public ReusablePackageSpecification() { }
        public ReusablePackageSpecification(
            in string account,
            in string copyright,
            in string email,
            in string namespacePrefix,
            in string packageCacheUrl,
            in string packageIconUrl,
            in string appveyorAzureStorageSecret)
        {
            AppveyorAzureStorageSecret = appveyorAzureStorageSecret;
            AuthorEmail = email;
            Copyright = copyright;
            GitHubAndNuGetAccount = account;
            NamespacePrefix = namespacePrefix;
            PackageCacheUrl = packageCacheUrl;
            PackageIconUrl = packageIconUrl;
        }
        public ReusablePackageSpecification(
            in string account,
            in GitCommitSettings gitCommitSettings,
            in NuGetPackageCacheCopyrightSettings nuGetPackageCacheCopyrightSettings,
            in NuGetPackageIconNamespaceSettings nuGetPackageIconNamespaceSettings)
            : this(
                  in account,
                  nuGetPackageCacheCopyrightSettings.Copyright.Value,
                  gitCommitSettings.Email.Value,
                  nuGetPackageIconNamespaceSettings.NamespacePrefix.Value,
                  nuGetPackageCacheCopyrightSettings.NuGetPackageCacheSettings.PackageCacheUrl.Value,
                  nuGetPackageIconNamespaceSettings.PackageIconUrl.Value,
                  nuGetPackageCacheCopyrightSettings.NuGetPackageCacheSettings.AppveyorAzureStorageSecret.Value)
        {
        }
        public ReusablePackageSpecification(in GitHubAccountSettings gitHubAccountSettings, in NuGetPackageSettings nuGetPackageSettings)
            : this(
                  gitHubAccountSettings.AccountName.Value,
                  gitHubAccountSettings.GitCommitSettings,
                  nuGetPackageSettings.NuGetPackageCacheCopyrightSettings,
                  nuGetPackageSettings.NuGetPackageIconNamespaceSettings)
        {
        }
        public ReusablePackageSpecification(in AccountSettings account)
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
