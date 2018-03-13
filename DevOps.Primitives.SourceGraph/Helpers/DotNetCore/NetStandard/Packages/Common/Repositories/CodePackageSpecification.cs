﻿using DevOps.Primitives.NuGet;
using DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.FileSets;
using System.Collections.Generic;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.Repositories
{
    public class CodePackageSpecification
    {
        public CodePackageSpecification(CodeTypeSpecification code, PackageRepositorySpecification package,
            IDictionary<string, string> environmentVariables = null)
        {
            Code = code;
            EnvironmentVariables = environmentVariables;
            Package = package;
        }

        public CodePackageSpecification(CodeTypeSpecification codeTypeSpecification, List<NuGetReference> dependencies, GitHubAccount account,
            IDictionary<string, string> environmentVariables = null)
            : this(codeTypeSpecification,
                  new PackageRepositorySpecification(account,
                      codeTypeSpecification.ProjectName,
                      codeTypeSpecification.Version,
                      codeTypeSpecification.Description,
                      dependencies),
                  environmentVariables)
        {
        }

        public CodeTypeSpecification Code { get; set; }
        public IDictionary<string, string> EnvironmentVariables { get; set; }
        public PackageRepositorySpecification Package { get; set; }
    }
}
