using DevOps.Primitives.NuGet;
using DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.Repositories.Builders;
using System;
using System.Collections.Generic;

namespace DevOps.Primitives.SourceGraph.Helpers.Consolidated
{
    public class Metapackage
    {
        public Metapackage(string projectName, string description, string version, List<NuGetReference> dependencies, IDictionary<string, string> environmentVariables = null)
        {
            Dependencies = dependencies;
            Description = description;
            EnvironmentVariables = environmentVariables;
            ProjectName = projectName;
            Version = version;
        }

        public List<NuGetReference> Dependencies { get; set; }
        public string Description { get; set; }
        public IDictionary<string, string> EnvironmentVariables { get; set; }
        public string ProjectName { get; set; }
        public string Version { get; set; }

        public Func<GitHubAccount, Repository> GetBuilder()
            => PackageBuilder.Metapackage(ProjectName, Description, Version, Dependencies, EnvironmentVariables);
    }
}
