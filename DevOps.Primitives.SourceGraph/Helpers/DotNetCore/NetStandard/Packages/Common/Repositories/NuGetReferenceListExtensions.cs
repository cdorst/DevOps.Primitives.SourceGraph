using DevOps.Primitives.NuGet;
using DevOps.Primitives.Strings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.Repositories
{
    public static class NuGetReferenceListExtensions
    {
        public static AsciiStringReferenceList GetSameAccountNuGetDependencies(
            this IEnumerable<NuGetReference> nuGetReferences, string account)
            => nuGetReferences.Any(PackageUnderAccount(account))
                ? new AsciiStringReferenceList
                {
                    AsciiStringReferenceListAssociations = nuGetReferences
                        .Where(PackageUnderAccount(account))
                        .Select(package => new AsciiStringReferenceListAssociation
                        {
                            AsciiStringReference = new AsciiStringReference(
                                package.Include.Value)
                        })
                        .ToList()
                }
                : null;

        internal static Func<NuGetReference, bool> PackageUnderAccount(string account)
            => package => package.Include.Value.StartsWith($"{account}.");
    }
}
