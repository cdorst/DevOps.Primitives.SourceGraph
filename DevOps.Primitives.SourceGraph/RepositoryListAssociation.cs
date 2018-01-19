using Common.EntityFrameworkServices;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.SourceGraph
{
    [ProtoContract]
    [Table("RepositoryListAssociations", Schema = nameof(SourceGraph))]
    public class RepositoryListAssociation : IUniqueListAssociation<Repository>
    {
        public RepositoryListAssociation() { }
        public RepositoryListAssociation(Repository repository, RepositoryList solutionProjectList = null)
        {
            Repository = repository;
            RepositoryList = solutionProjectList;
        }

        [Key]
        [ProtoMember(1)]
        public int RepositoryListAssociationId { get; set; }

        [ProtoMember(2)]
        public Repository Repository { get; set; }
        [ProtoMember(3)]
        public int RepositoryId { get; set; }

        [ProtoMember(4)]
        public RepositoryList RepositoryList { get; set; }
        [ProtoMember(5)]
        public int RepositoryListId { get; set; }

        public Repository GetRecord() => Repository;

        public void SetRecord(Repository record)
        {
            Repository = record;
            RepositoryId = Repository.RepositoryId;
        }
    }
}
