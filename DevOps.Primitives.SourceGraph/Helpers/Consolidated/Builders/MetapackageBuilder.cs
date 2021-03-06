﻿using DevOps.Primitives.NuGet;
using System.Collections.Generic;

namespace DevOps.Primitives.SourceGraph.Helpers.Consolidated.Builders
{
    public static class MetapackageBuilder
    {
        public static Metapackage Metapackage(string projectName, string description, string version, List<NuGetReference> dependencies, IDictionary<string, string> environmentVariables = null)
            => new Metapackage(projectName, description, version, dependencies, environmentVariables);
    }
}
