using DevOps.Primitives.CSharp.Helpers.EntityFramework;
using DevOps.Primitives.NuGet;
using System.Collections.Generic;

namespace DevOps.Primitives.SourceGraph.Helpers.Consolidated.Builders
{
    public static class EntityBuilder
    {
        public static Entity Entity(string projectName, string entityName, string version, List<NuGetReference> dependencies, List<EntityProperty> properties, KeyType keyType = KeyType.Int, int? typeId = null, bool editable = false)
            => new Entity(dependencies, editable, entityName, keyType, projectName, properties, typeId, version);
    }
}
