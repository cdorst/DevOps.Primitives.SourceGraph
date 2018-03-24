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
        public RepositoryContent(AsciiStringReferenceList sameAccountPackageDependencyList, RepositoryFileList repositoryFileList, AsciiStringReference version)
        {
            SameAccountPackageDependencyList = sameAccountPackageDependencyList;
            RepositoryFileList = repositoryFileList;
            Version = version;
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

        [ProtoMember(6)]
        public AsciiStringReference Version { get; set; }
        [ProtoMember(7)]
        public int? VersionId { get; set; }
    }
}
