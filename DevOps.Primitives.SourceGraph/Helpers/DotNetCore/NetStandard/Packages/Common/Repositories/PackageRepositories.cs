﻿using DevOps.Primitives.CSharp;
using DevOps.Primitives.NuGet;
using DevOps.Primitives.SourceGraph.Helpers.DotNetCore.Common.Files;
using DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.FileSets;
using System.Collections.Generic;
using System.Linq;
using static DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.FileSets.PackageFiles;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.Repositories
{
    public static class PackageRepositories
    {
        public static Repository Code(CodeTypeSpecification specification, List<NuGetReference> dependencies, GitHubAccount account)
            => Code(new CodePackageSpecification(specification, dependencies, account));

        public static Repository Code(CodePackageSpecification specification)
            => Code(specification.Code.Code, specification.Package);

        public static Repository Code(InterfacePackageSpecification specification, PackageRepositorySpecification package)
            => specification is ClassPackageSpecification
                ? SingleClass(package, specification as ClassPackageSpecification)
                : SingleInterface(package, specification);

        public static Repository Metapackage(
            string projectName,
            string description,
            string version,
            List<NuGetReference> dependencies,
            GitHubAccount account)
        {
            var pkg = new PackageRepositorySpecification(account, projectName, version, description, dependencies);
            return new Repository(projectName, description, null,
                new RepositoryFileList(
                    Package(pkg.PackageSpecification, pkg.AuthorEmail, pkg.PackageCacheUri, pkg.AppveyorAzureStorageSecret, dependencies).ToArray()));
        }

        public static Repository SingleClass(PackageRepositorySpecification package, ClassPackageSpecification specification)
            => specification.Static
                ? SingleStaticClass(
                    specification.TypeName,
                    package.PackageSpecification,
                    package.AppveyorAzureStorageSecret,
                    package.AuthorEmail,
                    package.PackageCacheUri,
                    package.Dependencies,
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
            string typeName,
            NuGetPackageSpecification packageSpecification,
            string appveyorAzureStorageSecret,
            string authorEmail,
            string packageCacheUri,
            IEnumerable<NuGetReference> nuGetReferences = null,
            UsingDirectiveList usingDirectiveList = null, DocumentationCommentList documentationCommentList = null, AttributeListCollection attributeListCollection = null, TypeParameterList typeParameterList = null, ConstraintClauseList constraintClauseList = null, BaseList baseList = null, ConstructorList constructorList = null, FieldList fieldList = null, MethodList methodList = null, PropertyList propertyList = null, Finalizer finalizer = null)
            => SingleType(
                packageSpecification,
                appveyorAzureStorageSecret,
                authorEmail,
                packageCacheUri,
                CSharpCode.CSharpClass(
                    packageSpecification.Name,
                    typeName,
                    packageSpecification.Name,
                    usingDirectiveList,
                    documentationCommentList,
                    attributeListCollection,
                    typeParameterList,
                    constraintClauseList,
                    baseList,
                    constructorList,
                    fieldList,
                    methodList,
                    propertyList,
                    finalizer),
                nuGetReferences);

        public static Repository SingleStaticClass(
            string typeName,
            NuGetPackageSpecification packageSpecification,
            string appveyorAzureStorageSecret,
            string authorEmail,
            string packageCacheUri,
            IEnumerable<NuGetReference> nuGetReferences = null,
            UsingDirectiveList usingDirectiveList = null, DocumentationCommentList documentationCommentList = null, AttributeListCollection attributeListCollection = null, TypeParameterList typeParameterList = null, ConstraintClauseList constraintClauseList = null, BaseList baseList = null, ConstructorList constructorList = null, FieldList fieldList = null, MethodList methodList = null, PropertyList propertyList = null, Finalizer finalizer = null)
            => SingleType(
                packageSpecification,
                appveyorAzureStorageSecret,
                authorEmail,
                packageCacheUri,
                CSharpCode.CSharpStaticClass(
                    packageSpecification.Name,
                    typeName,
                    packageSpecification.Name,
                    usingDirectiveList,
                    documentationCommentList,
                    attributeListCollection,
                    typeParameterList,
                    constraintClauseList,
                    baseList,
                    constructorList,
                    fieldList,
                    methodList,
                    propertyList,
                    finalizer),
                nuGetReferences);

        public static Repository SingleInterface(PackageRepositorySpecification package, InterfacePackageSpecification specification)
            => SingleInterface(
                specification.TypeName,
                package.PackageSpecification,
                package.AppveyorAzureStorageSecret,
                package.AuthorEmail,
                package.PackageCacheUri,
                package.Dependencies,
                specification.UsingDirectiveList,
                specification.DocumentationCommentList,
                specification.AttributeListCollection,
                specification.TypeParameterList,
                specification.ConstraintClauseList,
                specification.BaseList,
                specification.MethodList,
                specification.PropertyList);

        public static Repository SingleInterface(
            string typeName,
            NuGetPackageSpecification packageSpecification,
            string appveyorAzureStorageSecret,
            string authorEmail,
            string packageCacheUri,
            IEnumerable<NuGetReference> nuGetReferences = null,
            UsingDirectiveList usingDirectiveList = null, DocumentationCommentList documentationCommentList = null, AttributeListCollection attributeListCollection = null, TypeParameterList typeParameterList = null, ConstraintClauseList constraintClauseList = null, BaseList baseList = null, MethodList methodList = null, PropertyList propertyList = null)
            => SingleType(
                packageSpecification,
                appveyorAzureStorageSecret,
                authorEmail,
                packageCacheUri,
                CSharpCode.CSharpInterface(
                    packageSpecification.Name,
                    typeName,
                    packageSpecification.Name,
                    usingDirectiveList,
                    documentationCommentList,
                    attributeListCollection,
                    typeParameterList,
                    constraintClauseList,
                    baseList,
                    methodList,
                    propertyList),
                nuGetReferences);

        public static Repository SingleType(
            NuGetPackageSpecification packageSpecification,
            string appveyorAzureStorageSecret,
            string authorEmail,
            string packageCacheUri,
            TypeDeclaration type,
            IEnumerable<NuGetReference> nuGetReferences = null)
            => new Repository(packageSpecification.Name, packageSpecification.Description,
                nuGetReferences?.GetSameAccountNuGetDependencies(packageSpecification.NamespacePrefix), new RepositoryFileList(Package(packageSpecification, authorEmail, packageCacheUri, appveyorAzureStorageSecret, nuGetReferences, type).ToArray()));

        public static Repository SingleType(
            NuGetPackageSpecification packageSpecification,
            string appveyorAzureStorageSecret,
            string authorEmail,
            string packageCacheUri,
            RepositoryFile type,
            IEnumerable<NuGetReference> nuGetReferences = null)
            => new Repository(packageSpecification.Name, packageSpecification.Description,
                nuGetReferences?.GetSameAccountNuGetDependencies(packageSpecification.NamespacePrefix), new RepositoryFileList(Package(packageSpecification, authorEmail, packageCacheUri, appveyorAzureStorageSecret, nuGetReferences, type).ToArray()));

        public static Repository SingleType(
            PackageRepositorySpecification specification,
            TypeDeclaration type)
            => SingleType(
                specification.PackageSpecification,
                specification.AppveyorAzureStorageSecret,
                specification.AuthorEmail,
                specification.PackageCacheUri,
                type,
                specification.Dependencies);

        public static Repository SingleType(
            PackageRepositorySpecification specification,
            RepositoryFile type)
            => SingleType(
                specification.PackageSpecification,
                specification.AppveyorAzureStorageSecret,
                specification.AuthorEmail,
                specification.PackageCacheUri,
                type,
                specification.Dependencies);
    }
}
