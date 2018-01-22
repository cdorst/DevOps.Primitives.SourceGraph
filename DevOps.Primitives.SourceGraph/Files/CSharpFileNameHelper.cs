using DevOps.Primitives.CSharp;

namespace DevOps.Primitives.SourceGraph.Files
{
    internal static class CSharpFileNameHelper
    {
        public static string FileName(TypeDeclaration type)
            => $"{type.Identifier.Name.Value}.cs";
    }
}
