namespace DevOps.Primitives.SourceGraph.Helpers.ProjectIndex.Files
{
    internal class Link
    {
        public Link(in string source, in string target)
        {
            Source = source;
            Target = target;
        }

        public string Source { get; set; }
        public string Target { get; set; }
    }
}
