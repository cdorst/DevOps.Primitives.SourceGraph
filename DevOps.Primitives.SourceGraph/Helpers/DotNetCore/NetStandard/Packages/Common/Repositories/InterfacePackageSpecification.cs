using DevOps.Primitives.CSharp;
using System.Collections.Generic;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.Repositories
{
    public class InterfacePackageSpecification
    {
        public InterfacePackageSpecification(
            in string typeName,
            in IDictionary<string, string> environmentVariables = default,
            in UsingDirectiveList usingDirectiveList = default,
            in DocumentationCommentList documentationCommentList = default,
            in AttributeListCollection attributeListCollection = default,
            in TypeParameterList typeParameterList = default,
            in ConstraintClauseList constraintClauseList = default,
            in BaseList baseList = default,
            in MethodList methodList = default,
            in PropertyList propertyList = default)
        {
            AttributeListCollection = attributeListCollection;
            BaseList = baseList;
            ConstraintClauseList = constraintClauseList;
            DocumentationCommentList = documentationCommentList;
            EnvironmentVariables = environmentVariables;
            MethodList = methodList;
            PropertyList = propertyList;
            TypeName = typeName;
            TypeParameterList = typeParameterList;
            UsingDirectiveList = usingDirectiveList;
        }

        public AttributeListCollection AttributeListCollection { get; set; }
        public BaseList BaseList { get; set; }
        public ConstraintClauseList ConstraintClauseList { get; set; }
        public DocumentationCommentList DocumentationCommentList { get; set; }
        public IDictionary<string, string> EnvironmentVariables { get; set; }
        public MethodList MethodList { get; set; }
        public PropertyList PropertyList { get; set; }
        public string TypeName { get; set; }
        public TypeParameterList TypeParameterList { get; set; }
        public UsingDirectiveList UsingDirectiveList { get; set; }
    }
}
