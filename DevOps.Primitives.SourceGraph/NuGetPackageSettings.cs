using ProtoBuf;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.SourceGraph
{
    [ProtoContract]
    [Table("NuGetPackageSettings", Schema = nameof(SourceGraph))]
    public class NuGetPackageSettings
    {
        public NuGetPackageSettings() { }
        public NuGetPackageSettings(NuGetPackageCacheCopyrightSettings nuGetPackageCacheCopyrightSettings, NuGetPackageIconNamespaceSettings nuGetPackageIconNamespaceSettings)
        {
            NuGetPackageCacheCopyrightSettings = nuGetPackageCacheCopyrightSettings;
            NuGetPackageIconNamespaceSettings = nuGetPackageIconNamespaceSettings;
        }

        [ProtoMember(1)]
        public int NuGetPackageSettingsId { get; set; }

        [ProtoMember(2)]
        public NuGetPackageCacheCopyrightSettings NuGetPackageCacheCopyrightSettings { get; set; }
        [ProtoMember(3)]
        public int NuGetPackageCacheCopyrightSettingsId { get; set; }

        [ProtoMember(4)]
        public NuGetPackageIconNamespaceSettings NuGetPackageIconNamespaceSettings { get; set; }
        [ProtoMember(5)]
        public int NuGetPackageIconNamespaceSettingsId { get; set; }
    }
}
