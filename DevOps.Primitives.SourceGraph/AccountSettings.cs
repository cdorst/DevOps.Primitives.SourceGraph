using ProtoBuf;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.SourceGraph
{
    [ProtoContract]
    [Table("AccountSettings", Schema = nameof(SourceGraph))]
    public class AccountSettings
    {
        public AccountSettings() { }
        public AccountSettings(GitHubAccountSettings gitHubAccountSettings, NuGetPackageSettings nuGetPackageSettings)
        {
            GitHubAccountSettings = gitHubAccountSettings;
            NuGetPackageSettings = nuGetPackageSettings;
        }

        [ProtoMember(1)]
        public int AccountSettingsId { get; set; }

        [ProtoMember(2)]
        public GitHubAccountSettings GitHubAccountSettings { get; set; }
        [ProtoMember(3)]
        public int GitHubAccountSettingsId { get; set; }

        [ProtoMember(4)]
        public NuGetPackageSettings NuGetPackageSettings { get; set; }
        [ProtoMember(5)]
        public int NuGetPackageSettingsId { get; set; }
    }
}
