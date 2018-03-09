using DevOps.Primitives.CSharp.Helpers.EntityFramework;
using DevOps.Primitives.SourceGraph.Helpers.DotNetCore.Common.Files;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.EntityFramework.Files
{
    public static class EntityClassFiles
    {
        public static RepositoryFile Editable(EntityDeclaration declaration)
            => CSharpCode.ProjectRootCode(
                Entities.Editable(declaration));

        public static RepositoryFile Static(EntityDeclaration declaration)
            => CSharpCode.ProjectRootCode(
                Entities.Static(declaration));
    }
}
