using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Cci;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Cci.MutableCodeModel;

namespace TourreauGilles.CciExplorer.CodeModel.Tests
{
    [TestClass]
    public class UnaryNegationAndPlusInserterTest : UnitTestBase
    {
        [TestMethod]
        [DeploymentItem("UnaryNegationAndPlusInserterTest.Visit.cs")]
        public void Test()
        {
            string assemblyFileName;
            UnaryNegationAndPlusInserter remover;
            IAssembly assembly;

            assemblyFileName = Utilities.CompileFile("UnaryNegationAndPlusInserterTest.Visit.cs");

            remover = new UnaryNegationAndPlusInserter();
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
                IExpressionStatement expressionStatement;

                basicBlock = (BlockStatement)block;

                Assert.AreEqual(3, basicBlock.Statements.Count);

                Assert.IsInstanceOfType(basicBlock.Statements[0], typeof(IExpressionStatement));
                expressionStatement = (IExpressionStatement)basicBlock.Statements[0];
                Assert.IsInstanceOfType(expressionStatement.Expression, typeof(IUnaryPlus));

                Assert.IsInstanceOfType(basicBlock.Statements[1], typeof(IExpressionStatement));
                expressionStatement = (IExpressionStatement)basicBlock.Statements[1];
                Assert.IsInstanceOfType(expressionStatement.Expression, typeof(IUnaryNegation));
            }
        }
    }
}
