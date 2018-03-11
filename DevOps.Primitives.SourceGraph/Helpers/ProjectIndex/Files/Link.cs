namespace DevOps.Primitives.SourceGraph.Helpers.ProjectIndex.Files
{
    internal class Link
    {
        public Link(string source, string target)
        {
            Source = source;
            Target = target;
        }

        public string Source { get; set; }
        public string Target { get; set; }
    }
}
