using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Cci;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TourreauGilles.CciExplorer.CodeModel.Tests
{
    [TestClass]
    public abstract class UnitTestBase
    {
        private static UnitTestBase current;

        private PeReader.DefaultHost metadataHost;

        public static UnitTestBase Current
        {
            get { return current; }
        }

        public TestContext TestContext
        {
            get;
            set;
        }

        public IMetadataHost MetadataHost
        {
            get { return this.metadataHost; }
        }

        [TestInitialize]
        public void Initialize()
        {
            current = this;

            this.metadataHost = new PeReader.DefaultHost();
        }

        [TestCleanup]
        public void End()
        {
            this.metadataHost.Dispose();
            this.metadataHost = null;

            current = null;
        }
    }
}
