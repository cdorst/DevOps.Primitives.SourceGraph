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
        public Repository(RepositoryNameDescription repositoryNameDescription, RepositoryFileList repositoryFileList)
        {
            RepositoryNameDescription = repositoryNameDescription;
            RepositoryFileList = repositoryFileList;
        }
        public Repository(string repositoryName, string repositoryDescription, RepositoryFileList repositoryFileList)
            : this(new RepositoryNameDescription(repositoryName, repositoryDescription), repositoryFileList)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int RepositoryId { get; set; }

        [ProtoMember(2)]
        public RepositoryFileList RepositoryFileList { get; set; }
        [ProtoMember(3)]
        public int RepositoryFileListId { get; set; }

        [ProtoMember(4)]
        public RepositoryNameDescription RepositoryNameDescription { get; set; }
        [ProtoMember(5)]
        public int RepositoryNameDescriptionId { get; set; }
    }
}
