using System.Collections.Generic;
using static DevOps.Primitives.SourceGraph.Helpers.Common.Repositories.FileRepositories;
using static DevOps.Primitives.SourceGraph.Helpers.ProjectIndex.Files.DgmlFile;
using static DevOps.Primitives.SourceGraph.Helpers.ProjectIndex.Files.ProjectIndexReadme;

namespace DevOps.Primitives.SourceGraph.Helpers.ProjectIndex.Repositories
{
    public static class ProjectIndexRepositories
    {
        public static Repository ProjectIndexRepository(IDictionary<string, IEnumerable<string>> projectDirectory)
            => Repository(
                "Project.Index",
                "Metaproject directory for other repositories in this GitHub account",
                Dgml(projectDirectory),
                Readme(projectDirectory.Keys));
    }
}
