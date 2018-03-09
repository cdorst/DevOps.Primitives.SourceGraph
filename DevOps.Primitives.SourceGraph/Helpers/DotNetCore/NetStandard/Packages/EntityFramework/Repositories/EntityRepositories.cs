using DevOps.Primitives.NuGet;
using System.Collections.Generic;
using static DevOps.Primitives.CSharp.Helpers.EntityFramework.EntityDeclarations;
using static DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.Repositories.PackageRepositories;
using static DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.EntityFramework.Files.EntityClassFiles;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.EntityFramework.Repositories
{
    public static class EntityRepositories
    {
        public static Repository Entity(EntityPackageSpecification specification)
            => SingleType(
                specification.RepositorySpecification,
                GetFile(specification.EntityTypeSpecification));

        public static Repository Entity(EntityTypeSpecification specification, List<NuGetReference> dependencies, GitHubAccount account)
            => Entity(new EntityPackageSpecification(specification, dependencies, account));

        private static RepositoryFile GetFile(EntityTypeSpecification specification)
            => specification.Editable
                ? Editable(specification.EntityDeclaration)
                : Static(specification.EntityDeclaration);
    }
}
