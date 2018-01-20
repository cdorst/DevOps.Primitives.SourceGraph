using DevOps.Primitives.CSharp;
using ProtoBuf;

namespace DevOps.Primitives.SourceGraph.Files
{
    [ProtoContract]
    public class CSharpFile : RepositoryFile
    {
        public CSharpFile() : base() { }
        public CSharpFile(TypeDeclaration typeDeclaration, string fileName, string content, string relativePath)
            : base(fileName, content, relativePath)
        {
            TypeDeclaration = typeDeclaration;
        }

        [ProtoMember(8)]
        public TypeDeclaration TypeDeclaration { get; set; }
        [ProtoMember(9)]
        public int TypeDeclarationId { get; set; }
    }
}
