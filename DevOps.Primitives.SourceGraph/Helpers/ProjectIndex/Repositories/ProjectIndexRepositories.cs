using System.Collections.Generic;
using static DevOps.Primitives.SourceGraph.Helpers.ProjectIndex.Files.DgmlFile;
using static DevOps.Primitives.SourceGraph.Helpers.ProjectIndex.Files.ProjectIndexReadme;
using static System.Data.HashFunction.xxHash.xxHashFactory;
using static System.String;
using static System.Text.Encoding;

namespace DevOps.Primitives.SourceGraph.Helpers.ProjectIndex.Repositories
{
    public static class ProjectIndexRepositories
    {
        public static Repository ProjectIndexRepository(string accountName, string emailAddress, IDictionary<string, IEnumerable<string>> projectDirectory)
            => Common.Repositories.FileRepositories.Repository(
                "Project.Index",
                "Metaproject directory for other repositories in this GitHub account",
                ComputeVersionHash(projectDirectory.Keys),
                emailAddress,
                accountName,
                Dgml(projectDirectory),
                Readme(projectDirectory.Keys));

        private static string ComputeVersionHash(IEnumerable<string> repositoryNames)
            => Instance.Create()
                .ComputeHash(UTF8.GetBytes(Join(Empty, repositoryNames)))
                .AsHexString();
    }
}
