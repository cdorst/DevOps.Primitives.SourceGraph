using DevOps.Primitives.Strings;
using ProtoBuf;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.SourceGraph
{
    [ProtoContract]
    [Table("NuGetPackageCacheSettings", Schema = nameof(SourceGraph))]
    public class NuGetPackageCacheSettings
    {
        public NuGetPackageCacheSettings() { }
        public NuGetPackageCacheSettings(in AsciiStringReference appveyorAzureStorageSecret, in AsciiStringReference packageCacheUrl)
        {
            AppveyorAzureStorageSecret = appveyorAzureStorageSecret;
            PackageCacheUrl = packageCacheUrl;
        }
        public NuGetPackageCacheSettings(in string appveyorAzureStorageSecret, in string packageCacheUrl)
            : this(new AsciiStringReference(in appveyorAzureStorageSecret), new AsciiStringReference(in packageCacheUrl))
        {
        }

        [ProtoMember(1)]
        public int NuGetPackageCacheCopyrightSettingsId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference AppveyorAzureStorageSecret { get; set; }
        [ProtoMember(3)]
        public int AppveyorAzureStorageSecretId { get; set; }

        [ProtoMember(4)]
        public AsciiStringReference PackageCacheUrl { get; set; }
        [ProtoMember(5)]
        public int PackageCacheUrlId { get; set; }
    }
}
