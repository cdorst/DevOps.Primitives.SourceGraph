using Common.EnumStringValues;

namespace DevOps.Primitives.SourceGraph.Helpers.TypeScript.Common.Files
{
    public enum TsConfigModule : byte
    {
        [EnumStringValue(nameof(none))]
        none,
        [EnumStringValue(nameof(commonjs))]
        commonjs,
        [EnumStringValue(nameof(amd))]
        amd,
        [EnumStringValue(nameof(system))]
        system,
        [EnumStringValue(nameof(umd))]
        umd,
        [EnumStringValue(nameof(es2015))]
        es2015,
        [EnumStringValue(nameof(ESNext))]
        ESNext
    }
}
