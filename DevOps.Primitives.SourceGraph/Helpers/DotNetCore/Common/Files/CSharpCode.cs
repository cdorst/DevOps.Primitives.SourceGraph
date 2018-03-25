using DevOps.Primitives.CSharp;
using DevOps.Primitives.CSharp.Helpers.Common;
using System.Collections.Generic;
using System.Linq;
using static System.Environment;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.Common.Files
{
    public static class CSharpCode
    {
        private const string AutoGet = " get; ";
        private const string AutoSet = " set; ";
        private const string Separator = "; ";
        private const char Space = ' ';

        public static RepositoryFile Code(TypeDeclaration type, string copyright, params string[] pathParts)
            => new RepositoryFile(
                $"{type.Identifier.Name.Value}.cs",
                FormatCodeFile(type, copyright),
                pathParts);

        public static RepositoryFile CSharpClass(string copyright, string projectName, string typeName, string @namespace, UsingDirectiveList usingDirectiveList = null, DocumentationCommentList documentationCommentList = null, AttributeListCollection attributeListCollection = null, TypeParameterList typeParameterList = null, ConstraintClauseList constraintClauseList = null, BaseList baseList = null, ConstructorList constructorList = null, FieldList fieldList = null, MethodList methodList = null, PropertyList propertyList = null, Finalizer finalizer = null)
            => Code(
                Classes.Public(typeName, @namespace, usingDirectiveList, documentationCommentList, attributeListCollection, typeParameterList, constraintClauseList, baseList, constructorList, fieldList, methodList, propertyList, finalizer),
                copyright,
                projectName);

        public static RepositoryFile CSharpStaticClass(string copyright, string projectName, string typeName, string @namespace, UsingDirectiveList usingDirectiveList = null, DocumentationCommentList documentationCommentList = null, AttributeListCollection attributeListCollection = null, TypeParameterList typeParameterList = null, ConstraintClauseList constraintClauseList = null, BaseList baseList = null, ConstructorList constructorList = null, FieldList fieldList = null, MethodList methodList = null, PropertyList propertyList = null, Finalizer finalizer = null)
            => Code(
                Classes.PublicStatic(typeName, @namespace, usingDirectiveList, documentationCommentList, attributeListCollection, typeParameterList, constraintClauseList, baseList, constructorList, fieldList, methodList, propertyList, finalizer),
                copyright,
                projectName);

        public static RepositoryFile CSharpInterface(string copyright, string projectName, string typeName, string @namespace, UsingDirectiveList usingDirectiveList = null, DocumentationCommentList documentationCommentList = null, AttributeListCollection attributeListCollection = null, TypeParameterList typeParameterList = null, ConstraintClauseList constraintClauseList = null, BaseList baseList = null, MethodList methodList = null, PropertyList propertyList = null)
            => Code(
                Interfaces.Public(typeName, @namespace, usingDirectiveList, documentationCommentList, attributeListCollection, typeParameterList, constraintClauseList, baseList, methodList, propertyList),
                copyright,
                projectName);

        private static string FormatCodeFile(TypeDeclaration type, string copyright)
            => $"// {copyright}. All rights reserved.{NewLine}// Licensed under the GNU General Public License, Version 3.0. See the LICENSE document in the repository root for license information.{NewLine}{NewLine}{FormatBlockStatements(type)}";

        private static string FormatBlockStatements(TypeDeclaration type)
        {
            var contents = type.ToString();
            if (!contents.Contains(Separator)) return contents;
            var lines = contents.Split(new[] { NewLine }, System.StringSplitOptions.None);
            var formattedLines = new List<string>();
            foreach (var line in lines)
            {
                if (!line.Contains(Separator) || line.Contains(AutoGet) || line.Contains(AutoSet))
                {
                    formattedLines.Add(line);
                    continue;
                }
                var indentLevel = line.TakeWhile(character => character == Space).Count();
                var indent = new string(Space, indentLevel);
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
