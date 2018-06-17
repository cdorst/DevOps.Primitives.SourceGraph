using DevOps.Primitives.CSharp;
using DevOps.Primitives.NuGet;
using DevOps.Primitives.SourceGraph.Helpers.DotNetCore.Common.Files;
using DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.FileSets;
using System;
using System.Collections.Generic;
using System.Linq;
using static DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.FileSets.PackageFiles;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.Repositories
{
    public static class PackageRepositories
    {
        public static Repository Code(
            in CodeTypeSpecification specification,
            in List<NuGetReference> dependencies,
            in GitHubAccount account,
            in IDictionary<string, string> environmentVariables = default)
            => Code(new CodePackageSpecification(in specification, in dependencies, in account));

        public static Repository Code(
            in CodePackageSpecification specification,
            in IDictionary<string, string> environmentVariables = default)
            => Code(specification.Code.Code, specification.Package);

        public static Repository Code(
            in InterfacePackageSpecification specification,
            in PackageRepositorySpecification package,
            in IDictionary<string, string> environmentVariables = default)
            => specification is ClassPackageSpecification
                ? SingleClass(in package, specification as ClassPackageSpecification)
                : SingleInterface(in package, in specification);

        public static Repository Metapackage(
            in string projectName,
            in string description,
            in string version,
            in List<NuGetReference> dependencies,
            in GitHubAccount account,
            in IDictionary<string, string> environmentVariables = default)
        {
            var pkg = new PackageRepositorySpecification(in account, in projectName, in version, in description, in dependencies);
            return new Repository(in projectName, in description, in version, null,
                new RepositoryFileList(
                    Package(pkg.PackageSpecification, pkg.AuthorEmail, pkg.PackageCacheUri, pkg.AppveyorAzureStorageSecret, dependencies, in environmentVariables, files: null).ToArray()));
        }

        public static Repository SingleClass(
            in PackageRepositorySpecification package,
            in ClassPackageSpecification specification,
            in IDictionary<string, string> environmentVariables = default)
            => specification.Static
                ? SingleStaticClass(
                    specification.TypeName,
                    package.PackageSpecification,
                    package.AppveyorAzureStorageSecret,
                    package.AuthorEmail,
                    package.PackageCacheUri,
                    package.Dependencies,
                    in environmentVariables,
                    specification.UsingDirectiveList,
                    specification.DocumentationCommentList,
                    specification.AttributeListCollection,
                    specification.TypeParameterList,
                    specification.ConstraintClauseList,
                    specification.BaseList,
                    specification.ConstructorList,
                    specification.FieldList,
                    specification.MethodList,
                    specification.PropertyList,
                    specification.Finalizer)
            : SingleClass(
                    specification.TypeName,
                    package.PackageSpecification,
                    package.AppveyorAzureStorageSecret,
                    package.AuthorEmail,
                    package.PackageCacheUri,
                    package.Dependencies,
                    in environmentVariables,
                    specification.UsingDirectiveList,
                    specification.DocumentationCommentList,
                    specification.AttributeListCollection,
                    specification.TypeParameterList,
                    specification.ConstraintClauseList,
                    specification.BaseList,
                    specification.ConstructorList,
                    specification.FieldList,
                    specification.MethodList,
                    specification.PropertyList,
                    specification.Finalizer);

        public static Repository SingleClass(
            in string typeName,
            in NuGetPackageSpecification packageSpecification,
            in string appveyorAzureStorageSecret,
            in string authorEmail,
            in string packageCacheUri,
            in IEnumerable<NuGetReference> nuGetReferences = default,
            in IDictionary<string, string> environmentVariables = default,
            in UsingDirectiveList usingDirectiveList = default,
            in DocumentationCommentList documentationCommentList = default,
            in AttributeListCollection attributeListCollection = default,
            in TypeParameterList typeParameterList = default,
            in ConstraintClauseList constraintClauseList = default,
            in BaseList baseList = default,
            in ConstructorList constructorList = default,
            in FieldList fieldList = default,
            in MethodList methodList = default,
            in PropertyList propertyList = default,
            in Finalizer finalizer = default)
            => SingleType(
                in packageSpecification,
                in appveyorAzureStorageSecret,
                in authorEmail,
                in packageCacheUri,
                CSharpCode.CSharpClass(
                    packageSpecification.Copyright,
                    packageSpecification.Name,
                    in typeName,
                    packageSpecification.Name,
                    in usingDirectiveList,
                    in documentationCommentList,
                    in attributeListCollection,
                    in typeParameterList,
                    in constraintClauseList,
                    in baseList,
                    in constructorList,
                    in fieldList,
                    in methodList,
                    in propertyList,
                    in finalizer),
                in nuGetReferences);

        public static Repository SingleStaticClass(
            in string typeName,
            in NuGetPackageSpecification packageSpecification,
            in string appveyorAzureStorageSecret,
            in string authorEmail,
            in string packageCacheUri,
            in IEnumerable<NuGetReference> nuGetReferences = default,
            in IDictionary<string, string> environmentVariables = default,
            in UsingDirectiveList usingDirectiveList = default,
            in DocumentationCommentList documentationCommentList = default,
            in AttributeListCollection attributeListCollection = default,
            in TypeParameterList typeParameterList = default,
            in ConstraintClauseList constraintClauseList = default,
            in BaseList baseList = default,
            in ConstructorList constructorList = default,
            in FieldList fieldList = default,
            in MethodList methodList = default,
            in PropertyList propertyList = default,
            in Finalizer finalizer = default)
            => SingleType(
                in packageSpecification,
                in appveyorAzureStorageSecret,
                in authorEmail,
                in packageCacheUri,
                CSharpCode.CSharpStaticClass(
                    packageSpecification.Copyright,
                    packageSpecification.Name,
                    in typeName,
                    packageSpecification.Name,
                    in usingDirectiveList,
                    in documentationCommentList,
                    in attributeListCollection,
                    in typeParameterList,
                    in constraintClauseList,
                    in baseList,
                    in constructorList,
                    in fieldList,
                    in methodList,
                    in propertyList,
                    in finalizer),
                in nuGetReferences);

        public static Repository SingleInterface(
            in PackageRepositorySpecification package,
            in InterfacePackageSpecification specification,
            in IDictionary<string, string> environmentVariables = default)
            => SingleInterface(
                specification.TypeName,
                package.PackageSpecification,
                package.AppveyorAzureStorageSecret,
                package.AuthorEmail,
                package.PackageCacheUri,
                package.Dependencies,
                in environmentVariables,
                specification.UsingDirectiveList,
                specification.DocumentationCommentList,
                specification.AttributeListCollection,
                specification.TypeParameterList,
                specification.ConstraintClauseList,
                specification.BaseList,
                specification.MethodList,
                specification.PropertyList);

        public static Repository SingleInterface(
            in string typeName,
            in NuGetPackageSpecification packageSpecification,
            in string appveyorAzureStorageSecret,
            in string authorEmail,
            in string packageCacheUri,
            in IEnumerable<NuGetReference> nuGetReferences = default,
            in IDictionary<string, string> environmentVariables = default,
            in UsingDirectiveList usingDirectiveList = default,
            in DocumentationCommentList documentationCommentList = default,
            in AttributeListCollection attributeListCollection = default,
            in TypeParameterList typeParameterList = default,
            in ConstraintClauseList constraintClauseList = default,
            in BaseList baseList = default,
            in MethodList methodList = default,
            in PropertyList propertyList = default)
            => SingleType(
                in packageSpecification,
                in appveyorAzureStorageSecret,
                in authorEmail,
                in packageCacheUri,
                CSharpCode.CSharpInterface(
                    packageSpecification.Copyright,
                    packageSpecification.Name,
                    in typeName,
                    packageSpecification.Name,
                    in usingDirectiveList,
                    in documentationCommentList,
                    in attributeListCollection,
                    in typeParameterList,
                    in constraintClauseList,
                    in baseList,
                    in methodList,
                    in propertyList),
                in nuGetReferences);

        public static Repository SingleType(
            in NuGetPackageSpecification packageSpecification,
            in string appveyorAzureStorageSecret,
            in string authorEmail,
            in string packageCacheUri,
            in TypeDeclaration type,
            in IEnumerable<NuGetReference> nuGetReferences = default,
            in IDictionary<string, string> environmentVariables = default)
            => new Repository(
                packageSpecification?.Name ?? throw new ArgumentNullException(nameof(packageSpecification)),
                packageSpecification.Description,
                packageSpecification.Version,
                nuGetReferences?.GetSameAccountNuGetDependencies(packageSpecification.NamespacePrefix),
                new RepositoryFileList(
                    Package(in packageSpecification, in authorEmail, in packageCacheUri, in appveyorAzureStorageSecret, in nuGetReferences, in environmentVariables, type).ToArray()));

        public static Repository SingleType(
            in NuGetPackageSpecification packageSpecification,
            in string appveyorAzureStorageSecret,
            in string authorEmail,
            in string packageCacheUri,
            in RepositoryFile type,
            in IEnumerable<NuGetReference> nuGetReferences = default,
            in IDictionary<string, string> environmentVariables = default)
            => new Repository(
                packageSpecification?.Name ?? throw new ArgumentNullException(nameof(packageSpecification)),
                packageSpecification.Description,
                packageSpecification.Version,
                nuGetReferences?.GetSameAccountNuGetDependencies(packageSpecification.NamespacePrefix),
                new RepositoryFileList(
                    Package(in packageSpecification, in authorEmail, in packageCacheUri, in appveyorAzureStorageSecret, in nuGetReferences, in environmentVariables, type).ToArray()));

        public static Repository SingleType(
            in PackageRepositorySpecification specification,
            in TypeDeclaration type)
            => SingleType(
                (specification ?? throw new ArgumentNullException(nameof(specification)))
                    .PackageSpecification ?? throw new ArgumentNullException("PackageSpecification"),
                specification.AppveyorAzureStorageSecret,
                specification.AuthorEmail,
                specification.PackageCacheUri,
                in type,
                specification.Dependencies);

        public static Repository SingleType(
            in PackageRepositorySpecification specification,
            in RepositoryFile type)
            => SingleType(
                (specification ?? throw new ArgumentNullException(nameof(specification)))
                    .PackageSpecification ?? throw new ArgumentNullException("PackageSpecification"),
                specification.AppveyorAzureStorageSecret,
                specification.AuthorEmail,
                specification.PackageCacheUri,
                in type,
                specification.Dependencies);
    }
}
