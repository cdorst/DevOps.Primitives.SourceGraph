using System.Linq;
using static DevOps.Primitives.SourceGraph.Helpers.Common.FileSets.CommonGitRepoFiles;

namespace DevOps.Primitives.SourceGraph.Helpers.Common.Repositories
{
    public static class FileRepositories
    {
        public static Repository Repository(string name, string description, string version, params RepositoryFile[] files)
            => new Repository(name, description, version, null,
                new RepositoryFileList(
                    StandardGitRepo().Concat(files).ToArray()));
    }
}
