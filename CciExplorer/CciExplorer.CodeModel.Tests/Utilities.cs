using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Cci.ILToCodeModel;
using Microsoft.Cci;
using System.IO;

namespace TourreauGilles.CciExplorer.CodeModel.Tests
{
    internal static class Utilities
    {
        public static string CompileFile(string fileName)
        {
            CompilerParameters parameters;
            CompilerResults results;
            string assemblyName;

            assemblyName = Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + ".dll";

            parameters = new CompilerParameters();
            parameters.IncludeDebugInformation = true;
            parameters.OutputAssembly = Path.Combine(UnitTestBase.Current.TestContext.TestRunDirectory, assemblyName);

            results = CodeDomProvider.CreateProvider("C#").CompileAssemblyFromFile(parameters, fileName);

            Assert.AreEqual(0, results.Errors.Count);

            return results.PathToAssembly;
        }

        public static IAssembly DecompilFrom(this IMetadataHost host, string location)
        {
            IAssembly assembly;

            assembly = (IAssembly)host.LoadUnitFrom(location);

            return Decompiler.GetCodeModelFromMetadataModel(UnitTestBase.Current.MetadataHost, assembly, null);
        }
    }
}
