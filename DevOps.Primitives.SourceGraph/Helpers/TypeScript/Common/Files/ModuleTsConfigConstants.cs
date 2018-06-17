namespace DevOps.Primitives.SourceGraph.Helpers.TypeScript.Common.Files
{
    internal static class ModuleTsConfigConstants
    {
        public const string OutDir = "./dist/";
        public const string SourceDirectory = "./src/**/*";

        public static readonly string[] IncludePaths = { SourceDirectory };
    }
}
