using Common.EnumStringValues;

namespace DevOps.Primitives.SourceGraph.Helpers.TypeScript.Common.Files
{
    public enum TsConfigJsx : byte
    {
        [EnumStringValue(nameof(preserve))]
        preserve,
        [EnumStringValue("react-native")]
        reactNative,
        [EnumStringValue(nameof(react))]
        react
    }
}
