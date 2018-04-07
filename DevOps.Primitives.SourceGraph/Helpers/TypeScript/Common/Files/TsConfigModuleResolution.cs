using Common.EnumStringValues;

namespace DevOps.Primitives.SourceGraph.Helpers.TypeScript.Common.Files
{
    public enum TsConfigModuleResolution : byte
    {
        [EnumStringValue(nameof(node))]
        node,
        [EnumStringValue(nameof(classic))]
        classic
    }
}
