using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Cci;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TourreauGilles.CciExplorer.CodeModel.Tests
{
    [TestClass]
    public class CodeModelExtensionsTest : UnitTestBase
    {
        [TestMethod]
        [DeploymentItem("CodeModelExtensionsTest.IsAssignableFromTest.cs")]
        public void IsAssignableFromTest()
        {
            string assemblyFileName;
            IAssembly assembly;

            INamedTypeDefinition baseClass;
            INamedTypeDefinition derivedClass;
            INamedTypeDefinition baseInterface;
            INamedTypeDefinition derivedInterface;
            
            assemblyFileName = Utilities.CompileFile("CodeModelExtensionsTest.IsAssignableFromTest.cs");
            assembly = this.MetadataHost.DecompilFrom(assemblyFileName);

            baseClass = assembly.GetAllTypes().Where(t => t.Name.Value == "Base").SingleOrDefault();
            derivedClass = assembly.GetAllTypes().Where(t => t.Name.Value == "Derived").SingleOrDefault();
            baseInterface = assembly.GetAllTypes().Where(t => t.Name.Value == "IBase").SingleOrDefault();
            derivedInterface = assembly.GetAllTypes().Where(t => t.Name.Value == "IDerived").SingleOrDefault();

            Assert.IsTrue(baseClass.IsAssignableFrom(baseClass));
            Assert.IsTrue(baseClass.IsAssignableFrom(derivedClass));
            Assert.IsFalse(baseClass.IsAssignableFrom(baseInterface));
            Assert.IsFalse(baseClass.IsAssignableFrom(derivedInterface));

            Assert.IsFalse(derivedClass.IsAssignableFrom(baseClass));
            Assert.IsTrue(derivedClass.IsAssignableFrom(derivedClass));
            Assert.IsFalse(derivedClass.IsAssignableFrom(baseInterface));
            Assert.IsFalse(derivedClass.IsAssignableFrom(derivedInterface));

            Assert.IsTrue(baseInterface.IsAssignableFrom(baseClass));
            Assert.IsTrue(baseInterface.IsAssignableFrom(derivedClass));
            Assert.IsTrue(baseInterface.IsAssignableFrom(baseInterface));
            Assert.IsTrue(baseInterface.IsAssignableFrom(derivedInterface));
            
            Assert.IsFalse(derivedInterface.IsAssignableFrom(baseClass));
            Assert.IsTrue(derivedInterface.IsAssignableFrom(derivedClass));
            Assert.IsFalse(derivedInterface.IsAssignableFrom(baseInterface));
            Assert.IsTrue(derivedInterface.IsAssignableFrom(derivedInterface));
        }
    }
}
