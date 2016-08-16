using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Microsoft.Cci;

namespace TourreauGilles.CciExplorer.Windows
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class CciExplorerApplication : Application
    {
        private IMetadataReaderHost metaDataReaderHost;
        
        public CciExplorerApplication()
        {
            this.metaDataReaderHost = new PeReader.DefaultHost();
        }

        public IMetadataReaderHost MetaDataReaderHost
        {
            get { return this.metaDataReaderHost; }
        }

        public new static CciExplorerApplication Current
        {
            get { return (CciExplorerApplication)Application.Current; }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            CciExplorerBootstrapper bootstrapper;
            
            bootstrapper = new CciExplorerBootstrapper();
            bootstrapper.Run();
        }
    }
}
