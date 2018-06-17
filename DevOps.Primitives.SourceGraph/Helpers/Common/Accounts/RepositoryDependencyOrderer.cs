using Common.EntityFrameworkServices;
using System.Collections.Generic;
using System.Linq;

namespace DevOps.Primitives.SourceGraph.Helpers.Common.Accounts
{
    internal static class RepositoryDependencyOrderer
    {
        public static IEnumerable<Repository> Order(this IEnumerable<Repository> repositories)
        {
            var considerations = GetDependencyConsiderations(in repositories);
            var dependencies = GetDependencyDictionary(in repositories);
            var worked = new HashSet<string>();
            var queue = new Queue<Repository>(repositories);
            while (queue.Any())
            {
                var record = queue.Dequeue();
                var name = record.GetName();
                if (dependencies[name].Any(package =>
                    !worked.Contains(package) && considerations.Contains(package)))
                    queue.Enqueue(record);
                else
                {
                    worked.Add(name);
                    yield return record;
                }
            }
        }

        private static HashSet<string> GetDependencyConsiderations(in IEnumerable<Repository> repositories)
            => new HashSet<string>(repositories.Select(r => r.GetName()).Distinct());

        private static Dictionary<string, HashSet<string>> GetDependencyDictionary(in IEnumerable<Repository> repositories)
        {
            var dependencyDictionary = new Dictionary<string, HashSet<string>>();
            foreach (var repository in repositories)
                dependencyDictionary.Add(
                    key: repository.GetName(),
                    value: new HashSet<string>(
                        repository.RepositoryContent
                            .SameAccountPackageDependencyList?.GetRecords()
                            .Select(r => r.Value).Distinct() ?? new string[] { }));
            return dependencyDictionary;
        }
    }
}
