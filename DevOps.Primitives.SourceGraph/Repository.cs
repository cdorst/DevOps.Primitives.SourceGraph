using Common.EntityFrameworkServices;
using DevOps.Primitives.Strings;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.SourceGraph
{
    [ProtoContract]
    [Table("Repositories", Schema = nameof(SourceGraph))]
    public class Repository : IUniqueListRecord
    {
        public Repository() { }
        public Repository(string repositoryName, RepositoryFileList repositoryFileList)
        {
            RepositoryName = new AsciiStringReference(repositoryName);
            RepositoryFileList = repositoryFileList;
        }

        [Key]
        [ProtoMember(1)]
        public int RepositoryId { get; set; }

        [ProtoMember(2)]
        public RepositoryFileList RepositoryFileList { get; set; }

        [ProtoMember(3)]
        public AsciiStringReference RepositoryName { get; set; }
        [ProtoMember(4)]
        public int RepositoryNameId { get; set; }
    }
}
