using Common.EntityFrameworkServices;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.SourceGraph
{
    [ProtoContract]
    [Table("RepositoryFileListAssociations", Schema = nameof(SourceGraph))]
    public class RepositoryFileListAssociation : IUniqueListAssociation<RepositoryFile>
    {
        public RepositoryFileListAssociation() { }
        public RepositoryFileListAssociation(RepositoryFile repositoryFile, RepositoryFileList solutionProjectList = null)
        {
            RepositoryFile = repositoryFile;
            RepositoryFileList = solutionProjectList;
        }

        [Key]
        [ProtoMember(1)]
        public int RepositoryFileListAssociationId { get; set; }

        [ProtoMember(2)]
        public RepositoryFile RepositoryFile { get; set; }
        [ProtoMember(3)]
        public int RepositoryFileId { get; set; }

        [ProtoMember(4)]
        public RepositoryFileList RepositoryFileList { get; set; }
        [ProtoMember(5)]
        public int RepositoryFileListId { get; set; }

        public RepositoryFile GetRecord() => RepositoryFile;

        public void SetRecord(RepositoryFile record)
        {
            RepositoryFile = record;
            RepositoryFileId = RepositoryFile.RepositoryFileId;
        }
    }
}
