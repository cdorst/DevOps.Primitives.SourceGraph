using Common.EntityFrameworkServices;
using DevOps.Primitives.Strings;
using ProtoBuf;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.SourceGraph
{
    [ProtoContract]
    [Table("RepositoryFiles", Schema = nameof(SourceGraph))]
    public class RepositoryFile : IUniqueListRecord
    {
        public RepositoryFile() { }
        public RepositoryFile(FileName fileName, UnicodeMaxStringReference content)
        {
            Content = content;
            FileName = fileName;
        }
        public RepositoryFile(FileName fileName, string content)
            : this(fileName, new UnicodeMaxStringReference(content))
        {
        }
        public RepositoryFile(string name, string content, params string[] pathParts)
            : this(new FileName(name, pathParts), content)
        {
        }

        [ProtoMember(1)]
        public int RepositoryFileId { get; set; }

        [ProtoMember(2)]
        public FileName FileName { get; set; }
        [ProtoMember(3)]
        public int FileNameId { get; set; }

        [ProtoMember(4)]
        public UnicodeMaxStringReference Content { get; set; }
        [ProtoMember(5)]
        public int ContentId { get; set; }

        public string GetPathRelativeToRepositoryRoot()
            => FileName.GetPathRelativeToRepositoryRoot();
    }
}
