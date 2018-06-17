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
        public RepositoryList(in List<RepositoryListAssociation> associations, in AsciiStringReference listIdentifier = default)
        {
            RepositoryListAssociations = associations;
            ListIdentifier = listIdentifier;
        }
        public RepositoryList(in RepositoryListAssociation associations, in AsciiStringReference listIdentifier = default)
            : this(new List<RepositoryListAssociation> { associations }, in listIdentifier)
        {
        }
        public RepositoryList(in Repository repository, in AsciiStringReference listIdentifier = default)
            : this(new RepositoryListAssociation(in repository), in listIdentifier)
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

        public void SetRecords(in List<Repository> records)
        {
            RepositoryListAssociations = UniqueListAssociationsFactory<Repository, RepositoryListAssociation>.Create(in records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<Repository>.Create(in records, r => r.RepositoryId));
        }
    }
}
