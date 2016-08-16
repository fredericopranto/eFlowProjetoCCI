using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Cci;

namespace TourreauGilles.CciExplorer.CodeModel.Tests
{
    [TestClass]
    public class TryCatchGotoRemoverTest : UnitTestBase
    {
        [TestMethod]
        [DeploymentItem("TryCatchGotoRemoverTest.Visit.cs")]
        public void Test()
        {
            string assemblyFileName;
            TryCatchAnalizer remover;
            IAssembly assembly;
            
            assemblyFileName = Utilities.CompileFile("TryCatchGotoRemoverTest.Visit.cs");

            remover = new TryCatchAnalizer();
            assembly = this.MetadataHost.DecompilFrom(assemblyFileName);

            remover.Visit(assembly);

            new VisitorCheck().Visit(assembly);
        }

        private class VisitorCheck : BaseCodeTraverser
        {
            public override void Visit(IGotoStatement gotoStatement)
            {
                Assert.Fail("Goto statement found ({0})", gotoStatement.TargetStatement.Label.Value);
            }

            public override void Visit(ILabeledStatement labeledStatement)
            {
                Assert.Fail("Labeled statement found ({0})", labeledStatement.Label.Value);
            }
        }
    }
}
