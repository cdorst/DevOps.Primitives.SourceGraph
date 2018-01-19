using Common.EntityFrameworkServices;
using Common.EntityFrameworkServices.Factories;
using DevOps.Primitives.Strings;
using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.SourceGraph
{
    [ProtoContract]
    [Table("RepositoryLists", Schema = nameof(SourceGraph))]
    public class RepositoryList : IUniqueList<Repository, RepositoryListAssociation>
    {
        public RepositoryList() { }
        public RepositoryList(List<RepositoryListAssociation> associations, AsciiStringReference listIdentifier = null)
        {
            RepositoryListAssociations = associations;
            ListIdentifier = listIdentifier;
        }
        public RepositoryList(RepositoryListAssociation associations, AsciiStringReference listIdentifier = null)
            : this(new List<RepositoryListAssociation> { associations }, listIdentifier)
        {
        }
        public RepositoryList(Repository repository, AsciiStringReference listIdentifier = null)
            : this(new RepositoryListAssociation(repository), listIdentifier)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int RepositoryListId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference ListIdentifier { get; set; }
        [ProtoMember(3)]
        public int ListIdentifierId { get; set; }

        [ProtoMember(4)]
        public List<RepositoryListAssociation> RepositoryListAssociations { get; set; }

        public List<RepositoryListAssociation> GetAssociations() => RepositoryListAssociations;

        public void SetRecords(List<Repository> records)
        {
            RepositoryListAssociations = UniqueListAssociationsFactory<Repository, RepositoryListAssociation>.Create(records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<Repository>.Create(records, r => r.RepositoryId));
        }
    }
}
