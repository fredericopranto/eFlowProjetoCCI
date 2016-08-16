using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Cci;

namespace TourreauGilles.CciExplorer.CodeModel.Tests
{
    [TestClass]
    public class AssignmentReformerTest : UnitTestBase
    {
        [TestMethod]
        [DeploymentItem("AssignmentReformerTest.Visit.cs")]
        public void Test()
        {
            string assemblyFileName;
            AssignmentReformer remover;
            IAssembly assembly;

            assemblyFileName = Utilities.CompileFile("AssignmentReformerTest.Visit.cs");

            remover = new AssignmentReformer();
            assembly = this.MetadataHost.DecompilFrom(assemblyFileName);

            remover.Visit(assembly);
            
            new VisitorCheck().Visit(assembly);
        }

        [TestMethod]
        [DeploymentItem("AssignmentReformerTest.VisitPolymorphism.cs")]
        public void TestWithPolymorphism()
        {
            string assemblyFileName;
            AssignmentReformer remover;
            IAssembly assembly;

            assemblyFileName = Utilities.CompileFile("AssignmentReformerTest.VisitPolymorphism.cs");

            remover = new AssignmentReformer();
            assembly = this.MetadataHost.DecompilFrom(assemblyFileName);

            remover.Visit(assembly);

            new VisitorCheck().Visit(assembly);
        }

        private class VisitorCheck : BaseCodeTraverser
        {
            public override void Visit(IAssignment assignment)
            {
                Assert.IsTrue(assignment.Target.Type.ResolvedType.IsAssignableFrom(assignment.Source.Type.ResolvedType));
            }

            public override void Visit(ILocalDeclarationStatement localDeclarationStatement)
            {
                Assert.IsTrue(localDeclarationStatement.LocalVariable.Type.ResolvedType.IsAssignableFrom(localDeclarationStatement.InitialValue.Type.ResolvedType));
            }
        }
    }
}
