using System.Collections.Generic;
using System.Text;
using static DevOps.Primitives.SourceGraph.Helpers.Common.Repositories.FileRepositories;
using static DevOps.Primitives.SourceGraph.Helpers.ProjectIndex.Files.DgmlFile;
using static DevOps.Primitives.SourceGraph.Helpers.ProjectIndex.Files.ProjectIndexReadme;

namespace DevOps.Primitives.SourceGraph.Helpers.ProjectIndex.Repositories
{
    public static class ProjectIndexRepositories
    {
        public static Repository ProjectIndexRepository(string accountName, string emailAddress, IDictionary<string, IEnumerable<string>> projectDirectory)
            => Repository(
                "Project.Index",
                "Metaproject directory for other repositories in this GitHub account",
                System.Data.HashFunction.xxHash.xxHashFactory.Instance.Create().ComputeHash(Encoding.UTF8.GetBytes(string.Join(string.Empty, projectDirectory.Keys))).AsHexString(),
                emailAddress,
                accountName,
                Dgml(projectDirectory),
                Readme(projectDirectory.Keys));
    }
}
