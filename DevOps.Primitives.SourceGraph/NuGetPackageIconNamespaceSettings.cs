using DevOps.Primitives.Strings;
using ProtoBuf;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.SourceGraph
{
    [ProtoContract]
    [Table("NuGetPackageIconNamespaceSettings", Schema = nameof(SourceGraph))]
    public class NuGetPackageIconNamespaceSettings
    {
        public NuGetPackageIconNamespaceSettings() { }
        public NuGetPackageIconNamespaceSettings(AsciiStringReference packageIconUrl, AsciiStringReference namespacePrefix)
        {
            NamespacePrefix = namespacePrefix;
            PackageIconUrl = packageIconUrl;
        }
        public NuGetPackageIconNamespaceSettings(string packageIconUrl, string namespacePrefix)
            : this(new AsciiStringReference(packageIconUrl), new AsciiStringReference(namespacePrefix))
        {
        }

        [ProtoMember(1)]
        public int NuGetPackageIconNamespaceSettingsId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference NamespacePrefix { get; set; }
        [ProtoMember(3)]
        public int NamespacePrefixId { get; set; }

        [ProtoMember(4)]
        public AsciiStringReference PackageIconUrl { get; set; }
        [ProtoMember(5)]
        public int PackageIconUrlId { get; set; }
    }
}
