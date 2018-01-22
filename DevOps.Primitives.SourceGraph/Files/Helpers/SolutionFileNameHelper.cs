using DevOps.Primitives.VisualStudio.Solutions;

namespace DevOps.Primitives.SourceGraph.Files.Helpers
{
    internal static class SolutionFileNameHelper
    {
        public static string FileName(Solution solution)
            => $"{solution.Name.Value}.sln";
    }
}
