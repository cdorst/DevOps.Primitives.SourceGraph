using DevOps.Primitives.CSharp;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.Repositories
{
    public class ClassPackageSpecification : InterfacePackageSpecification, IClassPackageSpecification
    {
        public ClassPackageSpecification(bool @static, string typeName,
            UsingDirectiveList usingDirectiveList = null, DocumentationCommentList documentationCommentList = null, AttributeListCollection attributeListCollection = null, TypeParameterList typeParameterList = null, ConstraintClauseList constraintClauseList = null, BaseList baseList = null, ConstructorList constructorList = null, FieldList fieldList = null, MethodList methodList = null, PropertyList propertyList = null, Finalizer finalizer = null)
            : base(typeName, usingDirectiveList, documentationCommentList, attributeListCollection, typeParameterList, constraintClauseList, baseList, methodList, propertyList)
        {
            ConstructorList = constructorList;
            FieldList = fieldList;
            Finalizer = finalizer;
        }
        public ConstructorList ConstructorList { get; set; }
        public FieldList FieldList { get; set; }
        public Finalizer Finalizer { get; set; }
        public bool Static { get; set; }
    }
}
