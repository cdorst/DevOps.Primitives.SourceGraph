using Common.EntityFrameworkServices;
using Common.EntityFrameworkServices.Factories;
using DevOps.Primitives.Strings;
using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DevOps.Primitives.SourceGraph
{
    [ProtoContract]
    [Table("RepositoryFileLists", Schema = nameof(SourceGraph))]
    public class RepositoryFileList : IUniqueList<RepositoryFile, RepositoryFileListAssociation>
    {
        public RepositoryFileList() { }
        public RepositoryFileList(in List<RepositoryFileListAssociation> associations, in AsciiStringReference listIdentifier = default)
        {
            RepositoryFileListAssociations = associations;
            ListIdentifier = listIdentifier;
        }
        public RepositoryFileList(params RepositoryFile[] files)
            : this(files.Select(file => new RepositoryFileListAssociation(in file)).ToList())
        {
        }
        public RepositoryFileList(in RepositoryFileListAssociation associations, in AsciiStringReference listIdentifier = default)
            : this(new List<RepositoryFileListAssociation> { associations }, in listIdentifier)
        {
        }
        public RepositoryFileList(in RepositoryFile repositoryFile, in AsciiStringReference listIdentifier = default)
            : this(new RepositoryFileListAssociation(in repositoryFile), in listIdentifier)
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

        public void SetRecords(in List<RepositoryFile> records)
        {
            RepositoryFileListAssociations = UniqueListAssociationsFactory<RepositoryFile, RepositoryFileListAssociation>.Create(in records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<RepositoryFile>.Create(in records, r => r.RepositoryFileId));
        }
    }
}
