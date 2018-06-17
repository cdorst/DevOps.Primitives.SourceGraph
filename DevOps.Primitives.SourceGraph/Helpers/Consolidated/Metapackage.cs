using DevOps.Primitives.NuGet;
using DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.Repositories.Builders;
using System;
using System.Collections.Generic;

namespace DevOps.Primitives.SourceGraph.Helpers.Consolidated
{
    public class Metapackage
    {
        public Metapackage(
            in string projectName,
            in string description,
            in string version,
            in List<NuGetReference> dependencies,
            in IDictionary<string, string> environmentVariables = default)
        {
            EnvironmentVariables = environmentVariables;
            Dependencies = dependencies;
            Description = description;
            ProjectName = projectName;
            Version = version;
        }

        public IDictionary<string, string> EnvironmentVariables { get; set; }
        public List<NuGetReference> Dependencies { get; set; }
        public string Description { get; set; }
        public string ProjectName { get; set; }
        public string Version { get; set; }

        public Func<GitHubAccount, Repository> GetBuilder()
            => PackageBuilder.Metapackage(ProjectName, Description, Version, Dependencies, EnvironmentVariables);
    }
}
