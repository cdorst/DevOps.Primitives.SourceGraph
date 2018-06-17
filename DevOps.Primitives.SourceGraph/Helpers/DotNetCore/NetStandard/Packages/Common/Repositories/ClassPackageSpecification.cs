using DevOps.Primitives.CSharp;
using System.Collections.Generic;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.NetStandard.Packages.Common.Repositories
{
    public class ClassPackageSpecification : InterfacePackageSpecification
    {
        public ClassPackageSpecification(
            in bool @static,
            in string typeName,
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
            : base(
                  in typeName,
                  in environmentVariables,
                  in usingDirectiveList,
                  in documentationCommentList,
                  in attributeListCollection,
                  in typeParameterList,
                  in constraintClauseList,
                  in baseList,
                  in methodList,
                  in propertyList)
        {
            ConstructorList = constructorList;
            FieldList = fieldList;
            Finalizer = finalizer;
            Static = @static;
        }

        public ConstructorList ConstructorList { get; set; }
        public FieldList FieldList { get; set; }
        public Finalizer Finalizer { get; set; }
        public bool Static { get; set; }
    }
}
