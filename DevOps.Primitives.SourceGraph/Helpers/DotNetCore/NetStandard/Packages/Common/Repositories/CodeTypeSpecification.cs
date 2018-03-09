namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.Repositories
{
    public class CodeTypeSpecification
    {
        public CodeTypeSpecification() { }
        public CodeTypeSpecification(string projectName, string description, InterfacePackageSpecification code, string version = "1.0.0")
        {
            Code = code;
            Description = description;
            ProjectName = projectName;
            Version = version;
        }

        public InterfacePackageSpecification Code { get; set; }
        public string Description { get; set; }
        public string ProjectName { get; set; }
        public string Version { get; set; }
    }
}
