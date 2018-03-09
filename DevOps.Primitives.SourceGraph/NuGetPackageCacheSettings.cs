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
        public NuGetPackageCacheSettings(AsciiStringReference appveyorAzureStorageSecret, AsciiStringReference packageCacheUrl)
        {
            AppveyorAzureStorageSecret = appveyorAzureStorageSecret;
            PackageCacheUrl = packageCacheUrl;
        }
        public NuGetPackageCacheSettings(string appveyorAzureStorageSecret, string packageCacheUrl)
            : this(new AsciiStringReference(appveyorAzureStorageSecret), new AsciiStringReference(packageCacheUrl))
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
