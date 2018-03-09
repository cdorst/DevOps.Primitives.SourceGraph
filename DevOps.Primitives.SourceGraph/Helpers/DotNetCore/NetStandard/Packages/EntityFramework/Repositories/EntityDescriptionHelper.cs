using System.Text;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.EntityFramework.Repositories
{
    internal static class EntityDescriptionHelper
    {
        public static string Description(bool editable, string name)
            => new StringBuilder(
                $"Contains the {name} ({Kind(editable)}) entity.")
                .Append(Followup(editable, name))
                .ToString();

        private static string Followup(bool editable, string name)
            => editable ? string.Empty
                : $" {name} records do not update. Query each {name}Id-keyed record once and cache forever (e.g. as protobuf blob in static-file CDN).";

        private static string Kind(bool editable)
            => editable ? nameof(editable) : "static";
    }
}
