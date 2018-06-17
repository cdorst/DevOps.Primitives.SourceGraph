namespace DevOps.Primitives.SourceGraph.Helpers.Common.Files
{
    public static class GitHubPullRequestTemplateFile
    {
        private const string Name = "pull_request_template.md";

        public static RepositoryFile GitHubPullRequestTemplate(in string accountName)
            => new RepositoryFile(Name, $@"## Purpose

<!-- Please provide a short (1 sentence) reason for this Pull Request -->

## Description (optional)

<!-- Please provide additional information about your changes here -->

## Mentions
<!-- The repository owner is mentioned below. Please add additional users if needed -->
@{accountName}", GitHubPathConstants.Path);
    }
}
