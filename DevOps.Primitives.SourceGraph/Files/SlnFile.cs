using DevOps.Primitives.VisualStudio.Solutions;
using ProtoBuf;
using static DevOps.Primitives.SourceGraph.Files.SolutionFileNameHelper;

namespace DevOps.Primitives.SourceGraph.Files
{
    [ProtoContract]
    public class SlnFile : RepositoryFile
    {
        public SlnFile() : base() { }
        public SlnFile(Solution solution)
            : base(
                  fileName: FileName(solution),
                  content: solution.ToString(),
                  relativePath: $"/{FileName(solution)}")
        {
            Solution = solution;
        }

        [ProtoMember(8)]
        public Solution Solution { get; set; }
        [ProtoMember(9)]
        public int SolutionId { get; set; }
    }
}
