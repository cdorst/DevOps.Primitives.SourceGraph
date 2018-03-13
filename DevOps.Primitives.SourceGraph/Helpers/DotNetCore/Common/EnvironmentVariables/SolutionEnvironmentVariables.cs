using System.Collections.Generic;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.Common.EnvironmentVariables
{
    public static class SolutionEnvironmentVariables
    {
        public static readonly KeyValuePair<string, string> LOCAL_NUGET_SOURCE_PATH
            = new KeyValuePair<string, string>(nameof(LOCAL_NUGET_SOURCE_PATH), @"*Required* to build the project, but not required during code execution. This is set to `c:\projects\nuget\cache` on the build server. On your development machine, set this to an empty, existing path. `dotnet restore` will inspect this folder prior to checking NuGet.");
    }
}
