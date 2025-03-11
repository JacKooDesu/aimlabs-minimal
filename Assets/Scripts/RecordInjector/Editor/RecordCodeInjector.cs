#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

using Mono.Cecil;
using Mono.Cecil.Cil;

namespace RecordInjector.Editor
{
    using System.IO;
    // using ALM.Common;
    // using ALM.Screens.Base;
    // using ALM.Screens.Mission;

    public static class RecordCodeInjector
    {
        [PostProcessScene]
        [MenuItem("ALM/Inject")]
        public static void Inject()
        {
            if (EditorApplication.isCompiling || Application.isPlaying)
            {
                return;
            }
            EditorApplication.LockReloadAssemblies();

            try
            {
                // var resolver = new _Resolver();
                var location = AppDomain.CurrentDomain.GetAssemblies()
                    .FirstOrDefault(x => x.FullName.Contains("ALM"))
                    .Location;
                // resolver.Dispose();
                Debug.Log(location);

                var assembly = _ReadAssembly(location);

                var module = assembly.MainModule;
                var type = module.Types
                    .FirstOrDefault(x => x.Name.Contains("RecordService"));
                var methods = type?.Methods;
                var body = methods?
                    .FirstOrDefault(x => x.Name.Contains("Tick"))?.Body;

                var loggerMethod = AssemblyDefinition.ReadAssembly(typeof(Debug).Assembly.Location)
                    .MainModule.Types
                    .FirstOrDefault(x => x.Name is nameof(Debug))?.Methods
                    .FirstOrDefault(x => x.Name is nameof(Debug.Log));
                // var loggerMethod = _ReadAssembly(typeof(Debug).Assembly.Location)
                //     .MainModule.Types
                //     .FirstOrDefault(x => x.Name is nameof(Debug))?.Methods
                //     .FirstOrDefault(x => x.Name is nameof(Debug.Log));

                if (body is null || loggerMethod is null)
                    return;

                var il = body.GetILProcessor();
                var first = il.Body.Instructions[0];
                var logCall = il.Create(
                    OpCodes.Call,
                    body.Method.Module.ImportReference(
                        typeof(Debug).GetMethod("Log", new[] { typeof(System.Object) })));

                il.InsertBefore(first,
                    Instruction.Create(OpCodes.Ldstr, "hi!"));
                il.InsertBefore(first, logCall);

                assembly.MainModule?.SymbolReader?.Dispose();

                Debug.Log(location);
                _WriteAssembly(assembly, location);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }

            EditorApplication.UnlockReloadAssemblies();

            AssetDatabase.Refresh();
        }

        static AssemblyDefinition _ReadAssembly(string assemblyPath)
        {
            DefaultAssemblyResolver assemblyResolver = new();

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (assembly.IsDynamic)
                    continue;

                assemblyResolver.AddSearchDirectory(Path.GetDirectoryName(assembly.Location));
            }
            assemblyResolver.AddSearchDirectory(Path.GetDirectoryName(EditorApplication.applicationPath) + "/Data/Managed");

            var readerParameters = new ReaderParameters
            {
                ReadWrite = true,
                AssemblyResolver = assemblyResolver
            };

            if (File.Exists(assemblyPath + ".mdb"))
            {
                readerParameters.ReadSymbols = true;
                return AssemblyDefinition.ReadAssembly(
                    assemblyPath, readerParameters);
            }
            else
            {
                return AssemblyDefinition.ReadAssembly(assemblyPath, readerParameters);
            }
        }

        static void _WriteAssembly(AssemblyDefinition assembly, string location)
        {
            WriterParameters writerParameters = new();
            if (File.Exists(location + ".mdb"))
            {
                writerParameters.WriteSymbols = true;
                assembly.Write(writerParameters);
            }
            else
            {
                assembly.Write(writerParameters);
            }
        }
    }

    class _Resolver : BaseAssemblyResolver
    {
        DefaultAssemblyResolver _r;
        internal Dictionary<string, Assembly> _aDict;

        public _Resolver()
        {
            _r = new();
            _aDict = AppDomain.CurrentDomain.GetAssemblies()
                .ToDictionary(x => x.FullName);
        }

        public override AssemblyDefinition Resolve(AssemblyNameReference name)
        {
            AssemblyDefinition result;
            try
            {
                result = _r.Resolve(name);
            }
            catch
            {
                if (_aDict.TryGetValue(name.FullName, out var a))
                    result = AssemblyDefinition.ReadAssembly(a.Location);
                else
                    throw new Exception($"Domain not contains {name}");
            }

            return result;
        }

        public Assembly GetAssembly(string name) => _aDict[name];
        public Assembly SearchAssembly(string name) =>
            AppDomain.CurrentDomain.GetAssemblies()
                .FirstOrDefault(x => x.FullName.Contains(name));
    }
}

#endif