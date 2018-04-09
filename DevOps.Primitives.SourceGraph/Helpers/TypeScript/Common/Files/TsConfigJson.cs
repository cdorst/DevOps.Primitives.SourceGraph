using DevOps.Primitives.TypeScript;
using System.Collections.Generic;
using static DevOps.Primitives.SourceGraph.Helpers.TypeScript.Common.Files.ModuleTsConfigConstants;

namespace DevOps.Primitives.SourceGraph.Helpers.TypeScript.Common.Files
{
    public static class TsConfigJson
    {
        private const string FileName = "tsconfig.json";

        public static RepositoryFile TsConfig(TsConfigTarget target, TsConfigModule module, IEnumerable<TsConfigLib> lib = null, bool allowJs = false, bool checkJs = false, TsConfigJsx? jsx = null, bool declaration = false, bool sourceMap = false, string outFile = null, string outDir = null, string rootDir = null, bool removeComments = false, bool noEmit = false, bool importHelpers = false, bool downLevelIteration = false, bool isolatedModules = false, bool strict = false, bool noImplicitAny = false, bool strictNullChecks = false, bool strictFunctionsTypes = false, bool strictPropertyInitialization = false, bool noImplicitThis = false, bool alwaysStrict = false, bool noUnusedLocals = false, bool noUnusedParameters = false, bool noImplicitReturns = false, bool noFallthroughCasesInSwitch = false, TsConfigModuleResolution? moduleResolution = null, string baseUrl = null, IDictionary<string, IEnumerable<string>> paths = null, IEnumerable<string> rootDirs = null, IEnumerable<string> typeRoots = null, IEnumerable<string> types = null, bool allowSyntheticDefaultImports = false, bool esModuleInterop = false, bool preserveSymlinks = false, string sourceRoot = null, string mapRoot = null, bool inlineSourceMap = false, bool inlineSources = false, bool experimentalDecorators = false, bool emitDecoratorMetadata = false, IEnumerable<string> includePaths = null, params string[] pathParts)
            => new RepositoryFile(FileName, new TsConfigInfo(target, module, lib, allowJs, checkJs, jsx, declaration, sourceMap, outFile, outDir, rootDir, removeComments, noEmit, importHelpers, downLevelIteration, isolatedModules, strict, noImplicitAny, strictNullChecks, strictFunctionsTypes, strictPropertyInitialization, noImplicitThis, alwaysStrict, noUnusedLocals, noUnusedParameters, noImplicitReturns, noFallthroughCasesInSwitch, moduleResolution, baseUrl, paths, rootDirs, typeRoots, types, allowSyntheticDefaultImports, esModuleInterop, preserveSymlinks, sourceRoot, mapRoot, inlineSourceMap, inlineSources, experimentalDecorators, emitDecoratorMetadata, includePaths).ToString(), pathParts);

        public static RepositoryFile ModuleTsConfig(params string[] pathParts)
            => TsConfig(
                TsConfigTarget.ES5,
                TsConfigModule.commonjs,
                outDir: OutDir,
                sourceMap: true,
                strict: true,
                includePaths: IncludePaths,
                pathParts: pathParts);
    }
}
