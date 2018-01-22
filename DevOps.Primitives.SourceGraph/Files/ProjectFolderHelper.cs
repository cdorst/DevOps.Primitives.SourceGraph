namespace DevOps.Primitives.SourceGraph.Files
{
    internal static class ProjectFolderHelper
    {
        private const string src = nameof(src);
        private const string test = nameof(test);

        public static string ProjectFolder(ProjectType projectType)
            => projectType == ProjectType.Tests
                ? test
                : src;
    }
}
