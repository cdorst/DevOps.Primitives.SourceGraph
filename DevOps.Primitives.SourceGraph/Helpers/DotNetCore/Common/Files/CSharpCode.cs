using DevOps.Primitives.CSharp;
using DevOps.Primitives.CSharp.Helpers.Common;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.Common.Files
{
    public static class CSharpCode
    {
        public static RepositoryFile Code(TypeDeclaration type, params string[] pathParts)
            => new RepositoryFile(
                $"{type.Identifier.Name.Value}.cs",
                type.ToString(),
                pathParts);

        public static RepositoryFile ProjectRootCode(TypeDeclaration type)
            => new RepositoryFile(
                $"{type.Identifier.Name.Value}.cs",
                type.ToString(),
                type.Namespace.Identifier.Name.Value);

        public static RepositoryFile CSharpClass(string projectName, string typeName, string @namespace, UsingDirectiveList usingDirectiveList = null, DocumentationCommentList documentationCommentList = null, AttributeListCollection attributeListCollection = null, TypeParameterList typeParameterList = null, ConstraintClauseList constraintClauseList = null, BaseList baseList = null, ConstructorList constructorList = null, FieldList fieldList = null, MethodList methodList = null, PropertyList propertyList = null, Finalizer finalizer = null)
            => Code(
                Classes.Public(typeName, @namespace, usingDirectiveList, documentationCommentList, attributeListCollection, typeParameterList, constraintClauseList, baseList, constructorList, fieldList, methodList, propertyList, finalizer),
                projectName);

        public static RepositoryFile CSharpStaticClass(string projectName, string typeName, string @namespace, UsingDirectiveList usingDirectiveList = null, DocumentationCommentList documentationCommentList = null, AttributeListCollection attributeListCollection = null, TypeParameterList typeParameterList = null, ConstraintClauseList constraintClauseList = null, BaseList baseList = null, ConstructorList constructorList = null, FieldList fieldList = null, MethodList methodList = null, PropertyList propertyList = null, Finalizer finalizer = null)
            => Code(
                Classes.PublicStatic(typeName, @namespace, usingDirectiveList, documentationCommentList, attributeListCollection, typeParameterList, constraintClauseList, baseList, constructorList, fieldList, methodList, propertyList, finalizer),
                projectName);

        public static RepositoryFile CSharpInterface(string projectName, string typeName, string @namespace, UsingDirectiveList usingDirectiveList = null, DocumentationCommentList documentationCommentList = null, AttributeListCollection attributeListCollection = null, TypeParameterList typeParameterList = null, ConstraintClauseList constraintClauseList = null, BaseList baseList = null, MethodList methodList = null, PropertyList propertyList = null)
            => Code(
                Interfaces.Public(typeName, @namespace, usingDirectiveList, documentationCommentList, attributeListCollection, typeParameterList, constraintClauseList, baseList, methodList, propertyList),
                projectName);
    }
}
