using DevOps.Primitives.CSharp;
using ProtoBuf;
using static DevOps.Primitives.SourceGraph.Files.CSharpFileNameHelper;

namespace DevOps.Primitives.SourceGraph.Files
{
    [ProtoContract]
    public class CSharpFile : RepositoryFile
    {
        public CSharpFile() : base() { }
        public CSharpFile(TypeDeclaration typeDeclaration, string containingFolderPath)
            : base(
                  fileName: FileName(typeDeclaration),
                  content: typeDeclaration.ToString(),
                  relativePath: $"{containingFolderPath}/{FileName(typeDeclaration)}")
        {
            TypeDeclaration = typeDeclaration;
        }

        [ProtoMember(8)]
        public TypeDeclaration TypeDeclaration { get; set; }
        [ProtoMember(9)]
        public int TypeDeclarationId { get; set; }
    }
}
