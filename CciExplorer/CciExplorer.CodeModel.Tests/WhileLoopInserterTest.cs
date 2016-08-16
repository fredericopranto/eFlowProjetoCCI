using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Cci;
using Microsoft.Cci.MutableCodeModel;

namespace TourreauGilles.CciExplorer.CodeModel.Tests
{
    [TestClass]
    public class WhileLoopInserterTest : UnitTestBase
    {
        [TestMethod]
        [DeploymentItem("WhileLoopInserterTest.Visit.cs")]
        public void Test()
        {
            string assemblyFileName;
            WhileLoopInserter remover;
            IAssembly assembly;

            assemblyFileName = Utilities.CompileFile("WhileLoopInserterTest.Visit.cs");

            remover = new WhileLoopInserter();
            assembly = this.MetadataHost.DecompilFrom(assemblyFileName);

            remover.Visit(assembly);

            new VisitorCheck().Visit(assembly);
        }

        private class VisitorCheck : BaseCodeTraverser
        {
            private bool alreadyVisited;

            public override void Visit(IBlockStatement block)
            {
                if (alreadyVisited == true)
                {
                    return;
                }

                alreadyVisited = true;

                BlockStatement basicBlock;

                basicBlock = (BlockStatement)block;

                Assert.AreEqual(4, basicBlock.Statements.Count);

                // Check IWhileDoStatement
                Assert.IsInstanceOfType(basicBlock.Statements[1], typeof(IWhileDoStatement));
                IWhileDoStatement whileStatement;
                whileStatement = (IWhileDoStatement)basicBlock.Statements[1];
                
                // Check condition
                Assert.IsInstanceOfType(whileStatement.Condition, typeof(ICompileTimeConstant));

                // Check while block
                BlockStatement whileBlock;
                whileBlock = (BlockStatement)whileStatement.Body;
                Assert.AreEqual(1, whileBlock.Statements.Count);
                Assert.IsInstanceOfType(whileBlock.Statements[0], typeof(IExpressionStatement));
            }
        }
    }
}
