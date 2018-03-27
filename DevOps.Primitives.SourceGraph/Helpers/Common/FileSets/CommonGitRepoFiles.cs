using System.Collections.Generic;
using static DevOps.Primitives.SourceGraph.Helpers.Common.Files.BotStaleIssuesConfigFile;
using static DevOps.Primitives.SourceGraph.Helpers.Common.Files.BotWelcomeConfigFile;
using static DevOps.Primitives.SourceGraph.Helpers.Common.Files.CodeOfConductFile;
using static DevOps.Primitives.SourceGraph.Helpers.Common.Files.ContributingFile;
using static DevOps.Primitives.SourceGraph.Helpers.Common.Files.GitAttributesFile;
using static DevOps.Primitives.SourceGraph.Helpers.Common.Files.GitHubIssueTemplateFile;
using static DevOps.Primitives.SourceGraph.Helpers.Common.Files.GitHubPullRequestTemplateFile;
using static DevOps.Primitives.SourceGraph.Helpers.Common.Files.GitIgnoreFile;
using static DevOps.Primitives.SourceGraph.Helpers.Common.Files.GnuGpl3License;

namespace DevOps.Primitives.SourceGraph.Helpers.Common.FileSets
{
    public static class CommonGitRepoFiles
    {
        public static IEnumerable<RepositoryFile> StandardGitRepo(string accountName, string emailAddress)
        {
            yield return BotStaleIssuesConfig();
            yield return BotWelcomeConfig();
            yield return Contributing(emailAddress);
            yield return CodeOfConduct(emailAddress);
            yield return GitAttributes();
            yield return GitHubIssueTemplate();
            yield return GitHubPullRequestTemplate(accountName);
            yield return GitIgnore();
            yield return License();
        }
    }
}
