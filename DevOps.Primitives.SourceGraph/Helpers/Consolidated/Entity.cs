using DevOps.Primitives.CSharp.Helpers.EntityFramework;
using DevOps.Primitives.NuGet;
using DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.EntityFramework.Repositories;
using DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.EntityFramework.Repositories.Builders;
using System;
using System.Collections.Generic;

namespace DevOps.Primitives.SourceGraph.Helpers.Consolidated
{
    public class Entity
    {
        public Entity(List<NuGetReference> dependencies, bool editable, string entityName, KeyType keyType, string projectName, List<EntityProperty> properties, int? typeId, string version)
        {
            Dependencies = dependencies ?? new List<NuGetReference>();
            Editable = editable;
            EntityName = entityName;
            KeyType = keyType;
            ProjectName = projectName;
            Properties = properties;
            TypeId = typeId;
            Version = version;
        }

        public List<NuGetReference> Dependencies { get; set; }
        public bool Editable { get; set; }
        public string EntityName { get; set; }
        public KeyType KeyType { get; set; }
        public string ProjectName { get; set; }
        public List<EntityProperty> Properties { get; set; }
        public int? TypeId { get; set; }
        public string Version { get; set; }

        public Func<GitHubAccount, Repository> GetBuilder()
            => EntityBuilder.Entity(GetTypeSpecification(), Dependencies);

        public EntityTypeSpecification GetTypeSpecification()
            => new EntityTypeSpecification(Editable, EntityName, ProjectName, Properties, KeyType, TypeId, Version);
    }
}
