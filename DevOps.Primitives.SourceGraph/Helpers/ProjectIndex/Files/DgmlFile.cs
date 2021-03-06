﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.String;

namespace DevOps.Primitives.SourceGraph.Helpers.ProjectIndex.Files
{
    public static class DgmlFile
    {
        private const string Foot = @"	</Links>
</DirectedGraph>
";
        private const string Head = @"<?xml version=""1.0"" encoding=""utf-8""?>
<DirectedGraph Title=""SourceCodeRepositoryGraph"" xmlns=""http://schemas.microsoft.com/vs/2009/dgml"">
	<Nodes>";

        public static RepositoryFile Dgml(in IDictionary<string, IEnumerable<string>> nodesAndLinks)
        {
            var linkList = new List<Link>();
            foreach (var node in nodesAndLinks)
                foreach (var link in node.Value ?? new string[] { })
                    linkList.Add(new Link(in link, node.Key));
            var content = new StringBuilder(Head).AppendLine();
            foreach (var node in nodesAndLinks.Keys)
                content.AppendLine(Concat("\t\t", GetNodeXml(node)));
            content
                .AppendLine("\t</Nodes>")
                .AppendLine("\t<Links>");
            foreach (var link in linkList
                .OrderBy(l => l.Source).ThenBy(l => l.Target))
                content.AppendLine(Concat("\t\t", GetLinkXml(link)));
            return new RepositoryFile("graph.dgml", content.AppendLine(Foot).ToString());
        }

        private static string GetLinkXml(in Link link)
            => Concat("<Link Source=\"", link.Source, "\" Target=\"", link.Target, "\" />");

        private static string GetNodeXml(in string name)
            => Concat("<Node Id=\"", name, "\" />");
    }
}
