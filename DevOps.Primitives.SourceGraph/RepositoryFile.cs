using Common.EntityFrameworkServices;
using DevOps.Primitives.Strings;
using ProtoBuf;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Data.HashFunction.xxHash.xxHashFactory;
using static System.Text.Encoding;

namespace DevOps.Primitives.SourceGraph
{
    [ProtoContract]
    [Table("RepositoryFiles", Schema = nameof(SourceGraph))]
    public class RepositoryFile : IUniqueListRecord
    {
        public RepositoryFile() { }
        public RepositoryFile(in FileName fileName, in UnicodeMaxStringReference content)
        {
            Content = content;
            FileName = fileName;
        }
        public RepositoryFile(in FileName fileName, in string content)
            : this(in fileName, new UnicodeMaxStringReference(in content))
        {
        }
        public RepositoryFile(in string name, in string content, params string[] pathParts)
            : this(new FileName(in name, in pathParts), in content)
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

        public string ComputeHash()
            => Instance.Create()
                .ComputeHash(UTF8.GetBytes(Content.Value))
                .AsHexString();

        public string GetPathRelativeToRepositoryRoot()
            => FileName.GetPathRelativeToRepositoryRoot();
    }
}
