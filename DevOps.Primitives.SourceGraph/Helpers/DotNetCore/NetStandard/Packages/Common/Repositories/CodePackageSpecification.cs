using DevOps.Primitives.NuGet;
using DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.FileSets;
using System.Collections.Generic;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.Repositories
{
    public class CodePackageSpecification
    {
        public CodePackageSpecification(CodeTypeSpecification code, PackageRepositorySpecification package)
        {
            Code = code;
            Package = package;
        }

        public CodePackageSpecification(CodeTypeSpecification codeTypeSpecification, List<NuGetReference> dependencies, GitHubAccount account)
            : this(codeTypeSpecification,
                  new PackageRepositorySpecification(account,
                      codeTypeSpecification.ProjectName,
                      codeTypeSpecification.Version,
                      codeTypeSpecification.Description,
                      dependencies))
        {
        }

        public CodeTypeSpecification Code { get; set; }
        public PackageRepositorySpecification Package { get; set; }
    }
}
