using DevOps.Primitives.CSharp;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.Common.Files
{
    public static class CSharpCode
    {
        public static RepositoryFile Code(TypeDeclaration type, params string[] pathParts)
            => new RepositoryFile(
                $"{type.Identifier.Name.Value}.cs",
                type.ToString(),
                pathParts);
    }
}
