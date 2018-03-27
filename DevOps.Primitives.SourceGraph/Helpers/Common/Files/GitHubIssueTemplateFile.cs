namespace DevOps.Primitives.SourceGraph.Helpers.Common.Files
{
    public static class GitHubIssueTemplateFile
    {
        private const string Name = "issue_template.md";

        public static RepositoryFile GitHubIssueTemplate()
            => new RepositoryFile(Name, @"### Expected behavior


### Actual behavior


### Steps to reproduce


### Description of proposed changes


", GitHubPathConstants.Path);
    }
}
