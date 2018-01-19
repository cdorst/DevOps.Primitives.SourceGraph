using DevOps.Primitives.CSharp;
using ProtoBuf;

namespace DevOps.Primitives.SourceGraph.Files
{
    [ProtoContract]
    public class CSharpFile
    {
        [ProtoMember(8)]
        public TypeDeclaration TypeDeclaration { get; set; }
        [ProtoMember(9)]
        public int TypeDeclarationId { get; set; }
    }
}
