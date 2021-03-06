﻿using DevOps.Primitives.CSharp;
using DevOps.Primitives.NuGet;
using DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.Repositories;
using System.Collections.Generic;

namespace DevOps.Primitives.SourceGraph.Helpers.Consolidated.Builders
{
    public static class CodeBuilder
    {
        public static Code Code(string projectName, string description, string version, List<NuGetReference> dependencies, InterfacePackageSpecification declaration, IDictionary<string, string> environmentVariables = null)
            => new Code(projectName, description, version, dependencies, declaration, environmentVariables);

        public static Code Class(string projectName, string description, string version, List<NuGetReference> dependencies, string typeName, IDictionary<string, string> environmentVariables = null, bool @static = true,
            UsingDirectiveList usingDirectiveList = null, DocumentationCommentList documentationCommentList = null, AttributeListCollection attributeListCollection = null, TypeParameterList typeParameterList = null, ConstraintClauseList constraintClauseList = null, BaseList baseList = null, ConstructorList constructorList = null, FieldList fieldList = null, MethodList methodList = null, PropertyList propertyList = null, Finalizer finalizer = null)
            => Code(projectName, description, version, dependencies,
                new ClassPackageSpecification(@static, typeName, environmentVariables, usingDirectiveList, documentationCommentList, attributeListCollection, typeParameterList, constraintClauseList, baseList, constructorList, fieldList, methodList, propertyList, finalizer));

        public static Code Interface(string projectName, string description, string version, List<NuGetReference> dependencies, string typeName, IDictionary<string, string> environmentVariables = null,
            UsingDirectiveList usingDirectiveList = null, DocumentationCommentList documentationCommentList = null, AttributeListCollection attributeListCollection = null, TypeParameterList typeParameterList = null, ConstraintClauseList constraintClauseList = null, BaseList baseList = null, MethodList methodList = null, PropertyList propertyList = null)
            => Code(projectName, description, version, dependencies,
                new InterfacePackageSpecification(typeName, environmentVariables, usingDirectiveList, documentationCommentList, attributeListCollection, typeParameterList, constraintClauseList, baseList, methodList, propertyList));
    }
}
