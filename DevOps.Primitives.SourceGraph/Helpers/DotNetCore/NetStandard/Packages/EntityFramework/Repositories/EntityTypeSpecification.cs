using DevOps.Primitives.CSharp.Helpers.EntityFramework;
using System.Collections.Generic;
using static DevOps.Primitives.CSharp.Helpers.EntityFramework.EntityDeclarations;
using static DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.EntityFramework.Files.EntityClassFiles;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.EntityFramework.Repositories
{
    public class EntityTypeSpecification
    {
        public EntityTypeSpecification() { }

        public EntityTypeSpecification(bool editable, string entityName, string projectName, List<EntityProperty> properties, KeyType keyType = KeyType.Int, int? typeId = null, string version = "1.0.0")
        {
            Editable = editable;
            EntityDeclaration = editable
                ? Editable(entityName, projectName, properties, keyType, typeId)
                : Static(entityName, projectName, properties, keyType, typeId);
            Version = version;
        }

        public bool Editable { get; set; }
        public EntityDeclaration EntityDeclaration { get; set; }
        public string Version { get; set; }
    }
}
