using DevOps.Primitives.CSharp;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.Repositories
{
    public class InterfacePackageSpecification
    {
        public InterfacePackageSpecification(string typeName,
            UsingDirectiveList usingDirectiveList = null, DocumentationCommentList documentationCommentList = null, AttributeListCollection attributeListCollection = null, TypeParameterList typeParameterList = null, ConstraintClauseList constraintClauseList = null, BaseList baseList = null, MethodList methodList = null, PropertyList propertyList = null)
        {
            AttributeListCollection = attributeListCollection;
            BaseList = baseList;
            ConstraintClauseList = constraintClauseList;
            DocumentationCommentList = documentationCommentList;
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
        public MethodList MethodList { get; set; }
        public PropertyList PropertyList { get; set; }
        public string TypeName { get; set; }
        public TypeParameterList TypeParameterList { get; set; }
        public UsingDirectiveList UsingDirectiveList { get; set; }
    }
}
