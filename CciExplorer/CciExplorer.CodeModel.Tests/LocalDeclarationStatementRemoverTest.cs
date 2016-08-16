using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.Cci;

namespace TourreauGilles.CciExplorer.CodeModel.Tests
{
    [TestClass]
    public class LocalDeclarationStatementRemoverTest : UnitTestBase
    {
        [TestMethod]
        [DeploymentItem("LocalDeclarationStatementRemoverTest.Visit.cs")]
        public void Test()
        {
            string assemblyFileName;
            LocalDeclarationStatementRemover remover;
            IAssembly assembly;

            assemblyFileName = Utilities.CompileFile("LocalDeclarationStatementRemoverTest.Visit.cs");

            remover = new LocalDeclarationStatementRemover();
            assembly = this.MetadataHost.DecompilFrom(assemblyFileName);

            remover.Visit(assembly);

            new VisitorCheck().Visit(assembly);
        }

        private class VisitorCheck : BaseCodeTraverser
        {
            public override void Visit(ILocalDeclarationStatement localDeclarationStatement)
            {
                Assert.Fail("The ILocalDeclarationStatement has not been deleted");
            }

            public override void Visit(IBlockStatement block)
            {
                // Only one statement
                Assert.AreEqual(2, block.Statements.Count());
                base.Visit(block);
            }

            public override void Visit(IMethodDefinition method)
            {
                if (method.IsConstructor == false)
                {
                    base.Visit(method);
                }
            }

            public override void Visit(IReturnStatement returnStatement)
            {
                Assert.IsInstanceOfType(returnStatement.Expression, typeof(IEquality));

                base.Visit(returnStatement);
            }
        }
    }
}
