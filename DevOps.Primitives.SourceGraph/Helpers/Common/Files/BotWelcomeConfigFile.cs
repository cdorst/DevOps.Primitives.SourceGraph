﻿namespace DevOps.Primitives.SourceGraph.Helpers.Common.Files
{
    public static class BotWelcomeConfigFile
    {
        private const string Name = "config.yml";

        public static RepositoryFile BotWelcomeConfig()
            => new RepositoryFile(Name, @"# Configuration for welcome - https://github.com/behaviorbot/welcome

# Configuration for new-issue-welcome - https://github.com/behaviorbot/new-issue-welcome

# Comment to be posted to on first time issues
newIssueWelcomeComment: >
  Thanks for opening your first issue here! Be sure to follow the issue template!

# Configuration for new-pr-welcome - https://github.com/behaviorbot/new-pr-welcome

# Comment to be posted to on PRs from first time contributors in your repository
newPRWelcomeComment: >
  Thanks for opening this pull request! Please check out our contributing guidelines and follow the Pull Request template.

# Configuration for first-pr-merge - https://github.com/behaviorbot/first-pr-merge

# Comment to be posted to on pull requests merged by a first time user
firstPRMergeComment: >
  Congrats on merging your first pull request! Thank you for contributing to this project!

# It is recommend to include as many gifs and emojis as possible", GitHubPathConstants.Path);
    }
}
