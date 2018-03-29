﻿namespace DevOps.Primitives.SourceGraph.Helpers.Common.Files
{
    public static class BotStaleIssuesConfigFile
    {
        private const string Name = "stale.yml";

        public static RepositoryFile BotStaleIssuesConfig()
            => new RepositoryFile(Name, @"# Configuration for stale-bot - https://github.com/probot/stale and https://github.com/apps/stale

# Number of days of inactivity before an issue becomes stale
daysUntilStale: 60
# Number of days of inactivity before a stale issue is closed
daysUntilClose: 7
# Issues with these labels will never be considered stale
exemptLabels:
  - pinned
  - security
# Label to use when marking an issue as stale
staleLabel: wontfix
# Comment to post when marking an issue as stale. Set to `false` to disable
markComment: >
  This issue has been automatically marked as stale because it has not had
  recent activity. It will be closed if no further activity occurs. Thank you
  for your contributions.
# Comment to post when closing a stale issue. Set to `false` to disable
closeComment: false", GitHubPathConstants.Path);
    }
}