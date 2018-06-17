namespace DevOps.Primitives.SourceGraph.Helpers.Common.Files
{
    public static class ContributingFile
    {
        private const string Name = "CONTRIBUTING.md";

        public static RepositoryFile Contributing(in string emailAddress)
            => new RepositoryFile(Name, $@"# How to contribute

Thank you for interest in this project! This repository is created by a code-generator, but is still maintained by humans.

Feel free to open an issue or to contact the owner at {emailAddress}.
", GitHubPathConstants.Path);
    }
}
