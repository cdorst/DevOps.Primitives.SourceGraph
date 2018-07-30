using DevOps.Primitives.CSharp;
using DevOps.Primitives.CSharp.Helpers.Common;
using System.Collections.Generic;
using System.Linq;
using static System.Environment;
using static System.String;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.Common.Files
{
    public static class CSharpCode
    {
        private const string AutoGet = " get; ";
        private const string AutoSet = " set; ";
        private const string Semicolon = ";";
        private const string Separator = "; ";
        private const char Space = ' ';

        public static RepositoryFile Code(in TypeDeclaration type, in string copyright, params string[] pathParts)
            => new RepositoryFile(
                Concat(type.Identifier.Name.Value, ".cs"),
                FormatCodeFile(type, copyright),
                pathParts);

        public static RepositoryFile CSharpClass(
            in string copyright,
            in string projectName,
            in string typeName,
            in string @namespace,
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
            => Code(
                Classes.Public(in typeName, in @namespace, in usingDirectiveList, in documentationCommentList, in attributeListCollection, in typeParameterList, in constraintClauseList, in baseList, in constructorList, in fieldList, in methodList, in propertyList, in finalizer),
                in copyright,
                projectName);

        public static RepositoryFile CSharpStaticClass(
            in string copyright,
            in string projectName,
            in string typeName,
            in string @namespace,
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
            => Code(
                Classes.PublicStatic(in typeName, in @namespace, in usingDirectiveList, in documentationCommentList, in attributeListCollection, in typeParameterList, in constraintClauseList, in baseList, in constructorList, in fieldList, in methodList, in propertyList, in finalizer),
                in copyright,
                projectName);

        public static RepositoryFile CSharpInterface(
            in string copyright,
            in string projectName,
            in string typeName,
            in string @namespace,
            in UsingDirectiveList usingDirectiveList = default,
            in DocumentationCommentList documentationCommentList = default,
            in AttributeListCollection attributeListCollection = default,
            in TypeParameterList typeParameterList = default,
            in ConstraintClauseList constraintClauseList = default,
            in BaseList baseList = default,
            in MethodList methodList = default,
            in PropertyList propertyList = default)
            => Code(
                Interfaces.Public(in typeName, in @namespace, in usingDirectiveList, in documentationCommentList, in attributeListCollection, in typeParameterList, in constraintClauseList, in baseList, in methodList, in propertyList),
                in copyright,
                projectName);

        private static string FormatCodeFile(in TypeDeclaration type, in string copyright)
            => IsNullOrWhiteSpace(copyright)
                ? FormatBlockStatements(in type)
                : Concat("// ", copyright, ". All rights reserved.", NewLine, "// Licensed under the GNU General Public License, Version 3.0. See the LICENSE document in the repository root for license information.", NewLine, NewLine, FormatBlockStatements(in type));

        private static string FormatBlockStatements(in TypeDeclaration type)
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
                    var statementString = trimmed.EndsWith(Semicolon) ? trimmed : Concat(trimmed, ";");
                    formattedLines.Add(Concat(indent, statementString));
                }
            }
            return Join(NewLine, formattedLines);
        }
    }
}
