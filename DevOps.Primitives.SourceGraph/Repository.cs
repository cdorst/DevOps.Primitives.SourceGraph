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
        public Repository(in RepositoryNameDescription repositoryNameDescription, in RepositoryContent repositoryContent)
        {
            RepositoryContent = repositoryContent;
            RepositoryNameDescription = repositoryNameDescription;
        }
        public Repository(
            in string repositoryName,
            in string repositoryDescription,
            in string version,
            in AsciiStringReferenceList sameAccountPackageDependencyList,
            in RepositoryFileList repositoryFileList)
            : this(
                  new RepositoryNameDescription(in repositoryName, in repositoryDescription),
                  new RepositoryContent(in sameAccountPackageDependencyList, in repositoryFileList, new AsciiStringReference(in version)))
        {
        }

        [Key]
        [ProtoMember(1)]
        public int RepositoryId { get; set; }

        [ProtoMember(2)]
        public RepositoryContent RepositoryContent { get; set; }
        [ProtoMember(3)]
        public int RepositoryContentId { get; set; }

        [ProtoMember(4)]
        public RepositoryNameDescription RepositoryNameDescription { get; set; }
        [ProtoMember(5)]
        public int RepositoryNameDescriptionId { get; set; }

        public string GetName()
            => RepositoryNameDescription.Name.Value;

        public string GetVersion()
            => RepositoryContent.Version.Value;
    }
}
