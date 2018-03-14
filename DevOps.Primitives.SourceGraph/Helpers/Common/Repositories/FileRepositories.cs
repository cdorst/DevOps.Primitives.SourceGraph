using System.Linq;
using static DevOps.Primitives.SourceGraph.Helpers.Common.FileSets.CommonGitRepoFiles;

namespace DevOps.Primitives.SourceGraph.Helpers.Common.Repositories
{
    public static class FileRepositories
    {
        public static Repository Repository(string name, string description, params RepositoryFile[] files)
            => new Repository(name, description, null,
                new RepositoryFileList(
                    StandardGitRepo().Concat(files).ToArray()));
    }
}
