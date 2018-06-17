using DevOps.Primitives.NuGet;
using DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.Repositories;
using DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.Repositories.Builders;
using System;
using System.Collections.Generic;

namespace DevOps.Primitives.SourceGraph.Helpers.Consolidated
{
    public class Code
    {
        public Code(
            in string projectName,
            in string description,
            in string version,
            in List<NuGetReference> dependencies,
            in InterfacePackageSpecification declaration,
            in IDictionary<string, string> environmentVariables = default)
        {
            Declaration = declaration;
            Dependencies = dependencies;
            Description = description;
            EnvironmentVariables = environmentVariables;
            ProjectName = projectName;
            Version = version;
        }

        public InterfacePackageSpecification Declaration { get; set; }
        public List<NuGetReference> Dependencies { get; set; }
        public string Description { get; set; }
        public IDictionary<string, string> EnvironmentVariables { get; set; }
        public string ProjectName { get; set; }
        public string Version { get; set; }

        public Func<GitHubAccount, Repository> GetBuilder()
            => PackageBuilder.Code(GetTypeSpecification(), Dependencies, EnvironmentVariables);

        public CodeTypeSpecification GetTypeSpecification()
            => new CodeTypeSpecification(ProjectName, Description, Declaration, Version);
    }
}
