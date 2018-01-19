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
    [Table("RepositoryFileLists", Schema = nameof(SourceGraph))]
    public class RepositoryFileList : IUniqueList<RepositoryFile, RepositoryFileListAssociation>
    {
        public RepositoryFileList() { }
        public RepositoryFileList(List<RepositoryFileListAssociation> associations, AsciiStringReference listIdentifier = null)
        {
            RepositoryFileListAssociations = associations;
            ListIdentifier = listIdentifier;
        }
        public RepositoryFileList(RepositoryFileListAssociation associations, AsciiStringReference listIdentifier = null)
            : this(new List<RepositoryFileListAssociation> { associations }, listIdentifier)
        {
        }
        public RepositoryFileList(RepositoryFile repositoryFile, AsciiStringReference listIdentifier = null)
            : this(new RepositoryFileListAssociation(repositoryFile), listIdentifier)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int RepositoryFileListId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference ListIdentifier { get; set; }
        [ProtoMember(3)]
        public int ListIdentifierId { get; set; }

        [ProtoMember(4)]
        public List<RepositoryFileListAssociation> RepositoryFileListAssociations { get; set; }

        public List<RepositoryFileListAssociation> GetAssociations() => RepositoryFileListAssociations;

        public void SetRecords(List<RepositoryFile> records)
        {
            RepositoryFileListAssociations = UniqueListAssociationsFactory<RepositoryFile, RepositoryFileListAssociation>.Create(records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<RepositoryFile>.Create(records, r => r.RepositoryFileId));
        }
    }
}
