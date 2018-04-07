using DevOps.Primitives.TypeScript;
using static System.Environment;

namespace DevOps.Primitives.SourceGraph.Helpers.TypeScript.Common.Files
{
    public static class TypeScriptCode
    {
        public static RepositoryFile Code(TypeDeclaration type, string copyright, params string[] pathParts)
            => new RepositoryFile(
                $"{type.Identifier}.ts",
                FormatCodeFile(type, copyright),
                pathParts);

        public static RepositoryFile TypeScriptClass(string copyright, string typeName, string @namespace, string comment, bool export = true, ImportStatementList importStatementList = null, DecoratorList decoratorList = null, TypeParameterList typeParameterList = null, Constructor constructor = null, MethodList methodList = null, PropertyList propertyList = null, BaseList extendsList = null, BaseList implementsList = null, bool isAbstract = false, params string[] pathParts)
            => Code(new ClassDeclaration(typeName, @namespace, comment, export, importStatementList, decoratorList, typeParameterList, constructor, methodList, propertyList, extendsList, implementsList, isAbstract), copyright, pathParts);

        public static RepositoryFile TypeScriptEnum(string copyright, string typeName, string @namespace, string comment, bool export = true, ImportStatementList importStatementList = null, EnumMemberList enumMemberList = null, params string[] pathParts)
            => Code(new EnumDeclaration(typeName, @namespace, comment, export, importStatementList, enumMemberList), copyright, pathParts);

        public static RepositoryFile TypeScriptInterface(string copyright, string typeName, string @namespace, string comment, bool export = true, ImportStatementList importStatementList = null, DecoratorList decoratorList = null, TypeParameterList typeParameterList = null, MethodList methodList = null, PropertyList propertyList = null, BaseList extendsList = null, params string[] pathParts)
            => Code(new InterfaceDeclaration(typeName, @namespace, comment, export, importStatementList, decoratorList, typeParameterList, methodList, propertyList, extendsList), copyright, pathParts);

        private static string FormatCodeFile(TypeDeclaration type, string copyright)
            => $"// {copyright}. All rights reserved.{NewLine}// Licensed under the GNU General Public License, Version 3.0. See the LICENSE document in the repository root for license information.{NewLine}{NewLine}{type}";
    }
}
