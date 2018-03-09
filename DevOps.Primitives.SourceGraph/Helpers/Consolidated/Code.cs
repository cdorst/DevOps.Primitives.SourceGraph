using DevOps.Primitives.NuGet;
using DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.Repositories;
using DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.Repositories.Builders;
using System;
using System.Collections.Generic;

namespace DevOps.Primitives.SourceGraph.Helpers.Consolidated
{
    public class Code
    {
        public Code(string projectName, string description, string version, List<NuGetReference> dependencies, InterfacePackageSpecification declaration)
        {
            Declaration = declaration;
            Dependencies = dependencies;
            Description = description;
            ProjectName = projectName;
            Version = version;
        }

        public InterfacePackageSpecification Declaration { get; set; }
        public List<NuGetReference> Dependencies { get; set; }
        public string Description { get; set; }
        public string ProjectName { get; set; }
        public string Version { get; set; }

        public Func<GitHubAccount, Repository> GetBuilder()
            => PackageBuilder.Code(GetTypeSpecification(), Dependencies);

        public CodeTypeSpecification GetTypeSpecification()
            => new CodeTypeSpecification(ProjectName, Description, Declaration, Version);
    }
}
