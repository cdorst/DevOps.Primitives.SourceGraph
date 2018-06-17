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
        public NuGetPackageCacheCopyrightSettings(in NuGetPackageCacheSettings nuGetPackageCacheSettings, in AsciiStringReference copyright)
        {
            NuGetPackageCacheSettings = nuGetPackageCacheSettings;
            Copyright = copyright;
        }
        public NuGetPackageCacheCopyrightSettings(in string copyright, in NuGetPackageCacheSettings nuGetPackageCacheSettings)
            : this(in nuGetPackageCacheSettings, new AsciiStringReference(in copyright))
        {
        }
        public NuGetPackageCacheCopyrightSettings(in string copyright, in string appveyorAzureStorageSecret, in string packageCacheUrl)
            : this(in copyright, new NuGetPackageCacheSettings(in appveyorAzureStorageSecret, in packageCacheUrl))
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
