namespace DevOps.Primitives.SourceGraph.Helpers.Common.Accounts
{
    public class GitHubAccountSpecification
    {
        public GitHubAccountSpecification(
            string accountName,
            string appveyorAzureStorageSecret,
            string authorEmail,
            string authorFullName,
            string copyright,
            string packageCacheUri,
            string packageIconUri,
            string namespacePrefix)
        {
            AccountName = accountName;
            AppveyorAzureStorageSecret = appveyorAzureStorageSecret;
            AuthorEmail = authorEmail;
            AuthorFullName = authorFullName;
            Copyright = copyright;
            PackageCacheUrl = packageCacheUri;
            PackageIconUrl = packageIconUri;
            NamespacePrefix = namespacePrefix;
        }

        public string AccountName { get; set; }
        public string AppveyorAzureStorageSecret { get; set; }
        public string AuthorEmail { get; set; }
        public string AuthorFullName { get; set; }
        public string Copyright { get; set; }
        public string PackageCacheUrl { get; set; }
        public string PackageIconUrl { get; set; }
        public string NamespacePrefix { get; set; }
    }
}
