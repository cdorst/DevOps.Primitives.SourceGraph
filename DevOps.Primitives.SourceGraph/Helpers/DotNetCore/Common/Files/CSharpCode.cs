using DevOps.Primitives.CSharp;
using DevOps.Primitives.CSharp.Helpers.Common;
using System.Collections.Generic;
using System.Linq;
using static System.Environment;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.Common.Files
{
    public static class CSharpCode
    {
        private const string Separator = "; ";
        private const char Tab = '\t';

        public static RepositoryFile Code(TypeDeclaration type, params string[] pathParts)
            => new RepositoryFile(
                $"{type.Identifier.Name.Value}.cs",
                FormatBlockStatements(type),
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

        private static string FormatBlockStatements(TypeDeclaration type)
        {
            var contents = type.ToString();
            if (!contents.Contains(Separator)) return contents;
            var lines = contents.Split(new[] { NewLine }, System.StringSplitOptions.None);
            var formattedLines = new List<string>();
            foreach (var line in lines)
            {
                if (!line.Contains(Separator))
                {
                    formattedLines.Add(line);
                    continue;
                }
                var indentLevel = line.Count(character => character == Tab);
                var indent = new string(Tab, indentLevel);
                var statements = line.Split(new[] { Separator }, System.StringSplitOptions.None);
                foreach (var statement in statements)
                {
                    var trimmed = statement.TrimStart();
                    formattedLines.Add($"{indent}{trimmed};");
                }
            }
            return string.Join(NewLine, formattedLines);
        }
    }
}
