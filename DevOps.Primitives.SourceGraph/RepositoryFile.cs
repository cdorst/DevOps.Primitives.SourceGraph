using Common.EntityFrameworkServices;
using DevOps.Primitives.Strings;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.SourceGraph
{
    [ProtoContract]
    [Table("RepositoryFiles", Schema = nameof(SourceGraph))]
    public class RepositoryFile : IUniqueListRecord
    {
        [Key]
        [ProtoMember(1)]
        public int RepositoryFileId { get; set; }

        [ProtoMember(2)]
        public UnicodeMaxStringReference Content { get; set; }
        [ProtoMember(3)]
        public int ContentId { get; set; }

        [ProtoMember(4)]
        public AsciiStringReference FileName { get; set; }
        [ProtoMember(5)]
        public int FileNameId { get; set; }

        [ProtoMember(6)]
        public AsciiStringReference PathRelativeToRepositoryRoot { get; set; }
        [ProtoMember(7)]
        public int PathRelativeToRepositoryRootId { get; set; }
    }
}
