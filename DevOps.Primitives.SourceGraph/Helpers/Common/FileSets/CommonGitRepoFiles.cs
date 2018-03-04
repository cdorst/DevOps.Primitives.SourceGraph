using System.Collections.Generic;
using static DevOps.Primitives.SourceGraph.Helpers.Common.Files.GitAttributesFile;
using static DevOps.Primitives.SourceGraph.Helpers.Common.Files.GitIgnoreFile;
using static DevOps.Primitives.SourceGraph.Helpers.Common.Files.GnuGpl3License;

namespace DevOps.Primitives.SourceGraph.Helpers.Common.FileSets
{
    public static class CommonGitRepoFiles
    {
        public static IEnumerable<RepositoryFile> StandardGitRepo()
        {
            yield return GitAttributes();
            yield return GitIgnore();
            yield return License();
        }
    }
}
