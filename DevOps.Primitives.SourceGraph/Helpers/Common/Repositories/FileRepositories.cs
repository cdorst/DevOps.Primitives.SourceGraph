using System.Linq;
using static DevOps.Primitives.SourceGraph.Helpers.Common.FileSets.CommonGitRepoFiles;

namespace DevOps.Primitives.SourceGraph.Helpers.Common.Repositories
{
    public static class FileRepositories
    {
        public static Repository Repository(
            in string name,
            in string description,
            in string version,
            in string emailAddress,
            in string accountName,
            params RepositoryFile[] files)
            => new Repository(
                in name,
                in description,
                in version,
                null,
                new RepositoryFileList(
                    StandardGitRepo(accountName, emailAddress).Concat(files).ToArray()));
    }
}
