using DevOps.Primitives.NuGet;
using DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.FileSets;
using System;
using System.Collections.Generic;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.EntityFramework.Repositories
{
    public class EntityPackageSpecification
    {
        public EntityPackageSpecification() { }

        public EntityPackageSpecification(EntityTypeSpecification entityTypeSpecification, PackageRepositorySpecification repositorySpecification)
        {
            EntityTypeSpecification = entityTypeSpecification;
            RepositorySpecification = RepositorySpecification;
        }

        public EntityPackageSpecification(EntityTypeSpecification entityTypeSpecification, List<NuGetReference> dependencies, GitHubAccount account)
            : this(entityTypeSpecification ?? throw new ArgumentNullException(nameof(entityTypeSpecification)),
                  new PackageRepositorySpecification(account,
                      entityTypeSpecification.EntityDeclaration?.Namespace ?? throw new ArgumentNullException("EntityDeclaration"),
                      entityTypeSpecification.Version,
                      EntityDescriptionHelper.Description(
                          entityTypeSpecification.Editable,
                          entityTypeSpecification.EntityDeclaration.Name),
                      dependencies))
        {
        }


        public EntityTypeSpecification EntityTypeSpecification { get; set; }
        public PackageRepositorySpecification RepositorySpecification { get; set; }
    }
}
