using DevOps.Primitives.VisualStudio.Solutions;
using static DevOps.Primitives.VisualStudio.Solutions.Helpers.VisualStudio15.Vs15Solutions;
using static System.String;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.Common.Files
{
    public static class SlnFile
    {
        public static RepositoryFile Solution(in string name)
            => Solution(SingleProject(name));

        public static RepositoryFile Solution(in Solution solution)
            => new RepositoryFile(
                Concat(solution.Name.Value, ".sln"),
                solution.ToString());
    }
}
