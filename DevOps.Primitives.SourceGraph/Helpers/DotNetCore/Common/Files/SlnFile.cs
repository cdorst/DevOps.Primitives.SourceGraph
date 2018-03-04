using DevOps.Primitives.VisualStudio.Solutions;
using static DevOps.Primitives.VisualStudio.Solutions.Helpers.VisualStudio15.Vs15Solutions;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.Common.Files
{
    public static class SlnFile
    {
        public static RepositoryFile Solution(string name)
            => Solution(SingleProject(name));

        public static RepositoryFile Solution(Solution solution)
            => new RepositoryFile(
                $"{solution.Name.Value}.sln",
                solution.ToString());
    }
}
