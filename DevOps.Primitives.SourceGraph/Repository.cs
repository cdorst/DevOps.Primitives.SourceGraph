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
        public Repository(RepositoryNameDescription repositoryNameDescription, RepositoryContent repositoryContent)
        {
            RepositoryNameDescription = repositoryNameDescription;
            RepositoryContent = repositoryContent;
        }
        public Repository(string repositoryName, string repositoryDescription, string version, AsciiStringReferenceList sameAccountPackageDependencyList, RepositoryFileList repositoryFileList)
            : this(new RepositoryNameDescription(repositoryName, repositoryDescription), new RepositoryContent(sameAccountPackageDependencyList, repositoryFileList, new AsciiStringReference(version)))
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
