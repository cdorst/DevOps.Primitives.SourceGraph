﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Common.Functions.CheckNullableEnumerationForAnyElements.NullableEnumerationAny;
using static DevOps.Primitives.SourceGraph.Helpers.Common.Files.ReadmeFileHelper;

namespace DevOps.Primitives.SourceGraph.Helpers.ProjectIndex.Files
{
    public static class ProjectIndexReadme
    {
        public static RepositoryFile Readme(
            IEnumerable<string> repositories)
        {
            var content = new StringBuilder($"# Project.Index").AppendLine();
            if (Any(repositories))
            {
                var prefix = repositories.First().Split('.').First(); // Foo.Bar => Foo
                content.AppendLine("## Description").AppendLine()
                    .AppendLine($"The table below lists each code-generated repository in the github.com/{prefix} account. Repository names link to each project's GitHub repository. DevOps-pipeline status badges are shown alongside each repository name.").AppendLine()
                    .AppendLine("Each of the repositories in this index is treated as a node on a graph. Package dependencies between nodes (e.g. npm or NuGet) are treated as links. A .dgml file of the resulting directed acyclic graph is located here: [graph.dgml](graph.dgml)").AppendLine()
                    .AppendLine("This repository and those listed below are generated by robots working with declarative templates. The robots and the declarative-templating system are part of an open-source project created and maintained by Christopher Dorst at [https://github.com/cdorst](https://github.com/cdorst). [Support cdorst on Patreon](https://www.patreon.com/user?u=9178360).").AppendLine();
                content.AppendLine("## Repositories").AppendLine()
                    .AppendLine("Name | Status")
                    .AppendLine("---- | ------");
                foreach (var repository in repositories.Select(repo => repo.Substring(prefix.Length + 1)).OrderBy(repo => repo)) content
                    .AppendLine($"[{repository}](https://github.com/{prefix}/{repository}) | {GetBadges(prefix, repository)}");
                content.AppendLine();
            }
            return new RepositoryFile(ReadmeFileName, content.ToString());
        }
    }
}
