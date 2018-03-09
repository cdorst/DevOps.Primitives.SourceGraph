using DevOps.Primitives.Strings;
using ProtoBuf;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.SourceGraph
{
    [ProtoContract]
    [Table("NuGetPackageCacheCopyrightSettings", Schema = nameof(SourceGraph))]
    public class NuGetPackageCacheCopyrightSettings
    {
        public NuGetPackageCacheCopyrightSettings() { }
        public NuGetPackageCacheCopyrightSettings(NuGetPackageCacheSettings nuGetPackageCacheSettings, AsciiStringReference copyright)
        {
            NuGetPackageCacheSettings = nuGetPackageCacheSettings;
            Copyright = copyright;
        }
        public NuGetPackageCacheCopyrightSettings(string copyright, NuGetPackageCacheSettings nuGetPackageCacheSettings)
            : this(nuGetPackageCacheSettings, new AsciiStringReference(copyright))
        {
        }
        public NuGetPackageCacheCopyrightSettings(string copyright, string appveyorAzureStorageSecret, string packageCacheUrl)
            : this(copyright, new NuGetPackageCacheSettings(appveyorAzureStorageSecret, packageCacheUrl))
        {
        }

        [ProtoMember(1)]
        public int NuGetPackageCacheCopyrightSettingsId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference Copyright { get; set; }
        [ProtoMember(3)]
        public int CopyrightId { get; set; }

        [ProtoMember(4)]
        public NuGetPackageCacheSettings NuGetPackageCacheSettings { get; set; }
        [ProtoMember(5)]
        public int NuGetPackageCacheSettingsId { get; set; }
    }
}
