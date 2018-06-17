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
        public RepositoryListAssociation(in Repository repository, in RepositoryList solutionProjectList = default)
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

        public void SetRecord(in Repository record)
        {
            Repository = record;
            RepositoryId = record.RepositoryId;
        }
    }
}
