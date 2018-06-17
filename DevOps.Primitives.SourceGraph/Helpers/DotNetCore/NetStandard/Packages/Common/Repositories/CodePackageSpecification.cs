using DevOps.Primitives.NuGet;
using DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.FileSets;
using System.Collections.Generic;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.Repositories
{
    public class CodePackageSpecification
    {
        public CodePackageSpecification(
            in CodeTypeSpecification code,
            in PackageRepositorySpecification package,
            in IDictionary<string, string> environmentVariables = default)
        {
            Code = code;
            EnvironmentVariables = environmentVariables;
            Package = package;
        }

        public CodePackageSpecification(
            in CodeTypeSpecification codeTypeSpecification,
            in List<NuGetReference> dependencies,
            in GitHubAccount account,
            in IDictionary<string, string> environmentVariables = default)
            : this(
                  in codeTypeSpecification,
                  new PackageRepositorySpecification(
                      in account,
                      codeTypeSpecification.ProjectName,
                      codeTypeSpecification.Version,
                      codeTypeSpecification.Description,
                      in dependencies),
                  in environmentVariables)
        {
        }

        public CodeTypeSpecification Code { get; set; }
        public IDictionary<string, string> EnvironmentVariables { get; set; }
        public PackageRepositorySpecification Package { get; set; }
    }
}
