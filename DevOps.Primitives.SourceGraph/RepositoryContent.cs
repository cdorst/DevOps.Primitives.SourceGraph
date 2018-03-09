using DevOps.Primitives.Strings;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.SourceGraph
{
    [ProtoContract]
    [Table("RepositoryContents", Schema = nameof(SourceGraph))]
    public class RepositoryContent
    {
        public RepositoryContent() { }
        public RepositoryContent(AsciiStringReferenceList sameAccountPackageDependencyList, RepositoryFileList repositoryFileList)
        {
            SameAccountPackageDependencyList = sameAccountPackageDependencyList;
            RepositoryFileList = repositoryFileList;
        }

        [Key]
        [ProtoMember(1)]
        public int RepositoryContentId { get; set; }

        [ProtoMember(2)]
        public RepositoryFileList RepositoryFileList { get; set; }
        [ProtoMember(3)]
        public int RepositoryFileListId { get; set; }

        [ProtoMember(4)]
        public AsciiStringReferenceList SameAccountPackageDependencyList { get; set; }
        [ProtoMember(5)]
        public int? SameAccountPackageDependencyListId { get; set; }
    }
}
