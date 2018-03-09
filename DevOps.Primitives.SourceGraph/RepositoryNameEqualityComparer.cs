using System.Collections.Generic;

namespace DevOps.Primitives.SourceGraph
{
    public class RepositoryNameEqualityComparer : EqualityComparer<Repository>
    {
        public static RepositoryNameEqualityComparer RepositoryName => new RepositoryNameEqualityComparer();

        public override bool Equals(Repository x, Repository y)
            => x.GetName().Equals(y.GetName());

        public override int GetHashCode(Repository obj)
            => obj.GetName().GetHashCode();
    }
}
